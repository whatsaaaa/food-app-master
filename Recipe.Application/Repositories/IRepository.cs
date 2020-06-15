using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Recipe.Application.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int perPage, int pageNumber);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T Get(int id);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);
    }
}
