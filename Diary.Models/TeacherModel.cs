using System;

namespace Diary.Models
{
    public class TeacherModel : UserModel
    {
        public DateTime BirthDate { get; set; }
        public DateTime CareerStartDate { get; set; }
        public string EducationPlace { get; set; }
    }
}
