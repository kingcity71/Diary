using Diary.Models.Abstract;
using System;

namespace Diary.Models
{
    public class UserModel : EntityModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
