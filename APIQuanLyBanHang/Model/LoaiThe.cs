using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class LoaiThe
{
    [Key]
    public string IdloaiThe { get; set; } = null!;

    public string? TenLoaiThe { get; set; }

    public string? HanMuc { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<TheThanhVien> TheThanhViens { get; set; } = new List<TheThanhVien>();
}
