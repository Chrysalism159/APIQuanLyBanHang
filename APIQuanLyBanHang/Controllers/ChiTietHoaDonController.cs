using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly IChiTietHoaDonRepository context;
        public ChiTietHoaDonController(IChiTietHoaDonRepository context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ChiTietHoaDonEntities>>>DanhSach()
        {
            return await this.context.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietHoaDonEntities>>TimTheoID(Guid id)
        {
           return await context.TimTheoID(id);
        }

        [HttpGet("{idsp}")]
        public async Task<ActionResult<List<ChiTietHoaDonEntities>>>TimTheoIDSanPham(Guid idsp)
        {
            return await context.TimTheoIDSanPham(idsp);
        }
        [HttpGet("{idhd}")]
        public async Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDHoaDon(Guid idhd)
        {
            return await context.TimTheoIDHoaDon(idhd);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(ChiTietHoaDonEntities cthd)
        {
            return await context.ThemThongTin(cthd);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id,ChiTietHoaDonEntities ctdh)
        {
            return await context.CapNhatThongTin(id, ctdh);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id)
        {
            return await context.XoaThongTin(id);
        }

    }
}
