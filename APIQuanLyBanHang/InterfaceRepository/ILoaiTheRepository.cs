using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ILoaiTheRepository
    {
        public Task<ActionResult<List<LoaiTheEntities>>> DanhSach();
        public Task<ActionResult<LoaiTheEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<LoaiTheEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(LoaiTheEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, LoaiTheEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class LoaiTheRepository : ILoaiTheRepository
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;

        public LoaiTheRepository(QlbdaTtsContext _context, IMapper _map)
        {
            this._context = _context;
            this._map = _map;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, LoaiTheEntities kh)
        {
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    LoaiThe tt = await _context.LoaiThes.FindAsync(id.ToString());
                    if (tt != null && kh != null)
                    {
                        tt.TenLoaiThe = kh.TenLoaiThe;
                        tt.HanMuc = kh.HanMuc.ToString();
                        tt.GhiChu = kh.GhiChu;
                    }
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong" };

                }
            }
            catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Sua that bai" };

        }

        public async Task<ActionResult<List<LoaiTheEntities>>> DanhSach()
        {
            List<LoaiThe> ds = await _context.LoaiThes.ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<LoaiThe>, List<LoaiTheEntities>>(ds);
            }
            return new List<LoaiTheEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(LoaiTheEntities kh)
        {
            kh.IdloaiThe = Guid.NewGuid();
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    if (kh != null)
                    {
                        LoaiThe tt = new LoaiThe()
                        {
                            IdloaiThe = kh.IdloaiThe.ToString(),
                            TenLoaiThe = kh.TenLoaiThe,
                            HanMuc = kh.HanMuc.ToString(),
                            GhiChu = kh.GhiChu
                        };
                        await _context.LoaiThes.AddAsync(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong" };
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them that bai" };
        }

        public async Task<ActionResult<LoaiTheEntities>> TimTheoID(Guid id)
        {
            LoaiThe ds = await _context.LoaiThes.FindAsync(id.ToString());
            if (ds != null)
            {
                return this._map.Map<LoaiThe, LoaiTheEntities>(ds);
            }
            return new LoaiTheEntities();
        }

        public async Task<ActionResult<List<LoaiTheEntities>>> TimTheoTen(string name)
        {
            List<LoaiThe> ds = await _context.LoaiThes.Where(m => m.TenLoaiThe.Contains(name)).ToListAsync();
            if (ds != null && ds.Count > 0)
            {
                return this._map.Map<List<LoaiThe>, List<LoaiTheEntities>>(ds);
            }
            return new List<LoaiTheEntities>();
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    LoaiThe tt = await _context.LoaiThes.FindAsync(id.ToString());
                    if (tt != null)
                    {
                        _context.LoaiThes.Remove(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Xoa thanh cong" };
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai" };
        }
    }
}
