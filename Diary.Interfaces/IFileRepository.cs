using Diary.Entities;
using System;

namespace Diary.Interfaces
{
    public interface IFileRepository :  IRepository<File>
    {
        File GetItem(string fileName);
    }
}
