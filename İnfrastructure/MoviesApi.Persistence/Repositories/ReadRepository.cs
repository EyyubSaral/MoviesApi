using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MoviesApi.Application.Interfaces.Repositories;
using MoviesApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase,new()
    {

        private readonly DbContext dbContext;
        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enabelTracking = false)
        {
          IQueryable<T> queryable = Table;
            if(!enabelTracking) queryable=queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if(predicate is not null) queryable=queryable.Where(predicate);
            if(orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }


        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enabelTracking = false, int currentPage = 1, int pageSiz = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enabelTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage-1)*pageSiz).Take(pageSiz).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSiz).Take(pageSiz).ToListAsync();
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enabelTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enabelTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
         
            //  queryable.Where(predicate);
            
             return await queryable.FirstOrDefaultAsync(predicate);
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking=false)
        {
           if(!enableTracking) Table.AsNoTracking();
           return  Table.Where(predicate);
        }

       

        

       
    }
}
