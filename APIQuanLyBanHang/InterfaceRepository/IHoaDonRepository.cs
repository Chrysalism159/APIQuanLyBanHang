using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IHoaDonRepository
    {
        public Task<ActionResult<List<HoaDonEntities>>> DanhSach();
        public Task<ActionResult<HoaDonEntities>> TimTheoIDKhachHang(Guid id);
        public Task<ActionResult<HoaDonEntities>> TimTheoIDNhanVien(Guid id);
        public Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper map;

        public HoaDonRepository(QlbdaTtsContext _context, IMapper map)
        {
            this._context = _context;
            this.map = map;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, HoaDonEntities kh)
        {
            try
            {
                using (var dbtran = await _context.Database.BeginTransactionAsync())
                {
                    HoaDon tt = await _context.HoaDons.FirstOrDefaultAsync(m => m.IdhoaDon.Equals(kh.IdhoaDon.ToString()));
                    if (tt != null)
                    {
                        tt.IdhoaDon = kh.IdhoaDon.ToString();
                        tt.IdchiNhanh = kh.IdchiNhanh.ToString();
                        tt.IdnhanVien = kh.IdnhanVien.ToString();
                        tt.IdtheThanhVien = kh.IdtheThanhVien.ToString();
                        tt.SoTienKhachTra = kh.SoTienKhachTra;
                        tt.TongTienSauChietKhau = kh.TongTienSauChietKhau;
                        tt.NgayLapHoaDon = DateTime.ParseExact(kh.NgayLapHoaDon, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    }
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong!" };

                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai!" };
        }

        public async Task<ActionResult<List<HoaDonEntities>>> DanhSach()
        {
            List<HoaDon> ds = await _context.HoaDons.Include(m => m.ChiTietHoaDons).ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this.map.Map<List<HoaDon>, List<HoaDonEntities>>(ds);
            }
            return new List<HoaDonEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(HoaDonEntities kh)
        {
            try
            {
                using (var dbtran = await _context.Database.BeginTransactionAsync())
                {
                    HoaDon tt = new HoaDon()
                    {
                        IdhoaDon = kh.IdhoaDon.ToString(),
                        IdchiNhanh = kh.IdchiNhanh.ToString(),
                        IdnhanVien = kh.IdnhanVien.ToString(),
                        IdtheThanhVien = kh.IdtheThanhVien.ToString(),
                        SoTienKhachTra = kh.SoTienKhachTra,
                        TongTienSauChietKhau = kh.TongTienSauChietKhau,
                        NgayLapHoaDon = DateTime.ParseExact(kh.NgayLapHoaDon, "yyyy-MM-dd", CultureInfo.InvariantCulture),

                    };
                    if (tt != null)
                    {
                        _context.HoaDons.AddAsync(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong!" };
                    }
                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them that bai!" };
        }

        public async Task<ActionResult<HoaDonEntities>> TimTheoIDKhachHang(Guid id)
        {
            HoaDon tt = await _context.HoaDons.FirstOrDefaultAsync(m => m.IdtheThanhVien.Equals(id.ToString()));
            if (tt != null)
            {
                return this.map.Map<HoaDon, HoaDonEntities>(tt);
            }
            return new HoaDonEntities();
        }

        public async Task<ActionResult<HoaDonEntities>> TimTheoIDNhanVien(Guid id)
        {
            HoaDon tt = await _context.HoaDons.FirstOrDefaultAsync(m => m.IdnhanVien.Equals(id.ToString()));
            if (tt != null)
            {
                return this.map.Map<HoaDon, HoaDonEntities>(tt);
            }
            return new HoaDonEntities();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                using (var dbtran = await _context.Database.BeginTransactionAsync())
                {
                    HoaDon tt = await _context.HoaDons.FirstOrDefaultAsync(m => m.IdhoaDon.Equals(id.ToString()));
                    if (tt != null)
                    {
                        _context.HoaDons.Remove(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Xoa thanh cong!" };
                    }
                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai!" };
        }
    }
}
