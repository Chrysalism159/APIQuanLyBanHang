using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Repository
{
    public class NhanVienRepo : INhanVienRepo
    {
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhanVienEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<NhanVienEntities>>> DanhSach()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> ThemThongTin(NhanVienEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<NhanVienEntities>> TimTheoID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<NhanVienEntities>>> TimTheoTen(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
