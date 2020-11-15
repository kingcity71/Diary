using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Models
{
    public class LessonEditModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Guid ClassId { get; set; }

        public IDictionary<Guid, string> Classes { get; set; }
        public IDictionary<Guid, string> Subjects { get; set; }
    }
}
