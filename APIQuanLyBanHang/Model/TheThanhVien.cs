using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class TheThanhVien
{
    [Key, Column(Order = 0)]
    public string IdtheThanhVien { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? IdloaiThe { get; set; }

    public string? TenKhachHang { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public double? SoDiemTichLuy { get; set; }

    public double? SoDiemDaSuDung { get; set; }

    public decimal? SoTienDaTichLuy { get; set; }

    public decimal? SoTienDaSuDung { get; set; }

    public bool? GioiTinh { get; set; }

    public string? ĐiaChi { get; set; }
    [DataType(DataType.Date)]
    public DateTime? NgaySinh { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual LoaiThe? IdloaiTheNavigation { get; set; }
}
