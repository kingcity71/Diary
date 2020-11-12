using Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diary.Services
{
    public partial class UserService
    {

        private StudentModel GetStudentModel(UserModel userModel)
        {
            var studentModel = Map<UserModel, StudentModel>(userModel);
            //var studentModel = new StudentModel { Id = userModel.Id, Name = userModel.Name, Login = userModel.Login, Role = userModel.Role };


            var classId = _classStudRepo.GetAllItems().FirstOrDefault(x => x.StudentId == studentModel.Id)?.ClassId;
            var parentIds = _childParentsRepo.GetAllItems().Where(x => x.ChildId == studentModel.Id).Select(x => x.ParentId).ToList();

            var values = _propertyValueService.GetUserPropertyValues(studentModel.Id);

            studentModel.BirthDate = GetDate(values, "StudentBirthDate");
            studentModel.ClassModel = _classService.GetClassModel(classId);
            studentModel.Parents = parentIds != null ? parentIds.Select(id => GetUser(id)).ToList() : null;

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
