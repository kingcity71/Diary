using Diary.Entities.Abstract;
using Diary.Entities.Enums;
using System;

namespace Diary.Entities
{
    public class SpecialTaskAnswerScore : Entity
    {
        public ScoreResult ScoreResult{ get; set; }
        public Guid TeacherId { get; set; }
        public string Comment { get; set; }
    }
}
