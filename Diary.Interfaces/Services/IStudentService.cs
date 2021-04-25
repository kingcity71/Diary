using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface IStudentService
    {
        void Update(StudentModel studentModel); 
        StudentModel GetStudentModel(string login);
        StudentModel GetStudentModel(Guid id);
    }
}
