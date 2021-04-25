using Diary.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diary.Interfaces
{
    public interface IPropertyValueService
    {
        void Update(Guid entityId, string propName, string value);
        IEnumerable<Guid> SearchUserIdByKey(string key);
        IDictionary<string,string> GetUserPropertyValues(Guid userId);
        void CreatePropertyValue(string propName, string value, Guid entityId);
    }
}
