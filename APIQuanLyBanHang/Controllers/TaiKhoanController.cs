using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Helper;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepositories account;

        public TaiKhoanController(ITaiKhoanRepositories acc)
        {
            this.account = acc;
        }

        [HttpPost("DangNhap")]
        public async Task<TrangThai> DangNhap(QuanLyTaiKhoanDangNhap model)
        {
            TrangThai result = await account.SignInAsync(model);
            return result;
        }
        [HttpPost("DangXuat")]
        public async Task<TrangThai> DangXuat(QuanLyTaiKhoanDangNhap tt)
        {
            return await account.SignOutAsync(tt);
        }
        [HttpPost("DangKi")]
        public async Task<IActionResult> DangKi(QuanLyThongTinTaiKhoan model)
        {
            var result = await account.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
            
        }
    }
}
