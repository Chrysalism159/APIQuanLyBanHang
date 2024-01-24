using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IChiTietHoaDonRepository
    {
        public Task<ActionResult<List<ChiTietHoaDonEntities>>> DanhSach();
        public Task<ActionResult<ChiTietHoaDonEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDSanPham(Guid idsp);
        public Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDHoaDon(Guid idsp);
        public Task<ActionResult<TrangThai>> ThemThongTin(ChiTietHoaDonEntities cthd);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, ChiTietHoaDonEntities cthd);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class ChiTietHoaDonRepository : IChiTietHoaDonRepository
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapper;
        public ChiTietHoaDonRepository(QlbdaTtsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, ChiTietHoaDonEntities cthd)
        {
            try
            {
                var hd = await this.context.ChiTietHoaDons.FindAsync(id.ToString());
                using (var dbcthd = await this.context.Database.BeginTransactionAsync())
                {
                    if (hd != null)
                    {
                        hd.ThanhTien = cthd.ThanhTien;
                        hd.IdhoaDon = cthd.IdhoaDon.ToString();
                        hd.IdsanPham = cthd.IdsanPham.ToString();
                        hd.IdphieuNhapHang = cthd.IdphieuNhapHang.ToString();
                        hd.ChietKhau = cthd.ChietKhau;
                        hd.SoLuong = cthd.SoLuong;
                        hd.Dongia = cthd.Dongia;
                        hd.ThanhTien = cthd.ThanhTien;
                        hd.GhiChu = cthd.GhiChu;

                        await context.SaveChangesAsync();
                        await dbcthd.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Cap Nhat Thanh Cong"
                        };

                    }
                }
            }
            catch
            { }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Cap Nhat That Bai"
            };
        }

        public async Task<ActionResult<List<ChiTietHoaDonEntities>>> DanhSach()
        {
            try
            {
                List<ChiTietHoaDon> lst = await this.context.ChiTietHoaDons.ToListAsync();
                if (lst.Count > 0 && lst != null)
                {
                    return this.mapper.Map<List<ChiTietHoaDon>, List<ChiTietHoaDonEntities>>(lst);
                }

            }
            catch
            {

            }
            return new List<ChiTietHoaDonEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(ChiTietHoaDonEntities cthd)
        {
            cthd.IdchiTietHoaDon = Guid.NewGuid();
            try
            {
                using (var dbcthd = await this.context.Database.BeginTransactionAsync())
                {
                    if (cthd != null)
                    {
                        ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon
                        {
                            IdchiTietHoaDon = cthd.IdchiTietHoaDon.ToString(),
                            IdhoaDon = cthd.IdhoaDon.ToString(),
                            IdsanPham = cthd.IdsanPham.ToString(),
                            IdphieuNhapHang = cthd.IdphieuNhapHang.ToString(),
                            ChietKhau = cthd.ChietKhau,
                            SoLuong = cthd.SoLuong,
                            Dongia = cthd.Dongia,
                            ThanhTien = cthd.ThanhTien,
                            GhiChu = cthd.GhiChu
                        };
                        await context.AddRangeAsync(chiTietHoaDon);
                        await context.SaveChangesAsync();
                        await dbcthd.CommitAsync();
                        return new TrangThai()
                        {
                            MaTrangThai = 1,
                            ThongBao = "Them Thanh Cong"

                        };
                    }

                }
            }
            catch { }
            return new TrangThai()
            {
                MaTrangThai = 0,
                ThongBao = "Them That Bai "

            };

        }

        public async Task<ActionResult<ChiTietHoaDonEntities>> TimTheoID(Guid id)
        {
            try
            {
                var hd = await this.context.ChiTietHoaDons.FirstOrDefaultAsync(h => h.IdchiTietHoaDon.Equals(id.ToString()));
                if (hd != null)
                {
                    return this.mapper.Map<ChiTietHoaDon, ChiTietHoaDonEntities>(hd);
                }

            }
            catch { }
            return new ChiTietHoaDonEntities() { };

        }

        public async Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDHoaDon(Guid idsp)
        {
            try
            {
                List<ChiTietHoaDon> lst = await this.context.ChiTietHoaDons.Where(h => h.IdhoaDon == idsp.ToString()).ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<ChiTietHoaDon>, List<ChiTietHoaDonEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<ChiTietHoaDonEntities>() { };
        }

        //public async Task<ActionResult<ChiTietHoaDonEntities>> TimHoaDonTheoIDSanPham(Guid id)
        //{
        //    try
        //    {
        //        var hd = await this.context.ChiTietHoaDons.FirstOrDefaultAsync(h => h.IdsanPham.Equals(id.ToString()));
        //        if (hd != null)
        //        {
        //            return this.mapper.Map<ChiTietHoaDon, ChiTietHoaDonEntities>(hd);
        //        }

        //    }
        //    catch { }
        //    return new ChiTietHoaDonEntities() { };
        //}

        public async Task<ActionResult<List<ChiTietHoaDonEntities>>> TimTheoIDSanPham(Guid idsp)
        {
            try
            {
                List<ChiTietHoaDon> lst = await this.context.ChiTietHoaDons.Where(h => h.IdsanPham == idsp.ToString()).ToListAsync();
                if (lst != null && lst.Count > 0)
                {
                    return this.mapper.Map<List<ChiTietHoaDon>, List<ChiTietHoaDonEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<ChiTietHoaDonEntities>() { };
        }



        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                var hd = await this.context.ChiTietHoaDons.FindAsync(id.ToString());
                using (var dbhd = await this.context.Database.BeginTransactionAsync())
                {
                    if (hd != null)
                    {
                        context.Remove(hd);
                        await this.context.SaveChangesAsync();
                        await dbhd.CommitAsync();
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
