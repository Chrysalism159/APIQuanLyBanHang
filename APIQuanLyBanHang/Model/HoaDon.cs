using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class HoaDon
{
    [Key, Column(Order = 0)]
    public string IdhoaDon { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? IdchiNhanh { get; set; }
    [Key, Column(Order = 2)]
    public string? IdnhanVien { get; set; }
    [Key, Column(Order = 3)]
    public string? IdtheThanhVien { get; set; }
    [DataType(DataType.Date)]
    public DateTime? NgayLapHoaDon { get; set; }

    public decimal? SoTienKhachTra { get; set; }

    public decimal? TongTienSauChietKhau { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhanVien? IdnhanVienNavigation { get; set; }

    public virtual TheThanhVien? IdtheThanhVienNavigation { get; set; }
}
