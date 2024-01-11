using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITheKhachHangRepo
    {
        public Task<ActionResult<List<TheThanhVienEntities>>> DanhSach();
        public Task<ActionResult<TheThanhVienEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<TheThanhVienEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(TheThanhVienEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheThanhVienEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
