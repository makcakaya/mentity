using Mentity.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Mentity.Concrete
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        private readonly ContextBase _context;
        private readonly IDbSet<TEntity> _set;

        public Repo(ContextBase context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }

            _context = context;
            _set = context.Set<TEntity>();
        }

        public Type ElementType
        {
            get
            {
                return _set.ElementType;
            }
        }

        public Expression Expression
        {
            get
            {
                return _set.Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _set.Provider;
            }
        }

        public TEntity Add(TEntity entity)
        {
            return _set.Add(entity);
        }

        public TEntity Attach(TEntity entity)
        {
            return _set.Attach(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _set.Find(keyValues);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> path)
        {
            return _set.Include(path);
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void SetState(TEntity entity, Mentity.Abstraction.EntityState state)
        {
            _context.Entry<TEntity>(entity).State = (System.Data.Entity.EntityState)(int)state;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }
    }
}
