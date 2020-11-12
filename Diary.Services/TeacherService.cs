using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Services
{
    public partial class UserService 
    {
        TeacherModel GetTeacherModel(UserModel userModel)
        {
            var model = Map<UserModel, TeacherModel>(userModel);
            var values = _propertyValueService.GetUserPropertyValues(userModel.Id);

            model.BirthDate = GetDate(values, "TeacherBirthDate");
            model.CareerStartDate = GetDate(values, "TeacherCareerStartDate");
            model.EducationPlace = GetString(values, "TeacherEducationPlace");

            return model;
        }
        public TeacherModel GetTeacherModel(string login)
        {
            var userModel = GetUser(login);
            return GetTeacherModel(userModel);
        }
        public TeacherModel GetTeacherModel(Guid id)
        {
            var userModel = GetUser(id);
            return GetTeacherModel(userModel);
        }
    }
}
