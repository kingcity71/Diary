using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllItems();
        T GetItem(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
