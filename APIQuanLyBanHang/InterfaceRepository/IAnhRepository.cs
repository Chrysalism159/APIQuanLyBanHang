using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IAnhRepository
    {
        public Task<ActionResult<List<AnhEntities>>> DanhSach();
        public Task<ActionResult<AnhEntities>> TimTheoID(Guid id);
        public Task<ActionResult<TrangThai>> ThemThongTin(AnhEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, AnhEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class AnhRepository : IAnhRepository
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;
        private readonly IQuanLyHinhAnhRepository _repo;

        public AnhRepository(QlbdaTtsContext _context, IMapper map, IQuanLyHinhAnhRepository imgrepo)
        {
            this._context = _context;
            this._map = map;
            this._repo = imgrepo;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, [FromForm] AnhEntities kh)
        {
            try
            {
                using (var dbtran = await _context.Database.BeginTransactionAsync())
                {
                    Anh img = await _context.Anhs.FirstOrDefaultAsync(m => m.Idanh.Equals(id.ToString()));
                    if (img != null)
                    {
                        if (kh.file != null)
                        {
                            var result = _repo.TaiHinhAnh(kh.file);
                            if (result.Item1 == 1)
                            {
                                kh.FileAnh = result.Item2;
                            }
                            img.Idanh = kh.Idanh.ToString();
                            img.FileAnh = kh.FileAnh;
                            img.GhiChu = kh.GhiChu;
                        }
                        await this._context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Sua thanh cong" };
                    }
                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Sua that bai" };
        }

        public async Task<ActionResult<List<AnhEntities>>> DanhSach()
        {
            try
            {
                List<Anh> ds = await _context.Anhs.ToListAsync();
                if (ds != null && ds.Count > 0)
                {
                    return this._map.Map<List<Anh>, List<AnhEntities>>(ds);
                }
            }
            catch
            {

            }
            return new List<AnhEntities>();

        }

        public async Task<ActionResult<TrangThai>> ThemThongTin([FromForm] AnhEntities kh)
        {
            try
            {
                using (var dbtran = await _context.Database.BeginTransactionAsync())
                {
                    if (kh != null)
                    {

                        if (kh.file != null)
                        {
                            var result = _repo.TaiHinhAnh(kh.file);
                            if (result.Item1 == 1)
                            {
                                kh.FileAnh = result.Item2;
                            }

                        }
                        Anh img = new Anh()
                        {
                            Idanh = kh.Idanh.ToString(),
                            FileAnh = kh.FileAnh,
                            GhiChu = kh.GhiChu
                        };
                        await this._context.AddAsync(img);
                        await this._context.SaveChangesAsync();
                        await dbtran.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong" };
                    }
                }

            }
            catch (Exception ex) { }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them that bai" };
        }

        public async Task<ActionResult<AnhEntities>> TimTheoID(Guid id)
        {
            Anh ds = await _context.Anhs.FindAsync(id.ToString());
            if (ds != null)
            {
                return this._map.Map<Anh, AnhEntities>(ds);
            }
            return new AnhEntities();
        }



        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            Anh ds = await _context.Anhs.FindAsync(id.ToString());
            if (ds != null)
            {
                _context.Anhs.Remove(ds);
                await _context.SaveChangesAsync();
                return new TrangThai() { MaTrangThai = 1, ThongBao = "Xoa thanh cong" };
            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Xoa that bai" };
        }
    }
}
