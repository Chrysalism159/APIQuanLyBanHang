
using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.Repository
{
    public class TheKhachHangRepo : ITheKhachHangRepo
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;

        public TheKhachHangRepo(QlbdaTtsContext _context, IMapper map) 
        {
            this._context = _context;
            this._map = map;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheThanhVienEntities kh)
        {
            try
            {
                using(var dbtran = await this._context.Database.BeginTransactionAsync()) 
                {
                    TheThanhVien tt = await _context.FindAsync<TheThanhVien>(id.ToString());
                    if(tt !=  null)
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
                        tt.ĐiaChi = kh.ĐiaChi;
                        tt.NgaySinh = kh.NgaySinh;
                        tt.GhiChu = kh.GhiChu;
                    }
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong" };
                }
            }catch (Exception ex) {
                return new TrangThai() { MaTrangThai = 0, ThongBao = "Sua that bai" };
            }
        }

        public async Task<ActionResult<List<TheThanhVienEntities>>> DanhSach()
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.ToListAsync();
            if(ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheThanhVienEntities>>(ds);
            }
            return new List<TheThanhVienEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(TheThanhVienEntities kh)
        {
            kh.IdtheThanhVien = Guid.NewGuid();
            try
            {
                using(var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    if(kh != null)
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
                            SoTienDaTichLuy = kh.SoTienDaTichLuy,
                            SoTienDaSuDung = kh.SoTienDaSuDung,
                            GioiTinh = kh.GioiTinh,
                            ĐiaChi = kh.ĐiaChi,
                            NgaySinh = kh.NgaySinh,
                            GhiChu = kh.GhiChu
                        };
                        _context.Add(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong" };
                    }
                }

            }catch(Exception ex) { }
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

        public async Task<ActionResult<List<TheThanhVienEntities>>> TimTheoTen(string name)
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.Where( m=>m.TenKhachHang.Contains(name)).ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheThanhVienEntities>>(ds);
            }
            return new List<TheThanhVienEntities>();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id) 
        {
            TheThanhVien tt = await _context.TheThanhViens.FindAsync(id.ToString());
            if(tt != null)
            {
                _context.TheThanhViens.Remove(tt);
                _context.SaveChangesAsync();
                return new TrangThai() { MaTrangThai=1, ThongBao="Xoa thanh cong!"};
            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai!" };
        }
    }
}
