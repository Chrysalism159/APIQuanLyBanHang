using APIQuanLyBanHang.Entity;
using APIQuanLyBanHang.Model;
using AutoMapper;

namespace APIQuanLyBanHang.HandleMapping
{
    public class MapProfile : Profile
    {
        public MapProfile() {
            CreateMap<TheThanhVien, TheKhachHangEntities>();
            CreateMap<LoaiThe, LoaiTheEntities>();
            CreateMap<SanPham, SanPhamEntities>();
            CreateMap<Anh, AnhEntities>();
        }

    }
}
