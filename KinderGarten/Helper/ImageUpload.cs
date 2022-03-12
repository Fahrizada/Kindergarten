using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace KinderGarten.Helper
{
    public class ImageUpload
    {
        private readonly IHostingEnvironment _environment;
        public ImageUpload(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public static async Task<string> Upload(IFormFile file)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Slike");
            //var uploads = Path.Combine(_environment.WebRootPath, "Slike");
            string putanja = null;
            if (file.Length > 0)
            {
                var filePath = Path.Combine(folder, file.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
            putanja = Path.Combine("Slike", file.FileName);

            return putanja;
        }
    }
}
