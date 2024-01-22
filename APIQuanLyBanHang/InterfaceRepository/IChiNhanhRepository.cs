using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IChiNhanhRepository
    {
        public Task<ActionResult<List<ChiNhanhEntities>>> DanhSach();
        public Task<ActionResult<ChiNhanhEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<ChiNhanhEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(ChiNhanhEntities cn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id,ChiNhanhEntities cn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class ChiNhanhRepository : IChiNhanhRepository
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public ChiNhanhRepository(QlbdaTtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, ChiNhanhEntities cn)
        {
            try
            {
                using (var dbcn = await this.context.Database.BeginTransactionAsync())
                {
                    var chinhanhcu = await context.ChiNhanhs.FindAsync(id.ToString());
                    if (chinhanhcu != null)
                    {
                        chinhanhcu.SoDienThoai = cn.SoDienThoai;
                        chinhanhcu.TenChiNhanh = cn.TenChiNhanh;
                        chinhanhcu.DiaChi = cn.DiaChi;
                        chinhanhcu.GhiChu = cn.GhiChu;

                        await context.SaveChangesAsync();
                        await dbcn.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Cap Nhat Thanh Cong"
                        };
                    }
                }
            }
            catch (Exception ex) { }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai "
            };
        }

        public async Task<ActionResult<List<ChiNhanhEntities>>> DanhSach()
        {
            try
            {
                List<ChiNhanh> lst = await context.ChiNhanhs.ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<ChiNhanh>, List<ChiNhanhEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<ChiNhanhEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(ChiNhanhEntities cn)
        {
            cn.IdchiNhanh = Guid.NewGuid();
            try
            {
                using (var dbcn = await this.context.Database.BeginTransactionAsync())
                {
                    if (cn != null)
                    {
                        ChiNhanh chiNhanh = new ChiNhanh
                        {
                            IdchiNhanh = cn.IdchiNhanh.ToString(),
                            TenChiNhanh = cn.TenChiNhanh,
                            DiaChi = cn.DiaChi,
                            GhiChu = cn.GhiChu,
                            SoDienThoai = cn.SoDienThoai
                        };
                        await context.ChiNhanhs.AddAsync(chiNhanh);
                        await context.SaveChangesAsync();
                        await dbcn.CommitAsync();
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

        public async Task<ActionResult<ChiNhanhEntities>> TimTheoID(Guid id)
        {
            try
            {
                ChiNhanh chiNhanh = await context.ChiNhanhs.FirstOrDefaultAsync(h => h.IdchiNhanh.Equals(id.ToString()));
                if (chiNhanh != null)
                {
                    return this.mapper.Map<ChiNhanh, ChiNhanhEntities>(chiNhanh);
                }
            }
            catch { }
            return new ChiNhanhEntities() { };
        }

        public async Task<ActionResult<List<ChiNhanhEntities>>> TimTheoTen(string ten)
        {
            try
            {
                List<ChiNhanh> lst = await context.ChiNhanhs.Where(h => h.TenChiNhanh.Contains(ten)).ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<ChiNhanh>, List<ChiNhanhEntities>>(lst);
                }

            }
            catch
            { }
            return new List<ChiNhanhEntities>() { };

        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                using (var dbcn = await this.context.Database.BeginTransactionAsync())
                {
                    var ChiNhanh = await context.ChiNhanhs.FirstOrDefaultAsync(h => h.IdchiNhanh.Equals(id.ToString()));
                    if (ChiNhanh != null)
                    {
                        context.Remove(ChiNhanh);
                        await context.SaveChangesAsync();
                        await dbcn.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Xoa Thanh Cong"
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
                ThongBao = "Xoa That Bai"
            };
        }
    }
}
