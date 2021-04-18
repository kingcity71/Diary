using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class LessonFile : Entity
    {
        public Guid FileId { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
