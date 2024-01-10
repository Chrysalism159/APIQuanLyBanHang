using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIQuanLyBanHang.Model;

public partial class PhieuNhapHang
{
    [Key, Column(Order = 0)]
    public string IdphieuNhapHang { get; set; } = null!;
    [Key, Column(Order = 1)]
    public string IdnhanVien { get; set; } = null!;
    [Key, Column(Order = 2)]
    public string? IdnhaCungCap { get; set; }
    [Key, Column(Order = 3)]
    public string? Idanh { get; set; }
    [Key, Column(Order = 4)]
    public string? IdchiNhanh { get; set; }

    public string? TenHangNhap { get; set; }

    public decimal? ChietKhau { get; set; }

    public decimal? TongTienSauChietKhau { get; set; }

    public decimal? TongTienThanhToan { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ThoiGianLapHoaDon { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Anh? IdanhNavigation { get; set; }

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhaCungCap? IdnhaCungCapNavigation { get; set; }

    public virtual NhanVien IdnhanVienNavigation { get; set; } = null!;
}
