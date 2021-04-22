using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Diary.Entities.Abstract;
using Diary.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Diary.Data.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        readonly protected IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public virtual void Create(T item)
        {
            using var ctx = new Context(_configuration);
            ctx.Add(item);
            ctx.SaveChanges();
        }
        public T GetItem(Expression<Func<T, bool>> expression)
        {
            using var ctx = new Context(_configuration);
            var res = ctx.Set<T>().FirstOrDefault(expression);
            return res;
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
        public IEnumerable<T> GetAllItems(Expression<Func<T, bool>> expression)
        {
            using var ctx = new Context(_configuration);
            var res = ctx.Set<T>().Where(expression).ToList();
            return res;
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