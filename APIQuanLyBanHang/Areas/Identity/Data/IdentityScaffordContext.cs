using APIQuanLyBanHang.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace APIQuanLyBanHang.Areas.Identity.Data;

public class IdentityScaffordContext : IdentityDbContext<TaiKhoanNguoiDung>
{
    public IdentityScaffordContext(DbContextOptions<IdentityScaffordContext> options)
        : base(options)
    {
    }
    protected IdentityScaffordContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(x => new { x.LoginProvider, x.ProviderKey });
        });
        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(x => new { x.UserId, x.RoleId });
        });
        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        });
    }
}
