using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface ITeacherService
    {
        TeacherModel GetTeacherModel(string login);
        TeacherModel GetTeacherModel(Guid id);
    }
}
