using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.HandleMapping;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace APIQuanLyBanHang.Repository
{
    public class NhanVienRepo : INhanVienRepo
    {
        private readonly QlbdaTtsContext context;
        private readonly IMapper mapProfile;
        public NhanVienRepo(QlbdaTtsContext context, IMapper mapProfile)
        {
            this.context = context;
            this.mapProfile = mapProfile;
        }

        public async Task<ActionResult<TrangThai>> CapNhatThongTin(Guid id, NhanVienEntities kh)
        {
            try
            {
                using(var dbnv=await context.Database.BeginTransactionAsync())
                {
                    NhanVien nv = await context.NhanViens.FindAsync(id.ToString());
                    if(nv!=null &&kh!=null)
                    {
                        nv.IdchiNhanh = kh.IdchiNhanh.ToString();
                        nv.IdtaiKhoan = kh.IdtaiKhoan.ToString();
                        nv.TenNhanVien = kh.TenNhanVien;
                            nv.Sdt = kh.Sdt;
                            nv.NgayBatDauLamViec = kh.NgayBatDauLamViec;
                            nv.Cccd = kh.Cccd;
                            nv.NgaySinh = kh.NgaySinh;
                            nv.GioiTinh = kh.GioiTinh;
                            nv.Email = kh.Email;
                            nv.ĐiaChi = kh.ĐiaChi;
                            nv.TrangThai = kh.TrangThai;
                            nv.GhiChu = kh.GhiChu;
                        await context.SaveChangesAsync();
                        await dbnv.CommitAsync();
                        return new TrangThai() { MaTrangThai = 1, ThongBao = "Da Sua Thanh Cong" };
                    }    
                    
                }    
               
            }
            catch
            {
                
            }
            return new TrangThai() { ThongBao = "Sua Khong Thanh Cong", MaTrangThai = 0 };
        }

        public async Task<ActionResult<List<NhanVienEntities>>> DanhSach()
        {
            List<NhanVien> ds = await context.NhanViens.ToListAsync();
            if(ds.Count > 0&&ds!=null)
            {
                return this.mapProfile.Map<List<NhanVien>, List<NhanVienEntities>>(ds);
            }
            return new List<NhanVienEntities>();
        }

        public async Task<ActionResult<TrangThai>> ThemThongTin(NhanVienEntities kh)
        {
             kh.IdnhanVien = Guid.NewGuid();
            try
            {
                using (var dbnv = await this.context.Database.BeginTransactionAsync())
                { 
                  
                    if (kh != null)
                    {
                        NhanVien nhanVien = new NhanVien()
                        { 
                            IdnhanVien = kh.IdnhanVien.ToString(),    
                            IdchiNhanh = kh.IdchiNhanh.ToString(),
                            IdtaiKhoan = kh.IdtaiKhoan.ToString(),
                            TenNhanVien = kh.TenNhanVien,
                            Sdt = kh.Sdt,
                            NgayBatDauLamViec = kh.NgayBatDauLamViec,
                            Cccd = kh.Cccd,
                            NgaySinh = kh.NgaySinh,
                            GioiTinh = kh.GioiTinh,
                            Email = kh.Email,
                            ĐiaChi = kh.ĐiaChi,
                            TrangThai = kh.TrangThai,
                            GhiChu = kh.GhiChu

                        };
                         context.Add(nhanVien);
                        await context.SaveChangesAsync();
                        await dbnv.CommitAsync();
                        return new TrangThai(){ MaTrangThai = 1, ThongBao = "Them Thanh Cong" };
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new TrangThai() { MaTrangThai = 0, ThongBao = "Them That Bai" };
        }

        public async Task<ActionResult<NhanVienEntities>> TimTheoID(Guid id)
        {
            try
            {
                var nv=await context.NhanViens.FirstOrDefaultAsync(h=>h.IdnhanVien.Equals(id.ToString()));
                if(nv!=null)
                {
                    return this.mapProfile.Map<NhanVien,NhanVienEntities>(nv);
                }    
                   
            }
            catch(Exception ex) { }
            {
                return new NhanVienEntities() { };
            }    
        }

        public async Task<ActionResult<List<NhanVienEntities>>> TimTheoTen(string name)
        {
            List<NhanVien>lst=await context.NhanViens.Where(h=>h.TenNhanVien.Contains(name)).ToListAsync();
            try
            {
                if(lst!=null&&lst.Count>0)
                {
                    return  this.mapProfile.Map<List<NhanVien>,List <NhanVienEntities>>(lst);
                }    
            }
            catch
            {

            }
            return new List<NhanVienEntities>() { };

        }

        public async Task<ActionResult<TrangThai>> XoaThongTin(Guid id)
        {
            try
            {
                using(var dbnv=await context.Database.BeginTransactionAsync())
                {
                    var nv = await context.NhanViens.FindAsync(id.ToString());
                    if(nv!=null)
                    {
                         context.Remove(nv);
                        await context.SaveChangesAsync();
                        await dbnv.CommitAsync();
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
