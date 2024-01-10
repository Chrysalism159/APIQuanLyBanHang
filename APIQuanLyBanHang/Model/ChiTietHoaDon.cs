using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIQuanLyBanHang.Model;

public partial class ChiTietHoaDon
{
    [Key, Column(Order =0)]
    public string IdchiTietHoaDon { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? IdhoaDon { get; set; }
    [Key, Column(Order = 2)]
    public string? IdsanPham { get; set; }
    [Key, Column(Order = 3)]
    public string? IdphieuNhapHang { get; set; }

    public decimal? ChietKhau { get; set; }

    public int? SoLuong { get; set; }

    public decimal? Dongia { get; set; }

    public decimal? ThanhTien { get; set; }

    public string? GhiChu { get; set; }

    public virtual HoaDon? IdhoaDonNavigation { get; set; }

    public virtual PhieuNhapHang? IdphieuNhapHangNavigation { get; set; }

    public virtual SanPham? IdsanPhamNavigation { get; set; }
}
