namespace APIQuanLyBanHang.Entity
{
    public class NhaCungCapEntities
    {
        public Guid IdnhaCungCap { get; set; } 

        public string? TenNhaCungCap { get; set; }

        public string? TenNguoiDaiDien { get; set; }

        public string? Sdt { get; set; }

        public int? DiaChi { get; set; }

        public decimal? SoTienNhapHang { get; set; }

        public decimal? SoTienDaThanhToan { get; set; }

        public string? GhiChu { get; set; }
    }
}
