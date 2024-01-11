using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITaiKhoanRepo
    {
        public Task<ActionResult<List<TaiKhoanEntities>>> DanhSach();
        public Task<ActionResult<TaiKhoanEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<TaiKhoanEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>>ThemThongTin(TaiKhoanEntities tk);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id,TaiKhoanEntities tk);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);

    }
}
