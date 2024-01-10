using APIQuanLyBanHang.Data;
using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIQuanLyBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepo _repo;

        public TaiKhoanController(ITaiKhoanRepo repo) 
        {   
            this._repo = repo;
        
        }
        [HttpPost("Sign in")]
        public async Task<IActionResult> SignInAsync(Account signin)
        {
            var result = await _repo.SignInAsync(signin);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost("Sign up")]
        public async Task<IActionResult> SignUpAsync(Account signup)
        {
            var result = await _repo.SignUpAsync(signup);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
    }
}
