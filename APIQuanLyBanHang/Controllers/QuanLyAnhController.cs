using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyAnhController : ControllerBase
    {
        private readonly IAnhRepo _repo;

        public QuanLyAnhController(IAnhRepo repo) 
        {
            this._repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<AnhEntities>>> DanhSach()
        {
            return await _repo.DanhSach();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AnhEntities>> TimTheoID(Guid id)
        {
            return await _repo.TimTheoID(id);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin([FromForm]AnhEntities kh)
        {
            return await _repo.ThemThongTin(kh);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, AnhEntities kh)
        {
            return await _repo.CapNhatThongTin(id, kh);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            return await _repo.XoaThongTin(id);
        }
    }
}
