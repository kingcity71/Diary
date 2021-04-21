using Diary.Entities;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface ISpecialTaskRepository : IRepository<SpecialTask>
    {
        SpecialTask CreateItem(SpecialTask specialTask);
        IEnumerable<SpecialTask> GetMany(Guid schedId);
        IEnumerable<Guid> FileIds(Guid stId);
    }
}
