using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Upload.Api.Config;

namespace Upload.Api
{
    public class UploadFile
    {
        public bool Upload(IFormFile file)
        {
            if (file.Length <= 0)
            {
                return false;
            }

            string path = CreateDirectory();

            string fileName = $"{Guid.NewGuid()}.{file.FileName}";
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return true;
        }

        private string CreateDirectory()
        {
            string uploads = ConfigurationHelper.Directory;
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            return uploads;
        }
    }
}
