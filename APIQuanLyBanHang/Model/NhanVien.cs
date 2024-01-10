using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIQuanLyBanHang.Model;

public partial class NhanVien
{
    [Key, Column(Order =0)]
    public string IdnhanVien { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string? IdchiNhanh { get; set; }
    [Key, Column(Order = 2)]
    public string? IdtaiKhoan { get; set; }

    public string? TenNhanVien { get; set; }

    public string? Sdt { get; set; }

    [DataType(DataType.Date)]
    public DateTime? NgayBatDauLamViec { get; set; }

    public string? Cccd { get; set; }
    [DataType(DataType.Date)]
    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Email { get; set; }

    public string? ĐiaChi { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual TaiKhoan? IdtaiKhoanNavigation { get; set; }

    public virtual ICollection<PhieuChiTieu> PhieuChiTieus { get; set; } = new List<PhieuChiTieu>();

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();
}
