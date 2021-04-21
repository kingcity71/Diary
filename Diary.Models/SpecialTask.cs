using Diary.Models.Abstract;
using Diary.Models.Enums;
using System;

namespace Diary.Models
{
    public class SpecialTask : EntityModel
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public SpecialTaskType SpecialTaskType { get; set; }
        public Guid FileId { get; set; }
    }
}