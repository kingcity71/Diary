using System;
using System.Collections.Generic;
using System.Linq;
using Diary.Entities.Abstract;
using Diary.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Diary.Data.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        readonly IConfiguration _configuration;
        
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Create(T item)
        {
            using var ctx = new Context(_configuration);
            ctx.Add(item);
            ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            using var ctx = new Context(_configuration);
            var item = ctx.Find<T>(id);
            ctx.Remove(item);
            ctx.SaveChanges();
        }

        public IEnumerable<T> GetAllItems()
        {
            using var ctx = new Context(_configuration);
            return ctx.Set<T>().ToList();

        }

        public T GetItem(Guid id)
        {
            using var ctx = new Context(_configuration);
            return ctx.Find<T>(id);
        }

        public void Update(T item)
        {
            using var ctx = new Context(_configuration);
            ctx.Update(item);
            ctx.SaveChanges();
        }
    }
}