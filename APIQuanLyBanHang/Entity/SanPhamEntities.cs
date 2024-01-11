namespace APIQuanLyBanHang.Entity
{
    public class SanPhamEntities
    {
        public Guid IdsanPham { get; set; } 

        public string? Idanh { get; set; }

        public string? TenSanPham { get; set; }

        public decimal? GiaBan { get; set; }

        public decimal? GiaVon { get; set; }

        public string? DonVi { get; set; }

        public int? SoLuongHienCo { get; set; }

        public string? GhiChu { get; set; }
    }
}
