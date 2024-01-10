namespace APIQuanLyBanHang.Entity
{
    public class TheKhachHangEntities
    {
        public Guid IdTheThanhVien { get; set; }
        public Guid? IdLoaiThe { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public int? SoDiemTichLuy { get; set; }
        public int? SoDiemDaSuDung { get; set; }
        public int? SoTienTichLuy { get; set; }
        public int? SoTienDaSuDung { get; set; }
        public bool? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string? GhiChuKhachHang {  get; set; }
    }
}
