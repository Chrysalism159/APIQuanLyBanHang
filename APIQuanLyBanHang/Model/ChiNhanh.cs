using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class ChiNhanh
{
    public string IdchiNhanh { get; set; } = null!;

    public string? TenChiNhanh { get; set; }

    public string? ĐiaChi { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<PhieuChiTieu> PhieuChiTieus { get; set; } = new List<PhieuChiTieu>();

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();
}
