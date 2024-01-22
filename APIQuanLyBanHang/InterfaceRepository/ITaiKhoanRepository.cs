using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITaiKhoanRepository
    {
        public Task<ActionResult<List<TaiKhoanEntities>>> DanhSach();
        public Task<ActionResult<TaiKhoanEntities>> TimTheoID(Guid id);
        public Task<ActionResult<TaiKhoanEntities>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>>ThemThongTin(TaiKhoanEntities tk);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id,TaiKhoanEntities tk);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);

    }
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly IMapper mapper;
        private readonly QlbdaTtsContext context;
        public TaiKhoanRepository(IMapper mapper, QlbdaTtsContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ActionResult<List<TaiKhoanEntities>>> DanhSach()
        {

            try
            {
                List<TaiKhoan> lst = await context.TaiKhoans.ToListAsync();
                if (lst != null)
                {
                    return this.mapper.Map<List<TaiKhoan>, List<TaiKhoanEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<TaiKhoanEntities>() { };
        }


        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TaiKhoanEntities tk)
        {
            try
            {
                var tim = await context.TaiKhoans.FirstOrDefaultAsync(h => h.IdtaiKhoan.Equals(id.ToString()));
                using (var dbtk = await this.context.Database.BeginTransactionAsync())
                {
                    if (tim != null)
                    {
                        tim.PhanQuyen = tk.PhanQuyen;
                        tim.GhiChu = tk.GhiChu;
                        tim.MatKhau = tk.MatKhau;
                        tim.TenNguoiDung = tk.TenNguoiDung;
                        await context.SaveChangesAsync();
                        await dbtk.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Cap Nhat Thanh Cong"
                        };
                    }
                }
            }
            catch
            {

            }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai"
            };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(TaiKhoanEntities tk)
        {
            tk.IdtaiKhoan = Guid.NewGuid();
            try
            {
                using (var dbtk = await this.context.Database.BeginTransactionAsync())
                {
                    if (tk != null)
                    {
                        TaiKhoan taiKhoan = new TaiKhoan()
                        {
                            IdtaiKhoan = tk.IdtaiKhoan.ToString(),
                            TenNguoiDung = tk.TenNguoiDung,
                            MatKhau = tk.MatKhau,
                            PhanQuyen = tk.PhanQuyen,
                            GhiChu = tk.GhiChu
                        };
                        await context.TaiKhoans.AddAsync(taiKhoan);
                        await context.SaveChangesAsync();
                        await dbtk.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Them Thanh Cong"
                        };
                    }
                }
            }
            catch
            {

            }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Them That Bai"
            };
        }

        public async Task<ActionResult<TaiKhoanEntities>> TimTheoID(Guid id)
        {
            try
            {
                var tk = await context.TaiKhoans.FindAsync(id.ToString());
                if (tk != null)
                {
                    return this.mapper.Map<TaiKhoanEntities>(tk);
                }
            }
            catch { }
            return new TaiKhoanEntities();
        }
        public async Task<ActionResult<TaiKhoanEntities>> TimTheoTen(string name)
        {
            try
            {
                TaiKhoan lst = await context.TaiKhoans.FirstOrDefaultAsync(h => h.TenNguoiDung.Equals(name));
                if (lst != null)
                {
                    return this.mapper.Map<TaiKhoan, TaiKhoanEntities>(lst);
                }
            }
            catch { }
            return new TaiKhoanEntities();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                var taikhoan = await context.TaiKhoans.FirstOrDefaultAsync(h => h.IdtaiKhoan.Equals(id.ToString()));
                using (var dbtk = await this.context.Database.BeginTransactionAsync())
                {
                    if (taikhoan != null)
                    {
                        context.Remove(taikhoan);
                        await context.SaveChangesAsync();
                        await dbtk.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Xoa Thanh Cong"
                        };
                    }
                }

            }
            catch { }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Xoa That Bai"
            };
        }

        internal string GetUserRole(string? username)
        {
            throw new NotImplementedException();
        }
    }
}
