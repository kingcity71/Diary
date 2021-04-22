using Diary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Diary.WebApp.Controllers
{
    public class FileController : Controller
    {
        const string PATH = @"D:\Test Upload\";
        private readonly IFileService fileService;
        private readonly IConfiguration configuration;

        public FileController(IFileService fileService, IConfiguration configuration)
        {
            this.fileService = fileService;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            Guid fileId = new Guid();
            try
            {
                fileId = fileService.Upload(file).Id;
            }
            catch
            {
                return BadRequest();
            }
            return Ok(fileId);
        }
        [HttpGet]
        public IActionResult Download(Guid id)
        {
            var fileName = fileService.GetFileName(id);
            var bytes = fileService.Download(id);
            var content = new MemoryStream(bytes);
            var contentType = GetContentType(fileName);
            return File(content, contentType, fileName);
        }
        string GetContentType(string fileName)
        {
            var contentTypes = configuration
                .GetSection("FileApplicationTypes")
                .AsEnumerable();
            var fileExtension = fileName.Split('.').LastOrDefault();
            foreach (var item in contentTypes)
            {
                var key = item.Key.Split(':').LastOrDefault();
                if (string.IsNullOrEmpty(key)) continue;
                if (key.ToLower() == fileExtension.ToLower())
                    return configuration[item.Key];
            }

            return string.Empty;
        }
    }
}
