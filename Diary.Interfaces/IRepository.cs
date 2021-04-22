using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Diary.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllItems();
        IEnumerable<T> GetAllItems(Expression<Func<T, bool>> expression);
        T GetItem(Guid id);
        T GetItem(Expression<Func<T, bool>> expression);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
