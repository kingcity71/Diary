using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public class StudentModel : UserModel
    {
        public ClassModel ClassModel { get; set; }
        public IEnumerable<UserModel> Parents { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
