using Diary.Models.Abstract;
using Diary.Models.Enums;
using System;

namespace Diary.Models
{
    public class SpecialTaskAnswer : EntityModel
    {
        public Guid SpecialTaskId { get; set; }
        public Guid StudentId { get; set; }
        public string Description { get; set; }
        public Guid[] Files { get; set; } = Array.Empty<Guid>();
        public ScoreResult ScoreResult { get; set; }
        public Guid TeacherId { get; set; }
        public string Comment { get; set; }
    }
}
