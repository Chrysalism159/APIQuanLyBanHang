using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IPhieuNhapHangRepository
    {
        public Task<ActionResult<List<PhieuNhapHangEntities>>> DanhSach();
        public Task<ActionResult<PhieuNhapHangEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<PhieuNhapHangEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(PhieuNhapHangEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuNhapHangEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class PhieuNhapHangRepository : IPhieuNhapHangRepository
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public PhieuNhapHangRepository(QlbdaTtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, PhieuNhapHangEntities kh)
        {
            try
            {
                var pnh = await this.context.PhieuNhapHangs.FirstOrDefaultAsync(h => h.IdphieuNhapHang.Equals(id.ToString()));
                using (var dbnh = await this.context.Database.BeginTransactionAsync())
                {
                    if (pnh != null)
                    {
                        pnh.IdnhanVien = kh.IdnhanVien.ToString();
                        pnh.IdnhaCungCap = kh.IdnhaCungCap.ToString();
                        pnh.IdchiNhanh = kh.IdchiNhanh.ToString();
                        pnh.TenHangNhap = kh.TenHangNhap;
                        pnh.ChietKhau = kh.ChietKhau;
                        pnh.TongTienSauChietKhau = kh.TongTienSauChietKhau;
                        pnh.TongTienThanhToan = kh.TongTienThanhToan;
                        pnh.GhiChu = kh.GhiChu;

                        await context.SaveChangesAsync();
                        await dbnh.CommitAsync();
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

        public async Task<ActionResult<List<PhieuNhapHangEntities>>> DanhSach()
        {
            try
            {
                List<PhieuNhapHang> lst = await this.context.PhieuNhapHangs.ToListAsync();
                if (lst.Count > 0 && lst != null)
                {
                    return this.mapper.Map<List<PhieuNhapHang>, List<PhieuNhapHangEntities>>(lst);
                }

            }
            catch
            {

            }
            return new List<PhieuNhapHangEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(PhieuNhapHangEntities kh)
        {
            kh.IdphieuNhapHang = Guid.NewGuid();
            try
            {

                using (var dbpn = await this.context.Database.BeginTransactionAsync())
                {
                    if (kh != null)
                    {
                        PhieuNhapHang phieuNhapHang = new PhieuNhapHang()
                        {
                            IdphieuNhapHang = kh.IdphieuNhapHang.ToString(),
                            IdnhanVien = kh.IdnhanVien.ToString(),
                            IdnhaCungCap = kh.IdnhaCungCap.ToString(),
                            IdchiNhanh = kh.IdchiNhanh.ToString(),
                            TenHangNhap = kh.TenHangNhap,
                            ChietKhau = kh.ChietKhau,
                            TongTienSauChietKhau = kh.TongTienSauChietKhau,
                            TongTienThanhToan = kh.TongTienThanhToan,
                            GhiChu = kh.GhiChu
                        };
                        await context.AddAsync(phieuNhapHang);
                        await context.SaveChangesAsync();
                        await dbpn.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Them Thanh Cong"
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
                ThongBao = "Them That Bai"
            };
        }

        public async Task<ActionResult<PhieuNhapHangEntities>> TimTheoID(Guid id)
        {
            try
            {
                var ph = await context.PhieuNhapHangs.FindAsync(id.ToString());
                if (ph != null)
                {
                    return this.mapper.Map<PhieuNhapHang, PhieuNhapHangEntities>(ph);
                }
            }
            catch
            {

            }
            return new PhieuNhapHangEntities() { };
        }

        public async Task<ActionResult<List<PhieuNhapHangEntities>>> TimTheoTen(string name)
        {
            try
            {
                List<PhieuNhapHang> lst = await context.PhieuNhapHangs.Where(h => h.TenHangNhap.Contains(name)).ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<PhieuNhapHang>, List<PhieuNhapHangEntities>>(lst);
                }

            }
            catch
            {

            }
            return new List<PhieuNhapHangEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {

                using (var dbph = await this.context.Database.BeginTransactionAsync())
                {
                    var Ph = await context.PhieuNhapHangs.FirstOrDefaultAsync(h => h.IdphieuNhapHang.Equals(id.ToString()));
                    if (Ph != null)
                    {
                        context.PhieuNhapHangs.Remove(Ph);
                        await context.SaveChangesAsync();
                        dbph.CommitAsync();
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
