using Mentity.Abstraction;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace Mentity.Concrete
{
    public sealed class DatabaseAdapter : IDatabase
    {
        private readonly Database _db;

        public DatabaseAdapter(Database database)
        {
            if (database == null) { throw new ArgumentNullException("database"); }

            _db = database;
        }

        public TimeSpan? CommandTimeout
        {
            get
            {
                if (_db.CommandTimeout == null) { return null; }
                return TimeSpan.FromMilliseconds((int)_db.CommandTimeout);
            }

            set
            {
                if (value == null) { _db.CommandTimeout = null; }
                else { _db.CommandTimeout = (int)value.Value.TotalMilliseconds; }
            }
        }

        public DbConnection Connection
        {
            get
            {
                return _db.Connection;
            }
        }

        public void Create()
        {
            _db.Create();
        }

        public void CreateIfNotExists()
        {
            _db.CreateIfNotExists();
        }

        public void Delete()
        {
            _db.Delete();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _db.ExecuteSqlCommand(sql, parameters);
        }

        public bool Exists()
        {
            return _db.Exists();
        }

        public void Initialize(bool force)
        {
            _db.Initialize(force);
        }

        public void UseTransaction(DbTransaction transaction)
        {
            _db.UseTransaction(transaction);
        }
    }
}
