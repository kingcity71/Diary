using System;

namespace Diary.WebApp.Models
{
    public class LessonEditDto
    {
        public string teacherName{ get; set; }
        public Guid schedId { get; set; }
        public string date { get; set; }
        public Guid classId { get; set; }
        public Guid subjectId { get; set; }
        public Guid teacherId { get; set; }
    }
}
