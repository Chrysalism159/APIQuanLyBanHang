namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IQuanLyHinhAnhRepo
    {
        public Tuple<int, string> TaiHinhAnh(IFormFile imageFile);
    }
}
