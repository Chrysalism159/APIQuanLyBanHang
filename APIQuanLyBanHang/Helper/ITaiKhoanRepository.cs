using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Helper
{
    public interface ITaiKhoanRepository
    {
        public Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan tt);
        public Task<string> SignInAsync(QuanLyTaiKhoanDangNhap tt);
    }
}
