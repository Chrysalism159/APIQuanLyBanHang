using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IHoaDonRepo
    {
        public Task<ActionResult<List<HoaDonEntities>>> DanhSach();
        public Task<ActionResult<HoaDonEntities>> TimTheoIDKhachHang(Guid id);
        public Task<ActionResult<HoaDonEntities>> TimTheoIDNhanVien(Guid id);
        public Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
