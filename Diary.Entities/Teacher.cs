using Diary.Entities.Abstract;
using System;

namespace Diary.Entities
{
    public class Teacher : User
    {
        public DateTime CareerStartDate { get; set; }
        public string EducationPlace { get; set; }
    }
}
