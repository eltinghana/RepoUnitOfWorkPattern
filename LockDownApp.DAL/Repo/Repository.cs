using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.DAL.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public TEntity Find(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Count(predicate);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                {
                    Update(entity);
                }
        }


    }
}
