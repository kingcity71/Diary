using Diary.Entities;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface ILessonFileRepository : IRepository<LessonFile>
    {
        IEnumerable<Guid> GetFileIdsBySchedueId(Guid scheduleId);
    }
}
