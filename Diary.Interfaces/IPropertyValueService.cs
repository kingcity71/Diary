using Diary.Entities;
using System;
using System.Collections.Generic;

namespace Diary.Interfaces
{
    public interface IPropertyValueService
    {
        IDictionary<string,string> GetUserPropertyValues(Guid userId);
        void CreatePropertyValue(string propName, string value, Guid entityId);
    }
}
