using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class SanPham
{
    public string IdsanPham { get; set; } = null!;

    public string? Idanh { get; set; }

    public string? TenSanPham { get; set; }

    public decimal? GiaBan { get; set; }

    public decimal? GiaVon { get; set; }

    public string? DonVi { get; set; }

    public int? SoLuongHienCo { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Anh? IdanhNavigation { get; set; }

    public virtual ICollection<SanPhamChiNhanh> SanPhamChiNhanhs { get; set; } = new List<SanPhamChiNhanh>();
}
