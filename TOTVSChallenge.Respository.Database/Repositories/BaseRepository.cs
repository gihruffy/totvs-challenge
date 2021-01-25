using Microsoft.EntityFrameworkCore;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TOTVSChallenge.Respository.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T, int> where T : EntityBase
    {
        public readonly DbContext Context;
        public readonly DbSet<T> DbSet;


        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual T Save(T entity)
        {
            if (entity.IsNew)
                DbSet.Add(entity);
            else
                DbSet.Update(entity);

            return entity;
        }

        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                var query = Context.Set<T>().Where(predicate);

                return await query.ToListAsync();
            }

            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Object id)
        {
            return await Context.Set<T>().FindAsync(id);
        }


        public virtual async Task DeleteAsync(int identifier)
        {
            var ett = await NoTracking().FirstOrDefaultAsync(x => x.Id == identifier);

            DbSet.Remove(ett);
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                var query = Context.Set<T>().Where(predicate);
                var ett = await query.FirstOrDefaultAsync();
                DbSet.Remove(ett);
            }
        }

        public virtual IQueryable<T> NoTracking()
        {
            return DbSet.AsNoTracking();
        }
    }
}
