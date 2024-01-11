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
    public class ChiNhanhController : ControllerBase
    {
        private readonly IChiNhanhRepo context;

        public ChiNhanhController(IChiNhanhRepo context)
        {
            this.context = context;
        }

        // GET: api/ChiNhanh
        [HttpGet]
        public async Task<ActionResult<List<ChiNhanhEntities>>> DanhSach()
        {
          return await context.DanhSach();
        }

        // GET: api/ChiNhanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiNhanhEntities>> TimTheoID(Guid id)
        {
            return await context.TimTheoID(id);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<ChiNhanhEntities>>> TimTheoTen(string name)
        {
            return await context.TimTheoTen(name);
        }

        // PUT: api/ChiNhanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, ChiNhanhEntities chiNhanh)
        {

            return await context.CapNhatThongTin(id, chiNhanh);
        }

        // POST: api/ChiNhanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(ChiNhanhEntities chiNhanh)
        {
            return await context.ThemThongTin(chiNhanh);
        }

        // DELETE: api/ChiNhanh/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            return await context.XoaThongTin(id);
        }
    }
}
