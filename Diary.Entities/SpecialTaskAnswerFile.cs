using Diary.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Entities
{
    public class SpecialTaskAnswerFile : Entity
    {
        public Guid SpecialTaskAnswerId { get; set; }
        public Guid FileId { get; set; }
    }
}
