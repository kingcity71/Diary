using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Interfaces
{
    public interface IStudentService
    {
        StudentModel GetStudentModel(string login);
        StudentModel GetStudentModel(Guid id);
    }
}
