using Diary.Entities;
using Diary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Data.Repository
{
    public class LessonFileRepository : BaseRepository<LessonFile>, ILessonFileRepository
    {
        public LessonFileRepository(IConfiguration configuration): base(configuration){}
        public IEnumerable<Guid> GetFileIdsBySchedueId(Guid scheduleId)
        {
            using var ctx = new Context(_configuration);
            return ctx
                .LessonFiles
                .Where(x => x.ScheduleId == scheduleId)
                .AsNoTracking()
                .Select(x=>x.FileId)
                .ToList();
        }
    }
}
