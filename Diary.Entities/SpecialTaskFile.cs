using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class SpecialTaskFile : Entity
    {
        public Guid FileId { get; set; }
        public Guid SpecialTaskId { get; set; }
    }
}
