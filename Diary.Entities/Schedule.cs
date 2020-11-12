using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class Schedule : Entity
    {
        public DateTime Date { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ClassId { get; set; }
    }
}
