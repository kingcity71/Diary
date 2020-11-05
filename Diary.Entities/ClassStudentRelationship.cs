using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class ClassStudentRelationship : Entity
    {
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
    }
}
