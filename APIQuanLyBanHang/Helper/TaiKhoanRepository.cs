using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static APIQuanLyBanHang.Helper.TaiKhoanRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIQuanLyBanHang.Helper
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
            private readonly UserManager<TaiKhoanNguoiDung> userManager;
            private readonly SignInManager<TaiKhoanNguoiDung> signInManager;
            private readonly IConfiguration configuration;
            private readonly RoleManager<IdentityRole> roleManager;

            public TaiKhoanRepository(UserManager<TaiKhoanNguoiDung> userManager, SignInManager<TaiKhoanNguoiDung> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
                this.configuration = configuration;
                this.roleManager = roleManager;

            }

            public async Task<string> SignInAsync(QuanLyThongTinTaiKhoan model)
            {
                var user = await userManager.FindByEmailAsync(model.TaiKhoanEmail);
                var passwordValid = await userManager.CheckPasswordAsync(user, model.MatKhau);

                if (user == null || !passwordValid)
                {
                    return string.Empty;
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
                    expires: DateTime.Now.AddMinutes(20),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public async Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan model)
            {
                var user = new TaiKhoanNguoiDung
                {
                    
                    Email = model.TaiKhoanEmail,
                    UserName = model.TenNguoiDung
                };

                var result = await userManager.CreateAsync(user, model.MatKhau);

                if (result.Succeeded)
                {
                    //kiểm tra role Customer đã có
                    if (!await roleManager.RoleExistsAsync(QuyenTruyCap.NhanVien))
                    {
                        await roleManager.CreateAsync(new IdentityRole(QuyenTruyCap.NhanVien));
                    }

                    await userManager.AddToRoleAsync(user, QuyenTruyCap.NhanVien);
                }
                return result;
            }
        }
}
