using System;

namespace Diary.Entities.Abstract
{
    public abstract class User : Entity
    {
        public string Login{ get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
