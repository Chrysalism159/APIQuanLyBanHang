﻿using APIQuanLyBanHang.InterfaceRepo;
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
        public Task<string> SignInAsync(QuanLyTaiKhoanDangNhap tt);
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

        public async Task<string> SignInAsync(QuanLyTaiKhoanDangNhap model)
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

                await userManager.AddToRoleAsync(user, QuyenTruyCap.QuanLy);
            }
            return result;
        }
    }
}