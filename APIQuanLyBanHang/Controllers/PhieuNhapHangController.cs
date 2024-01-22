using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class PhieuNhapHangController : ControllerBase
    {
        private readonly IPhieuNhapHangRepository context;
        public PhieuNhapHangController(IPhieuNhapHangRepository context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhieuNhapHangEntities>>>DanhSach()
        {
            return await this.context.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuNhapHangEntities>>TimTheoID(Guid id)
        {
            return await this.context.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<PhieuNhapHangEntities>>> TimTheoTen(string name)
        {
            return await this.context.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(PhieuNhapHangEntities kh)
        {
            return await this.context.ThemThongTin(kh);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id ,PhieuNhapHangEntities kh)
        {
            return await this.context.CapNhatThongTin(id,kh);
        }
        [HttpDelete]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id )
        {
            return await this.context.XoaThongTin(id);
        }

    }
}
