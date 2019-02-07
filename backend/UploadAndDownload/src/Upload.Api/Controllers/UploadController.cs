using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upload.Api.Models;

namespace Upload.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UploadFile _upload;

        public UploadController(UploadFile upload)
        {
            _upload = upload;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var result = _upload.Upload(file);

            if (!result)
            {
                return BadRequest(Result.Response(400, "Upload failed."));
            }

            return Ok(Result.Response(200, "Upload Successful!"));
        }
    }
}