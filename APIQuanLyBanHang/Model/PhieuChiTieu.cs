using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class PhieuChiTieu
{
    [Key, Column(Order = 0)]
    public string IdphieuChi { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? IdnhanVien { get; set; }
    [Key, Column(Order = 2)]
    public string? IdchiNhanh { get; set; }

    public string? TenPhieuChi { get; set; }

    public decimal? SoTienChi { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ThoiGianLapPhieu { get; set; }

    public string? GhiChu { get; set; }

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhanVien? IdnhanVienNavigation { get; set; }
}
