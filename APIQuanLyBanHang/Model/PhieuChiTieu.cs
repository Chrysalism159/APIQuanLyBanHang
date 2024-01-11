using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class PhieuChiTieu
{
    public string IdphieuChi { get; set; } = null!;

    public string? IdnhanVien { get; set; }

    public string? IdchiNhanh { get; set; }

    public string? TenPhieuChi { get; set; }

    public decimal? SoTienChi { get; set; }

    public DateTime? ThoiGianLapPhieu { get; set; }

    public string? GhiChu { get; set; }

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhanVien? IdnhanVienNavigation { get; set; }
}
