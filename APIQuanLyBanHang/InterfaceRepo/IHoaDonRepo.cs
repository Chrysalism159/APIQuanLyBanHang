using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IHoaDonRepo
    {
        public Task<ActionResult<List<HoaDonEntities>>> DanhSach();
        public Task<ActionResult<HoaDonEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<HoaDonEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
