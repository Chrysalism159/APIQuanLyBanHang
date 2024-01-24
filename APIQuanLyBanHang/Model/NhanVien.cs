using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class NhanVien
{
    public string IdnhanVien { get; set; } = null!;

    public string? IdchiNhanh { get; set; }

    public string? IdtaiKhoan { get; set; }

    public string? TenNhanVien { get; set; }

    public string? Sdt { get; set; }

    public DateTime? NgayBatDauLamViec { get; set; }

    public string? Cccd { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual TaiKhoan? IdtaiKhoanNavigation { get; set; }

    public virtual ICollection<PhieuChiTieu> PhieuChiTieus { get; set; } = new List<PhieuChiTieu>();

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();
}
