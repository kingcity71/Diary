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
        private readonly IMapper _mapper;

        public ClassService(IRepository<Class> repoClass, IRepository<ClassStudentRelationship> repoClassStudents,
            IRepository<User> userRepo, IPropertyValueService propValSer, IMapper mapper)
        {
            _repoClass = repoClass;
            _repoClassStudents = repoClassStudents;
            _userRepo = userRepo;
            _propValSer = propValSer;
            _mapper = mapper;
        }

        public IEnumerable<ClassModel> GetClasses()
        {
            var entities = _repoClass.GetAllItems();
            var models = entities.Select(entity => GetClassModel(entity))
                .OrderBy(x => x.FullName);
            return models;
        }

        private ClassModel GetClassModel(Class classEntity)
        {
            var classModel = _mapper.Map<Class, ClassModel>(classEntity);
            var studentIds = _repoClassStudents
                .GetAllItems()
                .Where(x => x.ClassId == classEntity.Id)
                .Select(x => x.StudentId)
                .ToList();

            foreach (var studentId in studentIds)
            {
                var student = GetUser(studentId);
                classModel.Students.Add(student);
            }

            return classModel;
        }
        public ClassModel GetClassModel(Guid? id)
        {
            if (id == null) return null;
            var classEntity = _repoClass.GetItem(id.Value);
            return GetClassModel(classEntity);
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
