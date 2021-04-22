using Diary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using FileEntity = Diary.Entities.File;
namespace Diary.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepo;
        private string _path;

        public FileService(IFileRepository fileRepo, IConfiguration configuration)
        {
            this.fileRepo = fileRepo;
            _path = configuration["FilePath"];
        }
        public byte[] Download(Guid id)
        {
            var fileEntity = fileRepo.GetItem(id);
            return System.IO.File.ReadAllBytes(_path + fileEntity.FileName);
        }
        public string GetFileName(Guid id)
            => fileRepo.GetItem(id).FileName;
        public FileEntity Upload(IFormFile file)
        {
            var id = Guid.NewGuid();
            var fileExt = file.FileName.Split('.').Last();
            var fileName = $"{id}.{fileExt}";
            using (var fileStream = new FileStream(_path + fileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            fileRepo.Create(new FileEntity {Id = id, FileName = fileName });
            var fileEntity  = fileRepo.GetItem(fileName); ;
            return fileEntity;
        }
        public void Delete(Guid id)
        {
            var file = fileRepo.GetItem(id);
            var fullPath = _path + file.FileName;
            try
            {
                System.IO.File.Delete(fullPath);
            }
            catch { }
            fileRepo.Delete(id);
        }
    }
}
