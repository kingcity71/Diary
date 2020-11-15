using Diary.Models;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IClassService
    {
        IEnumerable<ClassModel> GetClasses();
        ClassModel GetClassModel(Guid? id);
    }
}
