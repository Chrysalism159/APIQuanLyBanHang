using APIQuanLyBanHang.Data;
using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIQuanLyBanHang.Repository
{
    public class TaiKhoanRepo : ITaiKhoanRepo
    {
        private readonly UserManager<TaiKhoanNguoiDung> userManager;
        private readonly SignInManager<TaiKhoanNguoiDung> signinModel;
        private readonly IConfiguration config;

        public TaiKhoanRepo(UserManager<TaiKhoanNguoiDung> userManager, SignInManager<TaiKhoanNguoiDung> signInModel,
            IConfiguration config)
        {
            this.userManager = userManager;
            this.signinModel = signInModel;
            this.config = config;
        }

        public async Task<string> SignInAsync(Account signin)
        {
            var result = await signinModel.PasswordSignInAsync(signin.TenNguoiDung, signin.MatKhau, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var authen = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
            var token = new JwtSecurityToken
            (
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudience"],
                expires: DateTime.Now.AddMonths(1),
                claims: authen,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512)

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(Account signup)
        {
            var user = new TaiKhoanNguoiDung
            {
                UserName = signup.TenNguoiDung,
                Password = signup.MatKhau,
                Email = signup.Email,
                IdtaiKhoan = Guid.NewGuid().ToString()
            };
            return await userManager.CreateAsync(user, signup.MatKhau);
        }
    }
}
