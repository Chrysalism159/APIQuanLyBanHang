using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface ISanPhamRepository
    {
        public Task<ActionResult<List<SanPhamEntities>>> DanhSach();
        public Task<ActionResult<SanPhamEntities>> TimTheoID(Guid id);
        public Task<ActionResult<List<SanPhamEntities>>> TimTheoTen(string name);
        public Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh);
        public Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, SanPhamEntities kh);
        public Task<ActionResult<TrangThai>> XoaThongTin(Guid id);
    }
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly QlbdaTtsContext _context;
        private readonly IMapper _map;
        private readonly IAnhRepository _repo;

        public SanPhamRepository(QlbdaTtsContext context, IMapper map, IAnhRepository repo)
        {
            this._context = context;
            this._map = map;
            this._repo = repo;
        }
        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, SanPhamEntities kh)
        {
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    SanPham tt = await _context.SanPhams.FindAsync(id.ToString());
                    if (tt != null && kh != null)
                    {
                        tt.Idanh = kh.Idanh.ToString();
                        tt.TenSanPham = kh.TenSanPham;
                        tt.GiaBan = kh.GiaBan;
                        tt.GiaVon = kh.GiaVon;
                        tt.DonVi = kh.DonVi;
                        tt.SoLuongHienCo = kh.SoLuongHienCo;
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

        public async Task<ActionResult<List<SanPhamEntities>>> DanhSach()
        {
            var sp = await _context.SanPhams.Include(m => m.IdanhNavigation).ToListAsync();
            if (sp != null && sp.Count > 0)
            {
                return this._map.Map<List<SanPham>, List<SanPhamEntities>>(sp);
            }
            return new List<SanPhamEntities>();
        }


        public async Task<ActionResult<TrangThai>> ThemThongTin(SanPhamEntities kh)
        {
            kh.IdsanPham = Guid.NewGuid();
            try
            {
                using (var dbtran = await this._context.Database.BeginTransactionAsync())
                {
                    SanPham tt = new SanPham()
                    {
                        IdsanPham = kh.IdsanPham.ToString(),
                        Idanh = kh.Idanh.ToString(),
                        TenSanPham = kh.TenSanPham,
                        GiaBan = kh.GiaBan,
                        GiaVon = kh.GiaVon,
                        DonVi = kh.DonVi,
                        SoLuongHienCo = kh.SoLuongHienCo,
                        GhiChu = kh.GhiChu
                    };

                    await _context.AddAsync(tt);
                    await _context.SaveChangesAsync();
                    await dbtran.CommitAsync();
                    return new TrangThai() { MaTrangThai = 1, ThongBao = "Them thanh cong" };

                }
            }
            catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them that bai" };
        }

        public async Task<ActionResult<SanPhamEntities>> TimTheoID(Guid id)
        {
            try
            {
                var sp = await this._context.SanPhams.FirstOrDefaultAsync(h => h.IdsanPham.Equals(id.ToString()));
                if (sp != null)
                {
                    return this._map.Map<SanPhamEntities>(sp);
                }

            }
            catch
            {

            }
            return new SanPhamEntities() { };
        }

        public async Task<ActionResult<List<SanPhamEntities>>> TimTheoTen(string name)
        {
            try
            {
                List<SanPham> lst = await this._context.SanPhams.Where(h => h.TenSanPham.Contains(name)).ToListAsync();
                if (lst.Count > 0 && lst != null)
                {
                    return this._map.Map<List<SanPham>, List<SanPhamEntities>>(lst);
                }
            }
            catch
            {

            }
            return new List<SanPhamEntities>() { };
        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                var sp = await this._context.SanPhams.FindAsync(id.ToString());
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
