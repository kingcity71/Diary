using Diary.Entities;

namespace Diary.Interfaces
{
    public interface IFileRepository :  IRepository<File>
    {
        File GetItem(string fileName);
    }
}
