using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository _context;

        public HoaDonController(IHoaDonRepository _context)
        {
            this._context = _context;
        }
        [HttpGet]
        //[Authorize(Roles = "NhanVien")]
        public async Task<ActionResult<List<HoaDonEntities>>> DanhSach()
        {
            return await _context.DanhSach();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "QuanLy")]
        public async Task<ActionResult<HoaDonEntities>> TimTheoID(Guid id)
        {
            return await _context.TimTheoIDKhachHang(id);
        }
        [HttpGet("{idnv}")]
        public async Task<ActionResult<HoaDonEntities>> TimTheoIDNhanVien(Guid idnv)
        {
            return await _context.TimTheoIDNhanVien(idnv);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh)
        {
            return await _context.ThemThongTin(kh);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh)
        {
            return await _context.CapNhatThongTin(id, kh);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            return await _context.XoaThongTin(id);
        }
    }
}
