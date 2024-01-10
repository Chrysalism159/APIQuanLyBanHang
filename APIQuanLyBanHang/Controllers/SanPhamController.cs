using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepo _repo;

        public SanPhamController(ISanPhamRepo repo) 
        {
            this._repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<SanPhamEntities>>> DanhSach()
        {
            return await _repo.DanhSach();
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh)
        {
            return await _repo.ThemThongTin(kh);
        }
    }
}
