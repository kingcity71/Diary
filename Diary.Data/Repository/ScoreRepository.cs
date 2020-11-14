using Diary.Entities;
using Diary.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Data.Repository
{
    public class ScoreRepository : BaseRepository<Score>, IScoreRepository
    {
        public ScoreRepository(IConfiguration configuration): base(configuration){}

        public void CreateMany(IEnumerable<Score> scores)
        {
            using var ctx = new Context(_configuration);
            ctx.Scores.AddRange(scores);
            ctx.SaveChanges();
        }

        public IEnumerable<Score> GetItems(Guid schedId)
        {
            using var ctx = new Context(_configuration);
            return ctx.Scores.Where(x => x.ScheduleId == schedId).ToList();
        }

        public void UpdateMany(IEnumerable<Score> scores)
        {
            using var ctx = new Context(_configuration);
            ctx.Scores.UpdateRange(scores);
            ctx.SaveChanges();
        }
    }
}
