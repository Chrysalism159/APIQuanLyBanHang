using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class HoaDon
{
    public string IdhoaDon { get; set; } = null!;

    public string? IdchiNhanh { get; set; }

    public string? IdnhanVien { get; set; }

    public string? IdtheThanhVien { get; set; }

    public DateTime? NgayLapHoaDon { get; set; }

    public decimal? SoTienKhachTra { get; set; }

    public decimal? TongTienSauChietKhau { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhanVien? IdnhanVienNavigation { get; set; }

    public virtual TheThanhVien? IdtheThanhVienNavigation { get; set; }
}
