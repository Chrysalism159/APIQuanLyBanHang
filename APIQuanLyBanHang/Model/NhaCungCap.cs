using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class NhaCungCap
{
    public string IdnhaCungCap { get; set; } = null!;

    public string? TenNhaCungCap { get; set; }

    public string? TenNguoiDaiDien { get; set; }

    public string? Sdt { get; set; }

    public int? DiaChi { get; set; }

    public decimal? SoTienNhapHang { get; set; }

    public decimal? SoTienDaThanhToan { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();
}
