namespace APIQuanLyBanHang.Entity
{
    public class NhanVienEntities
    {

        public Guid? IdNhanVien { get; set; }
        public Guid? IdTaiKhoan { get; set; }
        public Guid? IdChiNhanh { get; set; }
        public string? TenNhanVien { get; set; }
        public string? SoDienThoai { get; set; }
        public DateTime NgayBatDauLamViec { get; set; }
        public string? SoCCCD {  get; set; }
        public DateTime NgaySinh {  get; set; }
        public bool GioiTinh { get; set; }
        public string? Email {  get; set; }
        public string? DiaChi { get; set;}
        public string? TrangThai { get; set; }
        public string?  GhiChuNhanVien { get; set; }

    }
}
