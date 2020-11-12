using System;
using System.Collections.Generic;

namespace Diary.Models
{
    public class ParentModel : UserModel
    {
        public DateTime BirthDate { get; set; }
        public Dictionary<Guid,string> Children { get; set; }
    }
}