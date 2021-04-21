using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class SpecialTaskAnswer : Entity
    {
        public Guid SpecialTaskId { get; set; }
        public Guid StudentId { get; set; }
        public string Description { get; set; }
    }
}
