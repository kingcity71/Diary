using System;

namespace Diary.WebApp.Models
{
    public class ScoreDTO
    {
        public Guid SchedId { get; set; }
        public string ScoreComment { get; set; }
        public Guid ScoreId { get; set; }
        public Guid StudentId { get; set; }
        public string ScoreType{ get; set; }
    }
}
