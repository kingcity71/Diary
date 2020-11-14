using Diary.Entities.Abstract;
using Diary.Entities.Enums;
using System;

namespace Diary.Entities
{
    public class Score : Entity
    {
        public ScoreResult ScoreResult { get; set; }
        public string Comment { get; set; }
        public Guid ScheduleId { get; set; }
        public Guid StudentId { get; set; }
    }
}