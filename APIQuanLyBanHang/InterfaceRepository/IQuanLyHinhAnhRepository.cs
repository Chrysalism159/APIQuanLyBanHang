namespace APIQuanLyBanHang.InterfaceRepo
{
    public interface IQuanLyHinhAnhRepository
    {
        public Tuple<int, string> TaiHinhAnh(IFormFile imageFile);
    }
    public class QuanLyHinhAnhRepository : IQuanLyHinhAnhRepository
    {
        private IWebHostEnvironment environment;
        public QuanLyHinhAnhRepository(IWebHostEnvironment env)
        {
            this.environment = env;
        }

        public Tuple<int, string> TaiHinhAnh(IFormFile imageFile)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "wwwroot\\ProductImg");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);

                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
    }
}
