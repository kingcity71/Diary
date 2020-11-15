using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IClassService
    {
        void Update(ClassModel classModel);
        IEnumerable<ClassModel> GetClasses();
        ClassModel GetClassModel(Guid? id);
    }
}
