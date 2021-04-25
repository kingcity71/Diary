using Diary.Entities;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IPropertyValueRepository : IRepository<PropertyValue>
    {
        IEnumerable<PropertyValue> SearchByKey(string key);
    }
}
