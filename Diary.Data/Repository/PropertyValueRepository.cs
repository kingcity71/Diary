using Diary.Entities;
using Diary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Diary.Data.Repository
{
    public class PropertyValueRepository : BaseRepository<PropertyValue>, IPropertyValueRepository
    {
        public PropertyValueRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<PropertyValue> SearchByKey(string key)
        {
            using var ctx = new Context(_configuration);
            var entites = ctx.PropertyValues.AsNoTracking().Where(x => x.Value.ToLower().Contains(key.ToLower().Trim())).ToList();
            return entites;
        }
    }
}
