using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IChiTietHoaDonRepo
    {
        public Task<ActionResult<List<ChiTietHoaDonEntities>>> DanhSach();
        public Task<ActionResult<ChiTietHoaDonEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDSanPham(Guid idsp);
        public Task<ActionResult<TrangThai>> ThemThongTin(ChiTietHoaDonEntities cthd);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, ChiTietHoaDonEntities cthd);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
