namespace APIQuanLyBanHang.Entity
{
    public class HoaDonEntities
    {
        public Guid IdHoaDon { get; set; }
        public Guid? IdChiNhanh { get; set; }
        public Guid? IdNhanVien { get; set; }
        public Guid IdTheThanhVien { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public decimal SoTienKhachTra {  get; set; }
        public decimal TongTienSauChietKhau { get; set; }
        public string? GhiChuHoaDon { get; set; }
    }
}
