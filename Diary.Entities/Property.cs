using Diary.Entities.Abstract;
using Diary.Entities.Enums;

namespace Diary.Entities
{
    public class Property : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public UserRole ForUserRole { get; set; }
        public bool Required { get; set; }
    }
}
