using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface INhanVienRepo
    {
        public Task<ActionResult<List<NhanVienEntities>>> DanhSach();
        public Task<ActionResult<NhanVienEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<NhanVienEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(NhanVienEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhanVienEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
