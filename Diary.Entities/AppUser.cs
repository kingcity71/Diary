using Diary.Entities.Abstract;
using Diary.Entities.Enums;

namespace Diary.Entities
{
    public class AppUser : User
    {
        public UserType UserType { get; set; }
    }
}
