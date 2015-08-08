using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mentity.Abstraction
{
    /// <summary>
    /// Queryable container for <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity for the repo.</typeparam>
    public interface IRepo<TEntity> : IQueryable<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds given entity to the repo as new entity.
        /// </summary>
        /// <param name="entity">Entity to be added to the repo.</param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Attaches the given entity to the current context and repo.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Attach(TEntity entity);

        /// <summary>
        /// Returns the entity with given keys.
        /// </summary>
        /// <param name="keyValues">Keys to be searched for.</param>
        /// <returns>Entity with the given keys.</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// Removes the entity from repo.
        /// </summary>
        /// <param name="entity">Entity to be removed.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Includes related entities in the query with given path.
        /// </summary>
        /// <param name="path">Path of the related entity to be included.</param>
        /// <returns>Queryable set of entity.</returns>
        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> path);

        void SetState(TEntity entity, EntityState state);
    }
}
