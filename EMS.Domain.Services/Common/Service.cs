using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Repository;
using EMS.Core.Domain.Service;
using EMS.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Domain.Specification;

namespace EMS.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : IAggregateRoot, new()
    {
        #region Constructor

        private readonly IRepository<TEntity> _repository;
        private readonly ValidationResult _validationResult;

        public Service(IRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Read Methods

        public virtual TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            return _repository.FindBy(spec, @readonly);
        }

        public virtual IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            return _repository.FilterBy(spec, @readonly);
        }

        public virtual IQueryable<TEntity> GetAll(bool @readonly = false)
        {
            return _repository.GetAll(@readonly);
        }

        public virtual TEntity GetById(object id, bool @readonly = false)
        {
            return _repository.GetById(id, @readonly);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            //if (selfValidationEntity != null && !selfValidationEntity.IsValid)
            //    return selfValidationEntity.ValidationResult;


            _repository.Add(entity);
            return _validationResult;
        }

        public virtual ValidationResult Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            //if (selfValidationEntity != null && !selfValidationEntity.IsValid)
            //    return selfValidationEntity.ValidationResult;

            _repository.Update(entity);
            return _validationResult;
        }

        public virtual ValidationResult Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual ValidationResult Remove(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Delete(entity);
            return _validationResult;
        }

        public virtual ValidationResult Remove(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~Service()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
