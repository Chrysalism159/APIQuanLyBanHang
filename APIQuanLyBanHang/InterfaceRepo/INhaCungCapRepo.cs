using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface INhaCungCapRepo
    {
        public Task<ActionResult<List<NhaCungCapEntities>>> DanhSach();
        public Task<ActionResult<NhaCungCapEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<NhaCungCapEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(NhaCungCapEntities cn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhaCungCapEntities cn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
