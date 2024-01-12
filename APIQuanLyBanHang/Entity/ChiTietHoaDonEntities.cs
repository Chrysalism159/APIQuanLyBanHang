namespace APIQuanLyBanHang.Entity
{
    public class ChiTietHoaDonEntities
    {        
        public Guid IdchiTietHoaDon { get; set; } 

        public Guid? IdhoaDon { get; set; }

        public Guid? IdsanPham { get; set; }

        public Guid? IdphieuNhapHang { get; set; }

       

        public decimal? ChietKhau { get; set; }

        public int? SoLuong { get; set; }

        public decimal? Dongia { get; set; }

        public decimal? ThanhTien { get; set; }

        public string? GhiChu { get; set; }
    }
}
