using Diary.Models.Abstract;
using System;
using Diary.Models.Enums;

namespace Diary.Models
{
    public class ScoreModel : EntityModel
    {
        public ScoreResult ScoreResult { get; set; }
        public string Comment { get; set; }
        public Guid ScheduleId { get; set; }
        public UserModel StudentModel { get; set; }
    }
}
