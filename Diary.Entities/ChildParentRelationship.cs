using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class ChildParentRelationship : Entity
    {
        public Guid ChildId { get; set; }
        public Guid ParentId { get; set; }
    }
}
