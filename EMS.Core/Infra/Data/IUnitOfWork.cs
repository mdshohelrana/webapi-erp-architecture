using System;
using System.Data;
using NHibernate;

namespace EMS.Core.Infra.Data
{
    /// <summary>
    /// Represents a transactional job.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Current Session Container
        /// </summary>
        ISession CurrentSession { get; }

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        void Rollback();
    }
}