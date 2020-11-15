using Diary.Entities;
using Diary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Services
{
    public class PropertyValueService : IPropertyValueService
    {
        private readonly IPropertyValueRepository _repoPropVal;
        private readonly IRepository<Property> _repoProps;
        public PropertyValueService(IPropertyValueRepository repoPropVal, IRepository<Property> repoProps)
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

        public IEnumerable<Guid> SearchUserIdByKey(string key)
        {
            var entities = _repoPropVal.SearchByKey(key);
            return entities?.Select(x => x.EntityId);
        }

        public void Update(Guid entityId, string propName, string value)
        {
            var prop = _repoProps.GetAllItems().FirstOrDefault(x => x.Name.IsEqualIgnoreCase(propName));
            var propValueEntity = _repoPropVal.GetAllItems().FirstOrDefault(x => x.PropertyId == prop.Id && x.EntityId == entityId);

            if(propValueEntity!=null)
            {
                propValueEntity.Value = value;
                _repoPropVal.Update(propValueEntity);
            }
            else
            {
                var propValue = new PropertyValue()
                {
                    Id = new Guid(),
                    EntityId = entityId,
                    PropertyId = prop.Id,
                    Value = value
                };
                _repoPropVal.Create(propValue);
            }
        }
    }
}
