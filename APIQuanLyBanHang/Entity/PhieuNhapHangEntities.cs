namespace APIQuanLyBanHang.Entity
{
    public class PhieuNhapHangEntities
    {
        public Guid IdphieuNhapHang { get; set; } 
        public Guid IdnhanVien { get; set; } 

        public Guid? IdnhaCungCap { get; set; }

        public Guid? IdchiNhanh { get; set; }

        public string? TenHangNhap { get; set; }

        public decimal? ChietKhau { get; set; }

        public decimal? TongTienSauChietKhau { get; set; }

        public decimal? TongTienThanhToan { get; set; }

        public DateTime? ThoiGianLapHoaDon { get; set; }

        public string? GhiChu { get; set; }
    }
}
