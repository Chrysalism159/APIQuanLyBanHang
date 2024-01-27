using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIQuanLyBanHang.Helper
{
    public interface ITaiKhoanRepositories
    {
        public Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan tt);
        public Task<TrangThai> SignInAsync(QuanLyTaiKhoanDangNhap tt);
        public Task<TrangThai> SignOutAsync(QuanLyTaiKhoanDangNhap tt);
    }
    public class TaiKhoanRepositories : ITaiKhoanRepositories
    {
        private readonly UserManager<TaiKhoanNguoiDung> userManager;
        private readonly SignInManager<TaiKhoanNguoiDung> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public TaiKhoanRepositories(
                UserManager<TaiKhoanNguoiDung> userManager, SignInManager<TaiKhoanNguoiDung> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager
                )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;

        }

        public async Task<TrangThai> SignInAsync(QuanLyTaiKhoanDangNhap model)
        {
            var user = await userManager.FindByEmailAsync(model.TaiKhoanEmail);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.MatKhau);

            if (user == null || !passwordValid)
            {
                return new TrangThai { MaTrangThai= 0, ThongBao="Login failed!"};
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.TaiKhoanEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TrangThai { MaTrangThai = 1, ThongBao=tokenString };
        }

        public async Task<TrangThai> SignOutAsync(QuanLyTaiKhoanDangNhap tt)
        {
            var user = await userManager.FindByEmailAsync(tt.TaiKhoanEmail);

            // Chưa xác thực hoặc không có người dùng, không thể hủy token
            if (user==null)
            {
                return new TrangThai { MaTrangThai = 0, ThongBao = "Không tìm được thông tin tài khoản!" };
            }

            else
            {
                // Đăng xuất người dùng
                await signInManager.SignOutAsync();

                // Nếu cần, bạn cũng có thể thêm các bước khác như đặt trạng thái hủy token cho người dùng tại đây.

                return new TrangThai { MaTrangThai = 1, ThongBao = "Đăng xuất thành công!" };
            }

            return new TrangThai { MaTrangThai = 0, ThongBao = "Token vô hiệu!" };
        }

        public async Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan model)
        {
            var user = new TaiKhoanNguoiDung
            {

                Email = model.TaiKhoanEmail,
                UserName = model.TaiKhoanEmail
            };

            var result = await userManager.CreateAsync(user, model.MatKhau);

            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có
                if (!await roleManager.RoleExistsAsync(QuyenTruyCap.QuanLy))
                {
                    await roleManager.CreateAsync(new IdentityRole(QuyenTruyCap.QuanLy));
                }
                if (!await roleManager.RoleExistsAsync(QuyenTruyCap.NhanVien))
                {
                    await roleManager.CreateAsync(new IdentityRole(QuyenTruyCap.NhanVien));
                }

                if(model.PhanQuyen.Equals(QuyenTruyCap.NhanVien))
                {
                    await userManager.AddToRoleAsync(user, QuyenTruyCap.NhanVien);
                }
                else
                    await userManager.AddToRoleAsync(user, QuyenTruyCap.QuanLy);
            }
            return result;
        }
    }
}
