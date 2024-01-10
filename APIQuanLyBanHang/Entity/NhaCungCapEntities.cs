namespace APIQuanLyBanHang.Entity
{
    public class NhaCungCapEntities
    {
        public Guid IdNhaCungCap { get; set; }
        public string? TenNhaCungCap { get; set; }
        public string? TenNguoiDaiDien { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public decimal SoTienNhapHang { get; set; }
        public decimal SoTienDaThanhToan { get; set; }
        public string? GhiChuNhaCungCap { get; set; }
    }
}
