using System;
using System.Linq.Expressions;

namespace Recipe.Application.Queries
{
    public interface IQuery<T>
    {
        Expression<Func<T, bool>> AsQuery { get; }
    }
}
