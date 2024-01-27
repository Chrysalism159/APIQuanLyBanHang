using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class ChiTietHoaDon
{
    public string IdchiTietHoaDon { get; set; } = null!;

    public string? IdhoaDon { get; set; }

    public string? IdsanPham { get; set; }

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
