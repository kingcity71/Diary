using Diary.Entities;
using Diary.Interfaces;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diary.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repoClass;
        private readonly IRepository<ClassStudentRelationship> _repoClassStudents;
        private readonly IRepository<User> _userRepo;
        private readonly IPropertyValueService _propValSer;

        public ClassService(IRepository<Class> repoClass, IRepository<ClassStudentRelationship> repoClassStudents,
            IRepository<User> userRepo, IPropertyValueService propValSer)
        {
            _repoClass = repoClass;
            _repoClassStudents = repoClassStudents;
            _userRepo = userRepo;
            _propValSer = propValSer;
        }
        public ClassModel GetClassModel(Guid? id)
        {
            if (id == null) return null;
            var classEntity = _repoClass.GetItem(id.Value);
            var classModel = Activator.CreateInstance<ClassModel>();
            var studentIds = _repoClassStudents
                .GetAllItems()
                .Where(x => x.ClassId == id)
                .Select(x => x.StudentId)
                .ToList();

            classModel.Id = id.Value;
            classModel.Letter = classEntity.Letter;
            classModel.Number = classEntity.Number;

            foreach (var studentId in studentIds)
            {
                var student = GetUser(studentId);
                classModel.Students.Add(student);
            }

            return classModel;
        }

        private UserModel GetUser(Guid id)
        {
            var entity = _userRepo.GetItem(id);
            var entityValues = _propValSer.GetUserPropertyValues(entity.Id);

            var propName = $"{entity.UserRole.ToString()}Name";
            var name = entityValues.ContainsKey(propName) ? entityValues[propName] : string.Empty;

            return new UserModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Role = entity.UserRole.ToString(),
                Name = name
            };
        }

       
    }
}
