using Diary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Diary.Entities;
namespace Diary.Data.Repository
{

    public class FileRepository : BaseRepository<File>, IFileRepository
    {
        public FileRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public override void Create(File item)
        {
            using var ctx = new Context(_configuration);           
            ctx.Add(item);
            ctx.SaveChanges();
        }
        public File GetItem(string fileName)
        {
            using var ctx = new Context(_configuration);
            var entity = ctx.Files
                .AsNoTracking()
                .FirstOrDefault(x => x.FileName.ToLower().Trim() == fileName.ToLower().Trim());
            return entity;
        }

    }
}
