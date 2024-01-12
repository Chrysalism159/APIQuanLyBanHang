using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class LoaiTheController : ControllerBase
    {
        private readonly ILoaiTheRepo _context;

        public LoaiTheController(ILoaiTheRepo _context) 
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<ActionResult<List<LoaiTheEntities>>> DanhSach()
        {
            return await _context.DanhSach();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "QuanLy")]
        public async Task<ActionResult<LoaiTheEntities>> TimTheoID(Guid id)
        {
            return await _context.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<LoaiTheEntities>>> TimTheoTen(string name)
        {
            return await _context.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(LoaiTheEntities kh)
        {
            return await _context.ThemThongTin(kh);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, LoaiTheEntities kh)
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
