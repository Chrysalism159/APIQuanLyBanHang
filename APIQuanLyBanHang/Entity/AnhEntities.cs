namespace APIQuanLyBanHang.Entity
{
    public class AnhEntities
    {
        public Guid Idanh { get; set; }

        public string? TenFileAnh { get; set; }

        public string? GhiChu { get; set; }
        public IFormFile? file {  get; set; }
    }
}
