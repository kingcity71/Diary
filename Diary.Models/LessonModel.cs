using System;
using System.Collections.Generic;

namespace Diary.Models
{
    public class LessonModel
    {
        public ScheduleModel ScheduleInfo { get; set; }
        public IEnumerable<ScoreModel> Scores { get; set; }
        public Guid[] Files { get; set; } = Array.Empty<Guid>();
    }
}
