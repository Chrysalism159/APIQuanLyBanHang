using APIQuanLyBanHang.Data;
using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.Repository
{
    public class LoaiTheRepo : ILoaiTheRepo
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;

        public LoaiTheRepo(QlbdaTtsContext _context, IMapper _map) 
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
                            tt.GhiChu = kh.GhiChuLoaiThe;
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
            if(ds != null && ds.Count > 0)
            {
                return this._map.Map<List<LoaiThe>, List<LoaiTheEntities>>(ds);
            }
            return new List<LoaiTheEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(LoaiTheEntities kh)
        {
            kh.IdLoaiThe = Guid.NewGuid();
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    if(kh!= null)
                    {
                        LoaiThe tt = new LoaiThe()
                        {
                            IdloaiThe = kh.IdLoaiThe.ToString(),
                            TenLoaiThe = kh.TenLoaiThe,
                            HanMuc = kh.HanMuc.ToString(),
                            GhiChu = kh.GhiChuLoaiThe
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
            if (ds != null )
            {
                return this._map.Map<LoaiThe, LoaiTheEntities>(ds);
            }
            return new LoaiTheEntities();
        }

        public async Task<ActionResult<List<LoaiTheEntities>>> TimTheoTen(string name)
        {
            List<LoaiThe> ds = await _context.LoaiThes.Where(m=>m.TenLoaiThe.Contains(name)).ToListAsync();
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
                using(var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    LoaiThe tt  = await _context.LoaiThes.FindAsync(id.ToString());
                    if(tt != null)
                    {
                        _context.LoaiThes.Remove(tt);
                        await _context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Xoa thanh cong" };
                    }
                }
            }catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai" };
        }
    }
}
