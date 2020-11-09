using Diary.Entities.Abstract;
using Diary.Entities.Enums;

namespace Diary.Entities
{
    public class User : Entity
    {
        public string Login{ get; set; }
        public UserRole UserRole { get; set; }
    }
}
