using Diary.Models.Abstract;
using System;

namespace Diary.Models
{
    public class ScheduleModel : EntityModel
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public UserModel Teacher{ get; set; }
        public ClassModel Class{ get; set; }
    }
}
