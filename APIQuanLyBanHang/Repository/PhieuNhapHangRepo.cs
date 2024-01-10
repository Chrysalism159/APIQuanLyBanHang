using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Repository
{
    public class PhieuNhapHangRepo : IPhieuNhapHangRepo
    {
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuNhapHangEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<PhieuNhapHangEntities>>> DanhSach()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> ThemThongTin(PhieuNhapHangEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<PhieuNhapHangEntities>> TimTheoID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<PhieuNhapHangEntities>>> TimTheoTen(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
