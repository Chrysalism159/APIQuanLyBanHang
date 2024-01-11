using Microsoft.AspNetCore.Identity;

namespace APIQuanLyBanHang.Helper
{
    public interface ITaiKhoanRepository
    {
        public Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan tt);
        public Task<string> SignInAsync(QuanLyThongTinTaiKhoan tt);
    }
}
