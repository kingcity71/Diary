using Diary.Entities;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IScoreRepository : IRepository<Score>
    {
        IEnumerable<Score> GetItems(Guid schedId);
        void CreateMany(IEnumerable<Score> scores);
        void UpdateMany(IEnumerable<Score> scores);
    }
}
