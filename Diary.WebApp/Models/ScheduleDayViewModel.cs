using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.WebApp.Models
{
    public class ScheduleDayViewModel
    {
        public IEnumerable<ScheduleModel> ScheduleModels { get; set; }
        public DateTime Date { get; set; }
    }
}
