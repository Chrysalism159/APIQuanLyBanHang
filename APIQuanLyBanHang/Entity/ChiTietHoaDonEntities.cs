namespace APIQuanLyBanHang.Entity
{
    public class ChiTietHoaDonEntities
    {
        public Guid IdChiTietHoaDon { get; set; }
        public Guid? IdHoaDon { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid IdPhieuNhapHang { get; set; }
        public Guid IdPhieuChi { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public string? GhiChuChiTietHoaDon { get; set; }
    }
}
