using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepo context;
        public NhanVienController(INhanVienRepo context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<NhanVienEntities>>> DanhSach()
        {
            return await context.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVienEntities>>TimTheoID(Guid id)
        {
            return await context.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<NhanVienEntities>>>TimTheoTen(string name)
        {
            return await context.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(NhanVienEntities nv)
        {
            return await context.ThemThongTin(nv);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id,NhanVienEntities nv)
        {
            return await context.CapNhatThongTin(id, nv);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id)
        {
            return await context.XoaThongTin(id);
        }
    }
}
