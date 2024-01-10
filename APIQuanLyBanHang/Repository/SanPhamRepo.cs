using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Repository
{
    public class SanPhamRepo : ISanPhamRepo
    {
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, SanPhamEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<SanPhamEntities>>> DanhSach()
        {
            throw new NotImplementedException();
        }


        public Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<SanPhamEntities>> TimTheoID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<SanPhamEntities>>> TimTheoTen(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
