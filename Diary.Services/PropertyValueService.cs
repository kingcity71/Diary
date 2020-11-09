using Diary.Entities;
using Diary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Services
{
    public class PropertyValueService : IPropertyValueService
    {
        private readonly IRepository<PropertyValue> _repoPropVal;
        private readonly IRepository<Property> _repoProps;
        public PropertyValueService(IRepository<PropertyValue> repoPropVal, IRepository<Property> repoProps)
        {
            _repoPropVal = repoPropVal;
            _repoProps = repoProps;
        }
        public IDictionary<string,string> GetUserPropertyValues(Guid userId)
        {
            var dictionary = new Dictionary<string, string>();
            var userPropValues = _repoPropVal.GetAllItems().Where(x => x.EntityId == userId);
            foreach(var userPropValue in userPropValues)
            {
                var prop = _repoProps.GetItem(userPropValue.PropertyId);
                dictionary.Add(prop.Name, userPropValue.Value);
            }
            return dictionary;
        }
        public void CreatePropertyValue(string propName, string value, Guid entityId)
        {
            var prop = _repoProps.GetAllItems().FirstOrDefault(x => x.Name == propName);
            var propValue = Activator.CreateInstance<PropertyValue>();
            propValue.EntityId = entityId;
            propValue.PropertyId = prop.Id;
            propValue.Id = new Guid();
            propValue.Value = value;
            _repoPropVal.Create(propValue);
        }
    }
}
