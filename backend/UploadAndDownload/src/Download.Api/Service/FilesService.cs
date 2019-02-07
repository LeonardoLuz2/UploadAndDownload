using Download.Api.Config;
using Download.Api.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Download.Api.Service
{
    public class FilesService
    {
        Func<string, FileInfos> fileInfo = delegate(string f) {
            return new FileInfos { 
                Filename = Path.GetFileName(f), 
                Extension = Path.GetExtension(f) 
            };
        };

        public List<FileInfos> GetDirectoryFiles()
        {
            string directory = ConfigurationHelper.Directory;
            
            if (!Directory.Exists(directory))
            {
                return null;
            }

            return Directory.GetFiles(directory).Select(fileInfo).ToList();
        }
    }
}
