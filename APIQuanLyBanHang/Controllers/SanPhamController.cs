using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepository _repo;

        public SanPhamController(ISanPhamRepository repo) 
        {
            this._repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<SanPhamEntities>>> DanhSach()
        {
            return await _repo.DanhSach();
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<List<SanPhamEntities>>> TimTheoTen(string name)
        {
            return await _repo.TimTheoTen(name);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamEntities>> TimTheoID(Guid id)
        {
            return await _repo.TimTheoID(id);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh)
        {
            return await _repo.ThemThongTin(kh);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>>CapNhatThongTin(Guid id,SanPhamEntities kh)

        {
            return await _repo.CapNhatThongTin(id,kh);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>>XoaThongTin(Guid id)
        {
            return await _repo.XoaThongTin(id);
        }
    }
}
