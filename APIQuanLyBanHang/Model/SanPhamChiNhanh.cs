using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIQuanLyBanHang.Model;

public partial class SanPhamChiNhanh
{
    [Key, Column(Order = 0)]
    public string IdsanPham { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string IdchiNhanh { get; set; } = null!;

    public string? GhiChu { get; set; }

    public virtual ChiNhanh IdchiNhanhNavigation { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
