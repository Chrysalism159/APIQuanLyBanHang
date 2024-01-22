using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ISanPhamChiNhanhRepository
    {
        public Task<ActionResult<List<SanPhamChiNhanhEntities>>> DanhSach();
        public Task<ActionResult<SanPhamChiNhanhEntities>> TimTheoID(Guid idsp, Guid idcn);
        public Task<ActionResult<TrangThai>> ThemThongTin(SanPhamChiNhanhEntities spcn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid idsp,Guid idcn, SanPhamChiNhanhEntities spcn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid idsp, Guid idcn);
    }
    public class SanPhamChiNhanhRepository : ISanPhamChiNhanhRepository
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public SanPhamChiNhanhRepository(QlbdaTtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid idsp, Guid idcn, SanPhamChiNhanhEntities spcn)
        {
            try
            {
                using (var dbcn = await this.context.Database.BeginTransactionAsync())
                {
                    var sp = await this.context.SanPhamChiNhanhs.FirstOrDefaultAsync(h => (h.IdsanPham.Equals(idsp.ToString()) && h.IdchiNhanh.Equals(idcn.ToString())));
                    if (sp != null)
                    {
                        sp.GhiChu = spcn.GhiChu;
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
            catch
            {

            }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai "
            };
        }

        public async Task<ActionResult<List<SanPhamChiNhanhEntities>>> DanhSach()
        {
            try
            {
                List<SanPhamChiNhanh> lst = await this.context.SanPhamChiNhanhs.ToListAsync();
                if (lst.Count > 0 && lst != null)
                {
                    return this.mapper.Map<List<SanPhamChiNhanh>, List<SanPhamChiNhanhEntities>>(lst);
                }
            }
            catch (Exception ex) { }
            return new List<SanPhamChiNhanhEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(SanPhamChiNhanhEntities spcn)
        {
            try
            {

                using (var dbsp = await this.context.Database.BeginTransactionAsync())
                {
                    if (spcn != null)
                    {
                        SanPhamChiNhanh sp = new SanPhamChiNhanh()
                        {
                            IdchiNhanh = spcn.IdchiNhanh.ToString(),
                            IdsanPham = spcn.IdsanPham.ToString(),
                            GhiChu = spcn.GhiChu
                        };
                        await this.context.AddAsync(sp);
                        await this.context.SaveChangesAsync();
                        await dbsp.CommitAsync();
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

        public async Task<ActionResult<SanPhamChiNhanhEntities>> TimTheoID(Guid idsp, Guid idcn)
        {
            try
            {
                var sp = await this.context.SanPhamChiNhanhs.FirstOrDefaultAsync(h => (h.IdchiNhanh.Equals(idcn.ToString()) && h.IdsanPham.Equals(idsp.ToString())));
                if (sp != null)
                {
                    return this.mapper.Map<SanPhamChiNhanhEntities>(sp);
                }

            }
            catch
            {

            }
            return new SanPhamChiNhanhEntities();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid idsp, Guid idcn)
        {
            try
            {
                var sp = await this.context.SanPhamChiNhanhs.FindAsync(idcn.ToString(), idsp.ToString());
                using (var dbsp = await this.context.Database.BeginTransactionAsync())
                {

                    if (sp != null)
                    {
                        this.context.SanPhamChiNhanhs.Remove(sp);
                        await context.SaveChangesAsync();
                        await dbsp.CommitAsync();
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
