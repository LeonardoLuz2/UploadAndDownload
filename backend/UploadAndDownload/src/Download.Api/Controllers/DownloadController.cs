using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Download.Api.Config;
using Download.Api.Models;
using Download.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Download.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly FilesService _fileService;
        private readonly DownloadFile _downloadFile;

        public DownloadController(FilesService fileService, DownloadFile downloadFile)
        {
            _fileService = fileService;
            _downloadFile = downloadFile;
        }

        [HttpGet]
        public List<FileInfos> GetFiles()
        {
            return _fileService.GetDirectoryFiles();
        }

        [HttpGet("{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            Stream stream = _downloadFile.GetFile(fileName);

            if (Object.Equals(stream, null))
            {
                return NotFound();
            }

            return File(stream, "application/octet-stream", fileName);
        }
    }
}