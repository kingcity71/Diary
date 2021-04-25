using Diary.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Diary.Interfaces
{
    public interface IFileService
    {
        void Delete(Guid id);
        string GetFileName(Guid id);
        File Upload(IFormFile file);
        byte[] Download(Guid id);
    }
}
