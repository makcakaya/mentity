using System;
using System.Data.Common;

namespace Mentity.Abstraction
{
    public interface IDatabase
    {
        /// <summary>
        /// Sets or gets the timeout for command processing.
        /// </summary>
        TimeSpan? CommandTimeout { get; set; }

        /// <summary>
        /// Gets connection properties of the database.
        /// </summary>
        DbConnection Connection { get; }

        /// <summary>
        /// Creates the database.
        /// </summary>
        void Create();

        /// <summary>
        /// Creates the database if it doesn't already exist.
        /// </summary>
        void CreateIfNotExists();

        /// <summary>
        /// Deletes the database.
        /// </summary>
        void Delete();

        /// <summary>
        /// Executes the Sql command with given parameters.
        /// </summary>
        /// <param name="sql">Sql command to be executed.</param>
        /// <param name="parameters">Parameters for the Sql command.</param>
        /// <returns>Number of rows affected.</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Returns true if the database exists, false otherwise.
        /// </summary>
        /// <returns></returns>
        bool Exists();

        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="force">Forces the database to initialize even if it is initialized.</param>
        void Initialize(bool force);

        /// <summary>
        /// Makes the database use given transaction instead of its own.
        /// </summary>
        /// <param name="transaction">Transaction to be used.</param>
        void UseTransaction(DbTransaction transaction);
    }
}
