using APIQuanLyBanHang.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepository account;

        public TaiKhoanController(ITaiKhoanRepository acc)
        {
            this.account = acc;
        }

        [HttpPost("SignUpAsync")]
        public async Task<IActionResult> SignUpAsync(QuanLyThongTinTaiKhoan signup)
        {
            var result = await account.SignUpAsync(signup);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost("SignInAsync")]
        public async Task<IActionResult> SignInAsync(QuanLyThongTinTaiKhoan signin)
        {
            var result = await account.SignInAsync(signin);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
