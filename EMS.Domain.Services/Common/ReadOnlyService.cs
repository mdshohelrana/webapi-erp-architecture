using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Repository;
using EMS.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Domain.Specification;

namespace EMS.Domain.Services.Common
{
    public class ReadOnlyService<TEntity> : IReadOnlyService<TEntity> where TEntity : IAggregateRoot, new()
    {
        #region Constructor

        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;

        public ReadOnlyService(IReadOnlyRepository<TEntity> readOnlyRepository)
        {
            if (readOnlyRepository == null)
                throw new ArgumentNullException("readOnlyRepository");

            _readOnlyRepository = readOnlyRepository;
        }

        #endregion

        #region Properties

        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        #endregion

        #region Implementations

        public virtual TEntity FindBy(ISpecification<TEntity> spec)
        {
            return _readOnlyRepository.FindBy(spec);
        }

        public virtual IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec)
        {
            return _readOnlyRepository.FilterBy(spec);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public virtual TEntity GetById(object id)
        {
            return _readOnlyRepository.GetById(id);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~ReadOnlyService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _readOnlyRepository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
