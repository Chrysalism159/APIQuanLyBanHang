using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepo _repo;

        public HoaDonController(IHoaDonRepo repo) {
            this._repo = repo;  
        }
        [HttpGet]
        public async Task<ActionResult<List<HoaDonEntities>>> DanhSach()
        {
            return await _repo.DanhSach();
        }
        [HttpGet("{idKhachHang}")]
        public async Task<ActionResult<HoaDonEntities>> TimTheoIDKhachHang(Guid id)
        {
            return await _repo.TimTheoIDKhachHang(id);
        }
        [HttpGet("{idNhanVien}")]
        public async Task<ActionResult<HoaDonEntities>> TimTheoIDNhanVien(Guid id)
        {
            return await _repo.TimTheoIDNhanVien(id);
        }
        [HttpPost]
        public async Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh)
        {
            return await _repo.ThemThongTin(kh);
        }
        [HttpPut]
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh)
        {
            return await _repo.CapNhatThongTin(id, kh);
        }
        [HttpDelete]
        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            return await _repo.XoaThongTin(id);
        }
    }
}
