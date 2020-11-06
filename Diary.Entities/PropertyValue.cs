using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class PropertyValue : Entity
    {
        public string Value { get; set; }
        public Guid PropertyId { get; set; }
        public Guid EntityId { get; set; }
    }
}
