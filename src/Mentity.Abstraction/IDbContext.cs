using System;

namespace Mentity.Abstraction
{
    /// <summary>
    /// Abstraction for <see cref="DbContext"/> in EF.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Gets the set of entity with given type.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity the set contains. </typeparam>
        /// <returns>Set of entityes with type <see cref="TEntity"/>.</returns>
        IRepo<TEntity> Repo<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets the database used by the context.
        /// </summary>
        IDatabase Database { get; }

        /// <summary>
        /// Saves the changes made to the current context.
        /// </summary>
        /// <returns>Number of changes made.</returns>
        int SaveChanges();
    }
}