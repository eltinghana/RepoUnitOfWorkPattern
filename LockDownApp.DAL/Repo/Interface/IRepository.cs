using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LockDownApp.DAL.Repo.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get one object from context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find(int? id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get all Records on <see cref="TEntity"/>
        /// </summary>
        /// <returns>This returns a List of <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Find records by an expression
        /// </summary>
        /// <param name="predicate">Expression to find records</param>
        /// <returns>Returns a list of <see cref="TEntity"/></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add a new object of type <see cref="TEntity"/> to database
        /// </summary>
        /// <param name="entity">The new object of type<see cref="TEntity"/></param>
        void Add(TEntity entity);

        /// <summary>
        /// Add a new list of objects of type <see cref="TEntity"/> to database
        /// </summary>
        /// <param name="entities">New List of objects of type <see cref="TEntity"/></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete an object of type <see cref="TEntity"/> from database
        /// </summary>
        /// <param name="entity">Object to delete from database of type <see cref="TEntity"/></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Delete a list of objects of type <see cref="TEntity"/> from database
        /// </summary>
        /// <param name="entities">List of objects of type <see cref="TEntity"/> to delete from database</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);


    }
}
