using Microsoft.AspNetCore.Identity;

namespace APIQuanLyBanHang.Helper
{
    public interface ITaiKhoanRepository
    {
        public Task<string> SignInAsync(QuanLyThongTinTaiKhoan tt);
        public Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan tt);
    }
}
