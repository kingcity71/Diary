using System.Collections.Generic;

namespace Diary.Models
{
    public class LessonModel
    {
        public ScheduleModel ScheduleInfo { get; set; }
        public IEnumerable<ScoreModel> Scores { get; set; }
    }
}
