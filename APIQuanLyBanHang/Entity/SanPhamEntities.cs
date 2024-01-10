namespace APIQuanLyBanHang.Entity
{
    public class SanPhamEntities
    {
        public Guid IdSanPham { get; set; }
        public Guid IdHinhAnh { get; set; }
        public string? TenSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaVon { get; set; }
        public string? DonVi { get; set; }
        public int? SoLuongHienCo { get; set; }
        public string? GhiChuSanPham { get; set; }
    }
}
