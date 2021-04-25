using Diary.Models;
using System;

namespace Diary.Interfaces
{
    public interface IParentService
    {
        void Update(ParentModel parentModel);
        ParentModel GetParentModel(string login);
        ParentModel GetParentModel(Guid id);
    }
}
