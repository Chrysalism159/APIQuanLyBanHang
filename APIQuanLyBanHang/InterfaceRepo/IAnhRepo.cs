using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IAnhRepo
    {
        public Task<ActionResult<List<AnhEntities>>> DanhSach();
        public Task<ActionResult<AnhEntities>> TimTheoID(Guid id);
        public Task<ActionResult<TrangThai>> ThemThongTin(AnhEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, AnhEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
