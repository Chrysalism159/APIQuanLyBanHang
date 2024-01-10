using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IPhieuNhapHangRepo
    {
        public Task<ActionResult<List<PhieuNhapHangEntities>>> DanhSach();
        public Task<ActionResult<PhieuNhapHangEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<PhieuNhapHangEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(PhieuNhapHangEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuNhapHangEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
