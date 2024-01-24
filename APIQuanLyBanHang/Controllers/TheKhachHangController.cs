using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIQuanLyBanHang.Model;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Entity;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TheKhachHangController : ControllerBase
    {
        private readonly ITheKhachHangRepository _context;

        public TheKhachHangController(ITheKhachHangRepository context)
        {
            _context = context;
        }

        // GET: api/TheKhachHang
        [HttpGet]
        public async Task<ActionResult<List<TheThanhVienEntities>>> DanhSach()
        {
             return await _context.DanhSach();
        }

        // GET: api/TheKhachHang/5\
        [HttpGet( "{id}")]
        public async Task<ActionResult<TheThanhVienEntities>> TimTheoID(Guid id)
        {
            return await _context.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<TheThanhVienEntities>>> TimTheoTen(string name)
        {
            return await _context.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(TheThanhVienEntities kh)
        {
            return await _context.ThemThongTin(kh);
        }
        [HttpGet("{name}/{ sdt}")]
        public async Task<ActionResult<TheThanhVienEntities>> LayMaKhachHang(string name, string sdt)
        {
            return await _context.LayMaKhachHang(name, sdt);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheThanhVienEntities kh)
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
