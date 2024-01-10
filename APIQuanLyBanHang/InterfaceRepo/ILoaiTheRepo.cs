using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ILoaiTheRepo
    {
        public Task<ActionResult<List<LoaiTheEntities>>> DanhSach();
        public Task<ActionResult<LoaiTheEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<LoaiTheEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(LoaiTheEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, LoaiTheEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
