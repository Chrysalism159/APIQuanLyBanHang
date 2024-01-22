using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class Anh
{
    public string Idanh { get; set; } = null!;

    public string? FileAnh { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
