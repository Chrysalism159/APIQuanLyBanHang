using APIQuanLyBanHang.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IPhieuChiTieuRepo
    {
        public Task<ActionResult<List<PhieuChiTieuEntities>>> DanhSach();
        public Task<ActionResult<PhieuChiTieuEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<PhieuChiTieuEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(PhieuChiTieuEntities ct);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuChiTieuEntities ct);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
}
