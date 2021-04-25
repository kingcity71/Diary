using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Interfaces
{
    public interface IScoreService
    {
        IEnumerable<ScoreModel> GetScoreModels(Guid schedId);
        void Update(IEnumerable<ScoreModel> scores);
    }
}
