using Microsoft.AspNetCore.Identity;

namespace APIQuanLyBanHang.Model
{
    public class TaiKhoanNguoiDung : IdentityUser
    {
        public string IdtaiKhoan { get; set; } = null!;

        public string? TenNguoiDung { get; set; }

        public string? Password { get; set; }

        public string? PhanQuyen { get; set; }

        public string? GhiChu { get; set; }
    }
}
