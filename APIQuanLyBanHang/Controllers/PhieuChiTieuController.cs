using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class PhieuChiTieuController : ControllerBase
    {
        private readonly IPhieuChiTieuRepository context;
        public PhieuChiTieuController(IPhieuChiTieuRepository phieuChiTieuRepo)
        {
            this.context = phieuChiTieuRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhieuChiTieuEntities>>>DanhSach()
        {
            return await this.context.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuChiTieuEntities>>TimTheoID(Guid id)
        {
            return await this.context.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<PhieuChiTieuEntities>>>TimTheoTen(string name)
        {
            return await this.context.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(PhieuChiTieuEntities ct)
        {
            return await this.context.ThemThongTin(ct);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id,PhieuChiTieuEntities ct)
        {
            return await this.context.CapNhatThongTin(id, ct);
        }
        [HttpDelete]    
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id )
        {
            return await this.context.XoaThongTin(id);
        }
    }
}
