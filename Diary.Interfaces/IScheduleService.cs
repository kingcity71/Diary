using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleModel> ScheduleSearch(DateTime date, Guid classId);
        LessonModel GetLesson(Guid schedId);
        IEnumerable<ScheduleModel> GetSchedulesByDay(DateTime day, string role, Guid? entityId = null, Guid? childId = null);
        ScheduleModel GetSchedule(Guid id);
     
        void UpdateSchedule(ScheduleModel model);
        void DeleteSchedule(ScheduleModel model);
    }
}
