using Diary.Entities;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _repoSched;
        private readonly IRepository<Subject> _repoSubject;
        private readonly IRepository<ClassStudentRelationship> _repoClassStudentRelationship;
        private readonly ILessonFileRepository lessonFileRepository;
        private readonly IUserService _userService;
        private readonly IScoreService _scoreService;
        private readonly ISpecialTaskService specialTaskService;
        private readonly IClassService _classService;

        public ScheduleService(IRepository<Schedule> repoSched, IRepository<Subject> repoSubject,
            IRepository<ClassStudentRelationship> repoClassStudentRelationship, 
            ILessonFileRepository lessonFileRepository,
            IUserService userService, 
            IClassService classService,
            IScoreService scoreService,
            ISpecialTaskService specialTaskService)
        {
            _repoSched = repoSched;
            _repoSubject = repoSubject;
            _repoClassStudentRelationship = repoClassStudentRelationship;
            this.lessonFileRepository = lessonFileRepository;
            _userService = userService;
            _scoreService = scoreService;
            this.specialTaskService = specialTaskService;
            _classService = classService;
        }
        public void BindLessonWithFile(Guid scheduleId, Guid fileId)
        {
            lessonFileRepository.Create(new LessonFile
            {
                FileId = fileId,
                ScheduleId = scheduleId
            });
        }
        public IEnumerable<Guid> GetLessonFiles(Guid scheduleId)
            => lessonFileRepository.GetFileIdsBySchedueId(scheduleId);
        public IEnumerable<ScheduleModel> ScheduleSearch(DateTime date, Guid classId)
        {
            var models = _repoSched.GetAllItems()
                .Where(x => x.ClassId == classId && date.Date == x.Date.Date)
                .Select(GetScheduleModel)
                .ToList();
            return models;
        }
        
        public void DeleteSchedule(Guid id) => _repoSched.Delete(id);

        public ScheduleModel GetSchedule(Guid id)
        {
            var sched = _repoSched.GetItem(id);
            return GetScheduleModel(sched);
        }

        private ScheduleModel GetScheduleModel(Schedule sched)
        {
            if (sched == null) return null;
            var teacher = _userService.GetUser(sched.TeacherId);
            var classModel = _classService.GetClassModel(sched.ClassId);
            var subject = _repoSubject.GetItem(sched.SubjectId);

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
            var classId = _repoClassStudentRelationship.GetAllItems().FirstOrDefault(x => x.StudentId == entityId)?.ClassId;
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
            var scheduleEntity = Activator.CreateInstance<Schedule>();
            scheduleEntity.Id = model.Id;
            scheduleEntity.Date = model.Date;
            scheduleEntity.ClassId = model.Class.Id;
            scheduleEntity.TeacherId = model.Teacher.Id;
            scheduleEntity.SubjectId = _repoSubject.GetAllItems().FirstOrDefault(x => x.Name == model.Subject).Id;

            if (model.Id == Guid.Empty)
                _repoSched.Create(scheduleEntity);
            else
                _repoSched.Update(scheduleEntity);
        }

        public LessonModel GetLesson(Guid schedId)
        {
            var lessonModel = Activator.CreateInstance<LessonModel>();
            if (schedId == Guid.Empty) return lessonModel;

            lessonModel.ScheduleInfo = GetSchedule(schedId);
            lessonModel.Scores = _scoreService.GetScoreModels(schedId);
            lessonModel.Files = GetLessonFiles(schedId).ToArray();
            lessonModel.SpecialTasks = specialTaskService.GetSpecialTasks(schedId);

            return lessonModel;
        }
    }
}
