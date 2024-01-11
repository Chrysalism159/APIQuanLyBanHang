using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;

namespace APIQuanLyBanHang.HandleMapping
{
    public class MapProfile : Profile
    {
        public MapProfile() {
            CreateMap<TheThanhVien, TheThanhVienEntities>();
            CreateMap<LoaiThe, LoaiTheEntities>();
            CreateMap<NhanVien, NhanVienEntities>();
            CreateMap<ChiNhanh, ChiNhanhEntities>();
            CreateMap<TaiKhoan, TaiKhoanEntities>();
            CreateMap<NhaCungCap,NhaCungCapEntities>();
            CreateMap<PhieuChiTieu,PhieuChiTieuEntities>();

            CreateMap<SanPham, SanPhamEntities>();
            CreateMap<HoaDon, HoaDonEntities>();
            CreateMap<ChiTietHoaDon, ChiTietHoaDonEntities>();
            CreateMap<PhieuNhapHang, PhieuNhapHangEntities>();

        }

    }
}
