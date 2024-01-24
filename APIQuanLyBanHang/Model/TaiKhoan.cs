using System;
using System.Collections.Generic;

namespace APIQuanLyBanHang.Model;

public partial class TaiKhoan
{
    public string IdtaiKhoan { get; set; } = null!;

    public string? TenNguoiDung { get; set; }

    public string? MatKhau { get; set; }

    public string? PhanQuyen { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
