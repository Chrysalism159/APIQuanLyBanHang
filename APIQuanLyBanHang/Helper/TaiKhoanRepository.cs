using Microsoft.AspNetCore.Identity;

namespace APIQuanLyBanHang.Helper
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public Task<string> SignInAsync(QuanLyThongTinTaiKhoan tt)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> SignUpAsync(QuanLyThongTinTaiKhoan tt)
        {
            throw new NotImplementedException();
        }
    }
}
