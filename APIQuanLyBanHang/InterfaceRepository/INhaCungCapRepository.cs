using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface INhaCungCapRepository
    {
        public Task<ActionResult<List<NhaCungCapEntities>>> DanhSach();
        public Task<ActionResult<NhaCungCapEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<NhaCungCapEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(NhaCungCapEntities cn);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhaCungCapEntities cn);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class NhaCungCapRepository : INhaCungCapRepository

    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public NhaCungCapRepository(QlbdaTtsContext qlbdaTtsContext, IMapper mapper)
        {
            this.context = qlbdaTtsContext;
            this.mapper = mapper;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhaCungCapEntities cn)
        {
            try
            {
                var ncc = await this.context.NhaCungCaps.FindAsync(id.ToString());
                using (var dbncc = await this.context.Database.BeginTransactionAsync())
                {
                    if (dbncc != null)
                    {
                        ncc.SoTienNhapHang = cn.SoTienNhapHang;
                        ncc.SoTienDaThanhToan = cn.SoTienDaThanhToan;
                        ncc.TenNhaCungCap = cn.TenNhaCungCap;
                        ncc.TenNguoiDaiDien = cn.TenNguoiDaiDien;
                        ncc.Sdt = cn.Sdt;
                        ncc.DiaChi = cn.DiaChi;
                        ncc.GhiChu = cn.GhiChu;

                        await context.SaveChangesAsync();
                        await dbncc.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Cap Nhat Thanh Cong"
                        };
                    }
                }
            }
            catch { }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai"
            };


        }

        public async Task<ActionResult<List<NhaCungCapEntities>>> DanhSach()
        {
            try
            {
                List<NhaCungCap> lst = await this.context.NhaCungCaps.ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<NhaCungCap>, List<NhaCungCapEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<NhaCungCapEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(NhaCungCapEntities cn)
        {
            try
            {
                using (var dbncc = await this.context.Database.BeginTransactionAsync())
                {
                    NhaCungCap ncc = new NhaCungCap()
                    {
                        IdnhaCungCap = cn.IdnhaCungCap.ToString(),
                        TenNhaCungCap = cn.TenNhaCungCap,
                        TenNguoiDaiDien = cn.TenNguoiDaiDien,
                        Sdt = cn.Sdt,
                        DiaChi = cn.DiaChi,
                        SoTienDaThanhToan = cn.SoTienDaThanhToan,
                        SoTienNhapHang = cn.SoTienNhapHang,
                        GhiChu = cn.GhiChu

                    };
                    await context.NhaCungCaps.AddAsync(ncc);
                    await context.SaveChangesAsync();
                    await dbncc.CommitAsync();
                    return new TrangThai()
                    {
                        MaTrangThai = 1,
                        ThongBao = "Them Thanh Cong"
                    };
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

        public async Task<ActionResult<NhaCungCapEntities>> TimTheoID(Guid id)
        {
            try
            {
                var ncc = await this.context.NhaCungCaps.FindAsync(id.ToString());
                if (ncc != null)
                {
                    return this.mapper.Map<NhaCungCap, NhaCungCapEntities>(ncc);
                }
            }
            catch
            {

            }
            return new NhaCungCapEntities() { };
        }

        public async Task<ActionResult<List<NhaCungCapEntities>>> TimTheoTen(string name)
        {
            try
            {
                List<NhaCungCap> lst = await this.context.NhaCungCaps.Where(h => h.TenNhaCungCap.Equals(name)).ToListAsync();
                if (lst.Count > 0 && lst != null)
                {
                    return this.mapper.Map<List<NhaCungCap>, List<NhaCungCapEntities>>(lst);
                }


            }
            catch
            {

            }
            return new List<NhaCungCapEntities>() { };

        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                using (var dbncc = await this.context.Database.BeginTransactionAsync())
                {
                    var ncc = await this.context.NhaCungCaps.FirstOrDefaultAsync(h => h.IdnhaCungCap.Equals(id.ToString()));
                    if (ncc != null)
                    {
                        context.Remove(ncc);
                        await this.context.SaveChangesAsync();
                        await dbncc.CommitAsync();
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
                MaTrangThai = 1,
                ThongBao = "Xoa That Bai"
            };

        }
    }
}
