using Mentity.Abstraction;
using System.Data.Entity;

namespace Mentity.Concrete
{
    public abstract class ContextBase : DbContext, IDbContext
    {
        private DatabaseAdapter _dbAdapter = null;

        public ContextBase() : base()
        {

        }

        public ContextBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        IDatabase IDbContext.Database
        {
            get
            {
                if (_dbAdapter == null)
                {
                    _dbAdapter = new DatabaseAdapter(Database);
                }

                return _dbAdapter;
            }
        }

        public IRepo<TEntity> Repo<TEntity>() where TEntity : class
        {
            return new Repo<TEntity>(this);
        }
    }
}
