using EMS.Core.Infra.Data;
using NHibernate;
using System;
using System.Data;

namespace EMS.Infra.Data.NH
{
    /// <summary>
    /// Implements Unit of work for NHibernate.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets Nhibernate session object to perform queries.
        /// </summary>
        private ISession _session;

        public ISession CurrentSession { get { return _session; } }

        /// <summary>
        /// Reference to the currently running transcation.
        /// </summary>
        private ITransaction _transaction;

        ///// <summary>
        ///// Creates a new instance of NhUnitOfWork.
        ///// </summary>
        ///// <param name="sessionFactory"></param>
        public UnitOfWork()
        {
            OpenSession();
        }

        /// <summary>
        /// OpenSession if not connected 
        /// </summary>
        public void OpenSession()
        {
            if (_session == null || !_session.IsConnected)
            {
                if (_session != null)
                    _session.Dispose();
                _session = NHSessionFactorySingleton.SessionFactory.OpenSession();
                //_session.FlushMode = FlushMode.Auto;
                //_session.CacheMode = CacheMode.Normal;
            }
        }

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transaction == null || !_transaction.IsActive)
            {
                if (_transaction != null)
                    _transaction.Dispose();

                _transaction = _session.BeginTransaction(isolationLevel);
            }
        }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Dispose();
            }
        }

        #region Dispose

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_session != null)
            {
                _session.Flush();
                _session.Close();
                _session.Dispose();
                _session = null;
            }
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
