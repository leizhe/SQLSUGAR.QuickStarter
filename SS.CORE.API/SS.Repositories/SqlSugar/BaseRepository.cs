using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using SqlSugar;
using SS.Domain.Repositories;

namespace SS.Repositories.SqlSugar
{
    public class BaseRepository<T> : IRepository<T>  where T : class, new()
    {
        
        public SqlSugarClient DB { get; set; }

        public BaseRepository(DBService server)
        {
            DB = server.DB;
        }

        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return DB.Queryable<T>().First(exp);
        }

        public ISugarQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public ISugarQueryable<T> Find(Expression<Func<T, bool>> expression, Expression<Func<T, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber,
                    "pageNumber must great than or equal to 1.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "pageSize must great than or equal to 1.");

            var query = DB.Queryable<T>().Where(expression);
            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            if (sortPredicate == null)
                throw new InvalidOperationException(
                    "Based on the paging query must specify sorting fields and sort order.");

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedAscending = query.OrderBy(sortPredicate).Skip(skip).Take(take);

                    return pagedAscending;
                case SortOrder.Descending:
                    var pagedDescending = query.OrderBy(sortPredicate, OrderByType.Desc).Skip(skip).Take(take);
                    return pagedDescending;
            }

            throw new InvalidOperationException(
                "Based on the paging query must specify sorting fields and sort order.");
        }

        public int Count(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public long Add(T entity)
        {
            return DB.Insertable(entity).ExecuteReturnBigIdentity();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DB.Insertable(entities.ToArray()).ExecuteCommand();
        }

        public void Update(T entity)
        {
            DB.Updateable(entity).Where(true).ExecuteCommand();
        }

        public void Update(IEnumerable<T> entities)
        {
            DB.Updateable(entities.ToArray()).Where(true).ExecuteCommand();
        }
        public void Update(Expression<Func<T, bool>> filterExpression, T entity)
        {
            DB.Updateable(entity).Where(true).Where(filterExpression).ExecuteCommand();
        }

        public void Delete(T entity)
        {
            DB.Deleteable(entity).ExecuteCommand();
        }

        public void Delete(Expression<Func<T, bool>> exp)
        {
            DB.Deleteable(exp).ExecuteCommand();
        }

        private ISugarQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = DB.Queryable<T>();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }


      
    }
}
