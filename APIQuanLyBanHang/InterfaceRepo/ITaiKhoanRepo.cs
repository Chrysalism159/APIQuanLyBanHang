using APIQuanLyBanHang.Data;
using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using Microsoft.AspNetCore.Identity;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITaiKhoanRepo
    {
        public Task<string> SignInAsync(Account signin);
        public Task<IdentityResult> SignUpAsync(Account signup);
    }
}
