using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapRepo context;
        public NhaCungCapController(INhaCungCapRepo context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<NhaCungCapEntities>>>DanhSach()
        {
            return await context.DanhSach();
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<NhaCungCapEntities>>>TimTheoTen(string name)
        {
            return await context.TimTheoTen(name);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaCungCapEntities>>TimTheoID(Guid id)
        {
            return await context.TimTheoID(id);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(NhaCungCapEntities nc)
        {
            return await context.ThemThongTin(nc);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id, NhaCungCapEntities nc)
        {
            return await context.CapNhatThongTin(id,nc);
        }
        [HttpDelete]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id)
        {
            return await context.XoaThongTin(id);
        }    
    }
}
