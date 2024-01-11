namespace APIQuanLyBanHang.Entity
{
    public class PhieuChiTieuEntities
    {
        public Guid IdphieuChi { get; set; }

        public Guid? IdnhanVien { get; set; }

        public Guid? IdchiNhanh { get; set; }

        public string? TenPhieuChi { get; set; }

        public decimal? SoTienChi { get; set; }

        public DateTime? ThoiGianLapPhieu { get; set; }

        public string? GhiChu { get; set; }
    }
}
