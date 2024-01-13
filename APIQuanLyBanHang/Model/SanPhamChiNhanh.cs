using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class SanPhamChiNhanh
{
    public string IdsanPham { get; set; } = null!;

    public string IdchiNhanh { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ChiNhanh IdchiNhanhNavigation { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
