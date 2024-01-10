using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Repository
{
    public class HoaDonRepo : IHoaDonRepo
    {
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<HoaDonEntities>>> DanhSach()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<HoaDonEntities>> TimTheoID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<HoaDonEntities>>> TimTheoTen(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
