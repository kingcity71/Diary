using Diary.Entities;
using Diary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Data.Repository
{
    public class SpecialTaskRepository : BaseRepository<SpecialTask>, ISpecialTaskRepository
    {
        public SpecialTaskRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public SpecialTask CreateItem(SpecialTask item)
        {
            using var ctx = new Context(_configuration);
            var newItem = ctx.Add(item);
            ctx.SaveChanges();
            return newItem.Entity;
        }

        public IEnumerable<SpecialTask> GetMany(Guid schedId)
        {
            using var ctx = new Context(_configuration);
            return ctx.SpecialTasks
                .Where(x => x.ScheduleId == schedId)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Guid> FileIds(Guid stId)
        {
            using var ctx = new Context(_configuration);
            return ctx.SpecialTaskFiles
                .Where(x => x.SpecialTaskId == stId)
                .AsNoTracking().
                Select(x => x.FileId)
                .ToList();
        }
    }
}
