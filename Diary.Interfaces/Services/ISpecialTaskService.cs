using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface ISpecialTaskService
    {
        void Delete(Guid id);
        void DeleteFile(Guid id);
        void Create(SpecialTask specialTask);
        SpecialTask Update(SpecialTask specialTask);
        void UpdateFile(Guid spId,Guid newFileId);
        IEnumerable<SpecialTask> GetSpecialTasks(Guid schedId);
    }
}
