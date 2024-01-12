namespace APIQuanLyBanHang.Entity
{
    public class HoaDonEntities
    {       
        public Guid IdhoaDon { get; set; } 

        public Guid? IdchiNhanh { get; set; }

        public Guid? IdnhanVien { get; set; }

        public Guid? IdtheThanhVien { get; set; }

        public DateTime? NgayLapHoaDon { get; set; }

        public decimal? SoTienKhachTra { get; set; }

        public decimal? TongTienSauChietKhau { get; set; }

        public string? GhiChu { get; set; }

        public List<ChiTietHoaDonEntities>? ChiTietHD{ get; set; }
    }
}
