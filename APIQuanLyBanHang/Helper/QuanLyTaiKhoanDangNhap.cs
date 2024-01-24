using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Helper
{
    public class QuanLyTaiKhoanDangNhap
    {
        [Required, EmailAddress]
        public string? TaiKhoanEmail { get; set; }
        [Required]
        public string? MatKhau { get; set; }
    }
}
