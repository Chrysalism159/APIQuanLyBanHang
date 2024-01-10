namespace APIQuanLyBanHang.Entity
{
    public class PhieuNhapHangEntities
    {
        public Guid IdPhieuNhapHang { get; set; }
        public Guid? IdChiNhanh { get; set; }
        public Guid? IdNhanVien { get; set; }
        public Guid IdNhaCungCap { get; set; }
        public decimal  ChietKhau { get; set; }
        public decimal TongTienSauChietKhau { get; set; }
        public decimal TongTienThanhToan { get; set; }
        public DateTime ThoiGianLapHoaDon {  get; set; }
        public string? GhiChuPhieuNhapHang { get; set; }
    }
}
