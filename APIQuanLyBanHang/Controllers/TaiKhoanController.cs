using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepo repository;
        public TaiKhoanController (ITaiKhoanRepo repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaiKhoanEntities>>> DanhSach()
        {
            return await repository.DanhSach();
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>>ThemThongTin(TaiKhoanEntities tk)
        {
            return await repository.ThemThongTin(tk);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoanEntities>>TimTheoID(Guid id)
        {
            return await repository.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<TaiKhoanEntities>>>TimTheoTen(string name)
        {
            return await repository.TimTheoTen(name);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>>SuaThongTin(Guid id,TaiKhoanEntities tk)
        {
            return await repository.CapNhatThongTin(id, tk);
        }
        [HttpDelete]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id)
        {
            return await repository.XoaThongTin(id);
        }
    }
}
