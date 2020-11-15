using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.WebApp.Models
{
    public class ScheduleDayViewModel
    {
        public Guid ClassId { get; set; }
        public IEnumerable<ScheduleModel> ScheduleModels { get; set; }
        public DateTime Date { get; set; }
    }
}
