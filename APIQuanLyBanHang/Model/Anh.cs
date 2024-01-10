using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIQuanLyBanHang.Model;

public partial class Anh
{
    [Key, Required]
    public string Idanh { get; set; } = null!;
    public string? TenAnh { get; set; }
    

    public string? GhiChu { get; set; }
    [NotMapped]
    public IFormFile? file {  get; set; }
    //[NotMapped]
    public string? FileAnh { get; set; }

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
