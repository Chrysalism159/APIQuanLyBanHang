using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ITheKhachHangRepository
    {
        public Task<ActionResult<List<TheThanhVienEntities>>> DanhSach();
        public Task<ActionResult<TheThanhVienEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<TheThanhVienEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(TheThanhVienEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheThanhVienEntities kh);
        public Task<ActionResult<TheThanhVienEntities>> LayMaKhachHang(string name, string sdt);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class TheKhachHangRepository : ITheKhachHangRepository
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;

        public TheKhachHangRepository(QlbdaTtsContext _context, IMapper map)
        {
            this._context = _context;
            this._map = map;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheThanhVienEntities kh)
        {
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    TheThanhVien tt = await _context.FindAsync<TheThanhVien>(id.ToString());
                    if (tt != null)
                    {
                        tt.IdloaiThe = kh.IdloaiThe.ToString();
                        tt.TenKhachHang = kh.TenKhachHang;
                        tt.Sdt = kh.Sdt;
                        tt.Email = kh.Email;
                        tt.SoDiemTichLuy = kh.SoDiemTichLuy;
                        tt.SoDiemDaSuDung = kh.SoDiemDaSuDung;
                        tt.SoTienDaTichLuy = kh.SoTienDaTichLuy;
                        tt.SoTienDaSuDung = kh.SoTienDaSuDung;
                        tt.GioiTinh = kh.GioiTinh;
                        tt.DiaChi = kh.DiaChi;
                        tt.NgaySinh = DateTime.ParseExact(kh.NgaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        tt.GhiChu = kh.GhiChu;
                    }
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong" };
                }
            }
            catch (Exception ex)
            {
                return new TrangThai() { MaTrangThai = 0, ThongBao = "Sua that bai" };
            }
        }

        public async Task<ActionResult<List<TheThanhVienEntities>>> DanhSach()
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheThanhVienEntities>>(ds);
            }
            return new List<TheThanhVienEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(TheThanhVienEntities kh)
        {
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    if (kh != null)
                    {
                        TheThanhVien tt = new TheThanhVien()
                        {
                            IdtheThanhVien = kh.IdtheThanhVien.ToString(),
                            IdloaiThe = kh.IdloaiThe.ToString(),
                            TenKhachHang = kh.TenKhachHang,
                            Sdt = kh.Sdt,
                            Email = kh.Email,
                            SoDiemTichLuy = kh.SoDiemTichLuy,
                            SoDiemDaSuDung = kh.SoDiemDaSuDung,
                            SoTienDaTichLuy = kh.SoTienDaSuDung,
                            SoTienDaSuDung = kh.SoTienDaSuDung,
                            GioiTinh = kh.GioiTinh,
                            DiaChi = kh.DiaChi,
                            NgaySinh = DateTime.ParseExact(kh.NgaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            GhiChu = kh.GhiChu
                        };
                        _context.Add(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong" };
                    }
                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them that bai" };
        }

        public async Task<ActionResult<TheThanhVienEntities>> TimTheoID(Guid id)
        {
            TheThanhVien ds = await _context.TheThanhViens.FindAsync(id.ToString());
            if (ds != null)
            {
                return this._map.Map<TheThanhVien, TheThanhVienEntities>(ds);
            }
            return new TheThanhVienEntities();
        }
        public async Task<ActionResult<TheThanhVienEntities>> LayMaKhachHang(string name, string sdt)
        {
            TheThanhVien ds = await _context.TheThanhViens.Where(m => m.TenKhachHang.Equals(name) && m.Sdt.Equals(sdt)).FirstOrDefaultAsync();
            if (ds != null)
            {
                return this._map.Map<TheThanhVien, TheThanhVienEntities>(ds);
            }
            return new TheThanhVienEntities();
        }
        public async Task<ActionResult<List<TheThanhVienEntities>>> TimTheoTen(string name)
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.Where(m => m.TenKhachHang.Contains(name)).ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheThanhVienEntities>>(ds);
            }
            return new List<TheThanhVienEntities>();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                var sp = await this._context.TheThanhViens.FindAsync(id.ToString());
                using (var dbsp = await this._context.Database.BeginTransactionAsync())
                {
                    if (sp != null)
                    {
                        this._context.Remove(sp);
                        await this._context.SaveChangesAsync();
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
                ThongBao = "Xoa That Bai "
            };
        }
    }
}
