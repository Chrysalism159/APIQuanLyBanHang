using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IChiNhanhRepo
    {
        public Task<ActionResult<List<ChiNhanhEntities>>> DanhSach();
        public Task<ActionResult<ChiNhanhEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<ChiNhanhEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(ChiNhanhEntities cn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id,ChiNhanhEntities cn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
