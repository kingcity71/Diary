using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Interfaces
{
    public interface IClassService
    {
        ClassModel GetClassModel(Guid? id);
    }
}
