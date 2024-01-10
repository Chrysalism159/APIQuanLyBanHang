using APIQuanLyBanHang.Data;
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

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, TheKhachHangEntities kh)
        {
            try
            {
                using(var dbtran = await this._context.Database.BeginTransactionAsync()) 
                {
                    TheThanhVien tt = await _context.FindAsync<TheThanhVien>(id.ToString());
                    if(tt !=  null)
                    {
                        tt.IdloaiThe = kh.IdLoaiThe.ToString();
                        tt.TenKhachHang = kh.TenKhachHang;
                        tt.Sdt = kh.SoDienThoai;
                        tt.Email = kh.Email;
                        tt.SoDiemTichLuy = kh.SoDiemTichLuy;
                        tt.SoDiemDaSuDung = kh.SoDiemDaSuDung;
                        tt.SoTienDaTichLuy = kh.SoTienTichLuy;
                        tt.SoTienDaSuDung = kh.SoTienDaSuDung;
                        tt.GioiTinh = kh.GioiTinh;
                        tt.ĐiaChi = kh.DiaChi;
                        tt.NgaySinh = kh.NgayThangNamSinh;
                        tt.GhiChu = kh.GhiChuKhachHang;
                    }
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong" };
                }
            }catch (Exception ex) {
                return new TrangThai() { MaTrangThai = 0, ThongBao = "Sua that bai" };
            }
        }

        public async Task<ActionResult<List<TheKhachHangEntities>>> DanhSach()
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.ToListAsync();
            if(ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheKhachHangEntities>>(ds);
            }
            return new List<TheKhachHangEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(TheKhachHangEntities kh)
        {
            kh.IdTheThanhVien = Guid.NewGuid();
            try
            {
                using(var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    if(kh != null)
                    {
                        TheThanhVien tt = new TheThanhVien()
                        {
                            IdtheThanhVien = kh.IdTheThanhVien.ToString(),
                            IdloaiThe = kh.IdLoaiThe.ToString(),
                            TenKhachHang = kh.TenKhachHang,
                            Sdt = kh.SoDienThoai,
                            Email = kh.Email,
                            SoDiemTichLuy = kh.SoDiemTichLuy,
                            SoDiemDaSuDung = kh.SoDiemDaSuDung,
                            SoTienDaTichLuy = kh.SoTienTichLuy,
                            SoTienDaSuDung = kh.SoTienDaSuDung,
                            GioiTinh = kh.GioiTinh,
                            ĐiaChi = kh.DiaChi,
                            NgaySinh = kh.NgayThangNamSinh,
                            GhiChu = kh.GhiChuKhachHang
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

        public async Task<ActionResult<TheKhachHangEntities>> TimTheoID(Guid id)
        {
            TheThanhVien ds = await _context.TheThanhViens.FindAsync(id.ToString());
            if (ds != null)
            {
                return this._map.Map<TheThanhVien, TheKhachHangEntities>(ds);
            }
            return new TheKhachHangEntities();
        }

        public async Task<ActionResult<List<TheKhachHangEntities>>> TimTheoTen(string name)
        {
            List<TheThanhVien> ds = await _context.TheThanhViens.Where( m=>m.TenKhachHang.Contains(name)).ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<TheThanhVien>, List<TheKhachHangEntities>>(ds);
            }
            return new List<TheKhachHangEntities>();
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
