using Recipe.Application.Repositories;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Recipe.DataAccess.Repositories
{
    public abstract class EfGenericRepository<T> : IRepository<T> where T : Entity
    {
        protected FoodDbContext Context { get; }

        protected EfGenericRepository(FoodDbContext context) => Context = context;

        public virtual T Add(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = Context.Set<T>().Find(id);
            Delete(entity);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int perPage, int pageNumber)
            => Context.Set<T>().Where(predicate).Take(perPage).Skip((pageNumber - 1) * perPage);

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate) => Context.Set<T>().Where(predicate);

        public virtual T Get(int id) => Context.Set<T>().Find(id);

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
