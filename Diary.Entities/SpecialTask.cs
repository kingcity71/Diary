using Diary.Entities.Abstract;
using Diary.Entities.Enums;
using System;

namespace Diary.Entities
{
    public class SpecialTask : Entity
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public SpecialTaskType SpecialTaskType { get; set; }
    }
}
