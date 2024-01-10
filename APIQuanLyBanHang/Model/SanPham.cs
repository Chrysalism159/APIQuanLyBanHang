using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class SanPham
{
    [Key, Column(Order = 0)]
    public string IdsanPham { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? Idanh { get; set; }

    public string? TenSanPham { get; set; }

    public decimal? GiaBan { get; set; }

    public decimal? GiaVon { get; set; }

    public string? DonVi { get; set; }

    public int? SoLuongHienCo { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Anh? IdanhNavigation { get; set; }
}
