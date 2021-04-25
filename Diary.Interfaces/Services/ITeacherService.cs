using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface ITeacherService
    {
        void Update(TeacherModel teacherModel);
        TeacherModel GetTeacherModel(string login);
        TeacherModel GetTeacherModel(Guid id);
    }
}
