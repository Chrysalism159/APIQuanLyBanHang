using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class SanPhamChiNhanhController : ControllerBase
    {
        private readonly ISanPhamChiNhanhRepo context;
        public SanPhamChiNhanhController(ISanPhamChiNhanhRepo context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SanPhamChiNhanhEntities>>>DanhSach()
        {
            return await this.context.DanhSach();
        }
        [HttpGet("{idsp},{idcn}")]
        public async Task<ActionResult<SanPhamChiNhanhEntities>>TimTheoID(Guid idsp,Guid idcn)
        {
            return await this.context.TimTheoID(idsp, idcn);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(SanPhamChiNhanhEntities spcn)
        {
            return await this.context.ThemThongTin(spcn);
        }
        [HttpDelete]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid idsp,Guid idcn)
        {
            return await this.context.XoaThongTin(idsp, idcn);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid idsp,Guid idcn ,SanPhamChiNhanhEntities spcn)
        {
            return await this.context.CapNhatThongTin(idsp , idcn , spcn);
        }
    }
}
