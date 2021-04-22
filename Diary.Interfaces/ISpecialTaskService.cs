using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface ISpecialTaskService
    {
        void Delete(Guid id);
        void Create(SpecialTask specialTask);
        IEnumerable<SpecialTask> GetSpecialTasks(Guid schedId);
    }
}
