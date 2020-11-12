using Diary.Entities;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diary.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _repoSched;
        private readonly IRepository<Subject> _repoSubject;
        private readonly IRepository<ClassStudentRelationship> _repoClassStudentRelationship;
        private readonly IUserService _userService;
        private readonly IClassService _classService;

        public ScheduleService(IRepository<Schedule> repoSched, IRepository<Subject> repoSubject, IRepository<ClassStudentRelationship> repoClassStudentRelationship, IUserService userService, IClassService classService)
        {
            _repoSched = repoSched;
            _repoSubject = repoSubject;
            _repoClassStudentRelationship = repoClassStudentRelationship;

            _userService = userService;
            _classService = classService;
        }
        public void CreateSchedule(ScheduleModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchedule(ScheduleModel model)
        {
            throw new NotImplementedException();
        }

        public ScheduleModel GetSchedule(Guid id)
        {
            var sched = _repoSched.GetItem(id);
            return GetScheduleModel(sched);
        }

        private ScheduleModel GetScheduleModel(Schedule sched)
        {
            if (sched == null) return null;
            var teacher = _userService.GetUser(sched.Id);
            var classModel = _classService.GetClassModel(sched.ClassId);
            var subject = _repoSubject.GetItem(sched.Id);

            var schedModel = Activator.CreateInstance<ScheduleModel>();
            schedModel.Id = sched.Id;
            schedModel.Date = sched.Date;
            schedModel.Teacher = teacher;
            schedModel.Subject = subject.Name;
            schedModel.Class = classModel;

            return schedModel;
        }

        private IEnumerable<ScheduleModel> GetStudentScheduleByDay(DateTime day, Guid entityId)
        {
            var classId = _repoClassStudentRelationship.GetAllItems().FirstOrDefault(x => x.StudentId == entityId)?.StudentId;
            if (classId == null) return null;

            var schedules = _repoSched.GetAllItems()
                .Where(x => x.ClassId == classId && x.Date.Date == day.Date)
                .Select(GetScheduleModel)
                .OrderBy(x => x.Date).ToList();

            return schedules;
        }

        private IEnumerable<ScheduleModel> GetTeacherScheduleByDay(DateTime day, Guid entityId)
        {
            var schedules = _repoSched.GetAllItems()
                .Where(x => x.TeacherId == entityId && x.Date.Date == day.Date)
                .Select(GetScheduleModel)
                .OrderBy(x => x.Date).ToList();

            return schedules;
        }

        private IEnumerable<ScheduleModel> GetParentOfChildScheduleByDay(DateTime day, Guid childId)
            => GetStudentScheduleByDay(day, childId);

        private IEnumerable<ScheduleModel> GetAllSchedulesByDay(DateTime day)
            => _repoSched.GetAllItems()
            .Where(x => x.Date.Date == day.Date)
            .Select(GetScheduleModel)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Class.FullName)
            .ToList();
        

        public IEnumerable<ScheduleModel> GetSchedulesByDay(DateTime day, string role, Guid? entityId = null, Guid? childId = null)
        {
            switch (role)
            {
                case "Student":
                    return GetStudentScheduleByDay(day, entityId.Value);
                case "Parent":
                    return GetParentOfChildScheduleByDay(day,  childId.Value);
                case "Teacher":
                    return GetTeacherScheduleByDay(day, entityId.Value);
                case "Admin":
                    return GetAllSchedulesByDay(day);
                default:
                    return null;
            }
        }

        public void UpdateSchedule(ScheduleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
