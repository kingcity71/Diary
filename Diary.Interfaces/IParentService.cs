using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface IParentService
    {
        ParentModel GetParentModel(string login);
        ParentModel GetParentModel(Guid id);
    }
}
