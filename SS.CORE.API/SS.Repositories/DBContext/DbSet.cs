using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SqlSugar;
using SS.Domain.Repositories;

namespace SS.Repositories.DBContext
{
    public class DbSet<T>: SimpleClient<T>, IRepository<T> where T:class ,new ()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {
        }
        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return Context.Queryable<T>().First(exp);
        }

        public ISugarQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public ISugarQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "pageNumber must great than or equal to 1.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "pageSize must great than or equal to 1.");

            var query = DbContext.Set<TEntity>().Where(expression);
            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            if (sortPredicate == null)
                throw new InvalidOperationException("Based on the paging query must specify sorting fields and sort order.");

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedAscending = query.SortBy(sortPredicate).Skip(skip).Take(take);

                    return pagedAscending;
                case SortOrder.Descending:
                    var pagedDescending = query.SortByDescending(sortPredicate).Skip(skip).Take(take);
                    return pagedDescending;
            }

            throw new InvalidOperationException("Based on the paging query must specify sorting fields and sort order.");
        }

        public int Count(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public void Add(T entity)
        {
            Context.Insertable(entity).ExecuteReturnBigIdentity();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Insertable(entities.ToArray()).ExecuteCommand();
        }

        public new void Update(T entity)
        {
            Context.Updateable(entity).ExecuteCommand();
        }

        public void Update(IEnumerable<T> entities)
        {

        };

        public void Delete(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(ICollection<T> entityCollection)
        {
            if (entityCollection.Count == 0)
                return;

            DbContext.Set<TEntity>().Attach(entityCollection.First());
            DbContext.Set<TEntity>().RemoveRange(entityCollection);
        }

        private ISugarQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Queryable<T>();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }

    

    }
}
