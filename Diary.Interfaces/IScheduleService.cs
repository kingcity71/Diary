using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IScheduleService
    {
        void BindLessonWithFile(Guid scheduleId, Guid fileId);
        IEnumerable<Guid> GetLessonFiles(Guid scheduleId);
        IEnumerable<ScheduleModel> ScheduleSearch(DateTime date, Guid classId);
        LessonModel GetLesson(Guid schedId);
        IEnumerable<ScheduleModel> GetSchedulesByDay(DateTime day, string role, Guid? entityId = null, Guid? childId = null);
        ScheduleModel GetSchedule(Guid id);
     
        void UpdateSchedule(ScheduleModel model);
        void DeleteSchedule(Guid id);
    }
}
