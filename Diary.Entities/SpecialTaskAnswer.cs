using Diary.Entities.Abstract;
using Diary.Entities.Enums;
using System;

namespace Diary.Entities
{
    public class SpecialTaskAnswer : Entity
    {
        public Guid SpecialTaskId { get; set; }
        public Guid StudentId { get; set; }
        public string Description { get; set; }
        public Guid FileId { get; set; }
        public ScoreResult ScoreResult { get; set; }
        public Guid TeacherId { get; set; }
        public string Comment { get; set; }
    }
}
