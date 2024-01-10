namespace APIQuanLyBanHang.Entity
{
    public class SanPhamEntities
    {
        public Guid IdSanPham { get; set; }
        public string? LoaiSanPham { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? GiaVon { get; set; }
        public string? DonVi { get; set; }
        public int? SoLuongHienCo { get; set; }
        public string? GhiChuSanPham { get; set; }
    }
}
