using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using SS.Domain.Auditing;

namespace SS.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> exp = null);
        ISugarQueryable<T> Find(Expression<Func<T, bool>> exp = null);
        ISugarQueryable<T> Find(Expression<Func<T, bool>> expression, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
        int Count(Expression<Func<T, bool>> exp = null);
        long Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Update(Expression<Func<T, bool>> filterExpression, T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> filterExpression);


    }
}
