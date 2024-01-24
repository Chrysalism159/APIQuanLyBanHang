using APIQuanLyBanHang.Helper;
using APIQuanLyBanHang.InterfaceRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepositories account;

        public TaiKhoanController(ITaiKhoanRepositories acc)
        {
            this.account = acc;
        }

        [HttpPost("SignInAsync")]
        public async Task<IActionResult> SignInAsync(QuanLyTaiKhoanDangNhap model)
        {
            var result = await account.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("SignUpAsync")]
        public async Task<IActionResult> SignUpAsync(QuanLyThongTinTaiKhoan model)
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
