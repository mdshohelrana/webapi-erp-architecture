using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using EMS.Core.Domain.Specification;
using EMS.Core.Infra.Data;

namespace EMS.Infra.Repository.NH
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets the NHibernate session object to perform database operations.
        /// </summary>
        protected ISession _session { get { return _unitOfWork.CurrentSession; } }

        #region Constructor

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        #endregion

        #region IWriteRepository

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _session.Save(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            foreach (TEntity entity in entities)
            {
                _session.Save(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _session.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            foreach (TEntity entity in entities)
            {
                _session.Update(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _session.Delete(entity);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entity");

            foreach (TEntity entity in entities)
            {
                _session.Delete(entity);
            }
        }

        #endregion

        #region IReadRepository

        public virtual IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            _session.FlushMode = @readonly ? FlushMode.Never : FlushMode.Auto;

            return GetAll().Where<TEntity>(spec.SpecExpression).AsQueryable();
        }

        public virtual TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            _session.FlushMode = @readonly ? FlushMode.Never : FlushMode.Auto;

            return GetAll().Where(spec.SpecExpression).SingleOrDefault();
        }

        public virtual TEntity GetById(object id, bool @readonly = false)
        {
            _session.FlushMode = @readonly ? FlushMode.Never : FlushMode.Auto;

            return _session.Get<TEntity>(id);
        }

        public virtual IQueryable<TEntity> GetAll(bool @readonly = false)
        {
            _session.FlushMode = @readonly ? FlushMode.Never : FlushMode.Auto;

            return _session.Query<TEntity>();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
