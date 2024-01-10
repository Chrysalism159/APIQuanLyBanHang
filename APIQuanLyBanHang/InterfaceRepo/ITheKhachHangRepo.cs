using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITheKhachHangRepo
    {
        public Task<ActionResult<List<TheKhachHangEntities>>> DanhSach();
        public Task<ActionResult<TheKhachHangEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<TheKhachHangEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(TheKhachHangEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id,TheKhachHangEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
