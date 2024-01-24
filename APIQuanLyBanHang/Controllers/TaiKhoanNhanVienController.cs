using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TaiKhoanNhanVienController : ControllerBase
    {
        private readonly ITaiKhoanRepository repository;

        public TaiKhoanNhanVienController(ITaiKhoanRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaiKhoanEntities>>> DanhSach()
        {
            return await this.repository.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoanEntities>> TimTheoID(Guid id)
        {
            return await repository.TimTheoID(id);
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<TaiKhoanEntities>> TimTheoTen(string name)
        {
            return await this.repository.TimTheoTen(name);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(TaiKhoanEntities tk)
        {
            return await this.repository.ThemThongTin(tk);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TaiKhoanEntities tk)
        {
            return await this.repository.CapNhatThongTin(id, tk);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            return await this.repository.XoaThongTin(id);
        }
    }
}
