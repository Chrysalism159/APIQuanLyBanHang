using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ISanPhamChiNhanhRepo
    {
        public Task<ActionResult<List<SanPhamChiNhanhEntities>>> DanhSach();
        public Task<ActionResult<SanPhamChiNhanhEntities>> TimTheoID(Guid idsp, Guid idcn);
        public Task<ActionResult<TrangThai>> ThemThongTin(SanPhamChiNhanhEntities spcn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid idsp,Guid idcn, SanPhamChiNhanhEntities spcn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid idsp, Guid idcn);
    }
}
