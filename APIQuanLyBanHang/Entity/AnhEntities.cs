namespace APIQuanLyBanHang.Entity
{
    public class AnhEntities
    {
        public Guid Idanh { get; set; } 

        public string? FileAnh { get; set; }

        public string? GhiChu { get; set; }

        public IFormFile? file {  get; set; }
    }
}
