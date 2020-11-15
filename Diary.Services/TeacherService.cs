using Diary.Models;
using System;

namespace Diary.Services
{
    public partial class UserService 
    {
        public void Update(TeacherModel teacherModel)
        {
            var id = teacherModel.Id;
            _propertyValueService.Update(id, "TeacherCareerStartDate", teacherModel.CareerStartDate.ToString());
            _propertyValueService.Update(id, "TeacherEducationPlace", teacherModel.EducationPlace.ToString());
            _propertyValueService.Update(id, "TeacherBirthDate", teacherModel.BirthDate.ToString());
            _propertyValueService.Update(id, "TeacherName", teacherModel.Name);
        }
        TeacherModel GetTeacherModel(UserModel userModel)
        {
            var model = _mapper.Map<UserModel, TeacherModel>(userModel);
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
