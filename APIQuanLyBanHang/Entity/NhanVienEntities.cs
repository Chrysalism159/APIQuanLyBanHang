namespace APIQuanLyBanHang.Entity
{
    public class NhanVienEntities
    {

        public Guid IdnhanVien { get; set; }

        public Guid? IdchiNhanh { get; set; }

        public Guid? IdtaiKhoan { get; set; }

        public string? TenNhanVien { get; set; }

        public string? Sdt { get; set; }

        public DateTime? NgayBatDauLamViec { get; set; }

        public string? Cccd { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public string? Email { get; set; }

        public string? ĐiaChi { get; set; }

        public string? TrangThai { get; set; }

        public string? GhiChu { get; set; }

    }
}
