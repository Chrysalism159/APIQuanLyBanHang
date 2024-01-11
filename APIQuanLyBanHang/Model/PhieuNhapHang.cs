using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class PhieuNhapHang
{
    public string IdphieuNhapHang { get; set; } = null!;

    public string IdnhanVien { get; set; } = null!;

    public string? IdnhaCungCap { get; set; }

    public string? Idanh { get; set; }

    public string? IdchiNhanh { get; set; }

    public string? TenHangNhap { get; set; }

    public decimal? ChietKhau { get; set; }

    public decimal? TongTienSauChietKhau { get; set; }

    public decimal? TongTienThanhToan { get; set; }

    public DateTime? ThoiGianLapHoaDon { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Anh? IdanhNavigation { get; set; }

    public virtual ChiNhanh? IdchiNhanhNavigation { get; set; }

    public virtual NhaCungCap? IdnhaCungCapNavigation { get; set; }

    public virtual NhanVien IdnhanVienNavigation { get; set; } = null!;
}
