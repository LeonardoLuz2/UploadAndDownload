using Download.Api.Config;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Download.Api
{
    public class DownloadFile
    {
        public Stream GetFile(string filename)
        {
            string filePath = $"{ConfigurationHelper.Directory}/{filename}" ;

            if (!File.Exists(filePath))
            {
                return null;
            }

            return new FileStream(filePath, FileMode.Open);
        }
    }
}
