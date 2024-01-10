using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ISanPhamRepo
    {
        public Task<ActionResult<List<SanPhamEntities>>> DanhSach();
        public Task<ActionResult<SanPhamEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<SanPhamEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, SanPhamEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
