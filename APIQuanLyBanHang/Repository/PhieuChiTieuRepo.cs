using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.Repository
{
    public class PhieuChiTieuRepo : IPhieuChiTieuRepo
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public PhieuChiTieuRepo(QlbdaTtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuChiTieuEntities ct)
        {
            try
            {
                using(var dbct=await this.context.Database.BeginTransactionAsync())
                {
                    var pct = await this.context.PhieuChiTieus.FirstOrDefaultAsync(h => h.IdphieuChi.Equals(id.ToString()));
                    if (pct != null)
                    {
                        pct.IdnhanVien = ct.IdnhanVien.ToString();
                        pct.IdchiNhanh = ct.IdchiNhanh.ToString();
                        pct.TenPhieuChi = ct.TenPhieuChi;
                        pct.SoTienChi = ct.SoTienChi;
                        pct.ThoiGianLapPhieu = ct.ThoiGianLapPhieu;
                        pct.GhiChu = ct.GhiChu;
                        await this.context.SaveChangesAsync();
                       await  dbct.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Cap Nhat Thanh Cong"
                        };
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai"
            };
        }

        public async Task<ActionResult<List<PhieuChiTieuEntities>>> DanhSach()
        {
            try
            {
                List<PhieuChiTieu>lst=await this.context.PhieuChiTieus.ToListAsync();
                if(lst.Count>0&&lst!=null)
                {
                    return  this.mapper.Map<List<PhieuChiTieu>,List<PhieuChiTieuEntities>>(lst);
                }    
            }
            catch
            {

            }
            return new List<PhieuChiTieuEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(PhieuChiTieuEntities ct)
        {
            ct.IdphieuChi = Guid.NewGuid();
            try
            {
                using (var dbct = await this.context.Database.BeginTransactionAsync())
                {

                    PhieuChiTieu phieuChi = new PhieuChiTieu()
                    {
                        IdphieuChi = ct.IdphieuChi.ToString(),
                        IdnhanVien = ct.IdnhanVien.ToString(),
                        IdchiNhanh = ct.IdchiNhanh.ToString(),
                        TenPhieuChi = ct.TenPhieuChi,
                        SoTienChi = ct.SoTienChi,
                        ThoiGianLapPhieu = ct.ThoiGianLapPhieu,
                        GhiChu = ct.GhiChu
                    };
                    await this.context.PhieuChiTieus.AddAsync(phieuChi);
                    await this.context.SaveChangesAsync();
                    await dbct.CommitAsync();
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

        public async Task<ActionResult<PhieuChiTieuEntities>> TimTheoID(Guid id)
        {
            try
            {
                var phieu = await this.context.PhieuChiTieus.FindAsync(id.ToString());
                if(phieu!=null)
                {
                    return this.mapper.Map<PhieuChiTieu, PhieuChiTieuEntities>(phieu);
                }    
            }
            catch
            {

            }
            return new PhieuChiTieuEntities() { };
        }

        public async Task<ActionResult<List<PhieuChiTieuEntities>>> TimTheoTen(string name)
        {
            try
            {
                List<PhieuChiTieu> lst=await this.context.PhieuChiTieus.Where(h=>h.TenPhieuChi.Contains(name)).ToListAsync();
                if(lst!=null&&lst.Count>0)
                {
                    return this.mapper.Map<List<PhieuChiTieu>,List<PhieuChiTieuEntities>>(lst);   
                }    

            }
            catch
            {

            }
            return new List<PhieuChiTieuEntities>();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                var phieu = await this.context.PhieuChiTieus.FirstOrDefaultAsync(h => h.IdphieuChi == (id.ToString()));
                using (var dbphieu = await this.context.Database.BeginTransactionAsync())
                {
                    if (phieu != null)
                    {
                        context.PhieuChiTieus.Remove(phieu);
                        await this.context.SaveChangesAsync();
                        await dbphieu.CommitAsync();
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
                ThongBao = "Xoa That Bai "
            };
        }
    }
}
