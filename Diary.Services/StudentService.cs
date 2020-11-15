using Diary.Models;
using System;
using System.Linq;

namespace Diary.Services
{
    public partial class UserService
    {
        public void Update(StudentModel studentModel)
        {
            var id = studentModel.Id;
            _propertyValueService.Update(id, "StudentBirthDate", studentModel.BirthDate.ToString());
            _propertyValueService.Update(id, "StudentName", studentModel.Name);

            var parent1id = studentModel.Parents.FirstOrDefault()?.Id;
            var parent2id = studentModel.Parents.LastOrDefault()?.Id;
            var parentIds = new[] { parent1id??Guid.Empty, parent2id ?? Guid.Empty };


            var classId = studentModel.ClassModel.Id;

            var parentRefs = _childParentsRepo.GetAllItems()
                .Where(x => x.ChildId == id)
                .ToList();
            
            foreach(var parentRef in parentRefs)
                if (!parentIds.Contains(parentRef.ParentId))
                    _childParentsRepo.Delete(parentRef.Id);

            parentRefs = _childParentsRepo.GetAllItems()
                .Where(x => x.ChildId == id)
                .ToList();

            foreach (var parentId in parentIds.Where(x => x != Guid.Empty))
                if (!parentRefs.Select(x => x.ParentId).ToList().Contains(parentId))
                    _childParentsRepo.Create(new Entities.ChildParentRelationship() { Id = new Guid(), ChildId = id, ParentId = parentId });

            var classRef = _classStudRepo.GetAllItems().FirstOrDefault(x => x.StudentId == id);
            if (classRef == null)
            {
                _classStudRepo.Create(new Entities.ClassStudentRelationship() { Id = new Guid(), ClassId = studentModel.Id, StudentId = id });
            }
            if(classRef!=null && classRef.ClassId != classId)
            {
                classRef.ClassId = classId;
                _classStudRepo.Update(classRef);
            }
        }
        private StudentModel GetStudentModel(UserModel userModel)
        {
            var studentModel = _mapper.Map<UserModel, StudentModel>(userModel);
            
            var classId = _classStudRepo.GetAllItems().FirstOrDefault(x => x.StudentId == studentModel.Id)?.ClassId;
            var parentIds = _childParentsRepo.GetAllItems().Where(x => x.ChildId == studentModel.Id).Select(x => x.ParentId).ToList();

            var values = _propertyValueService.GetUserPropertyValues(studentModel.Id);

            studentModel.BirthDate = GetDate(values, "StudentBirthDate");
            studentModel.ClassModel = _classService.GetClassModel(classId);
            studentModel.Parents = parentIds?.Select(id => GetUser(id)).ToList();

            return studentModel;
        }
        public StudentModel GetStudentModel(string login)
        {
            var userModel = GetUser(login);
            return GetStudentModel(userModel);            
        }
        public StudentModel GetStudentModel(Guid id)
        {
            var userModel = GetUser(id);
            return GetStudentModel(userModel);
        }
    }
}
