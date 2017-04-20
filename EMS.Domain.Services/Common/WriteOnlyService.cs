using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Repository;
using EMS.Core.Domain.Service;
using System;
using System.Collections.Generic;
using EMS.Core.Domain.Validation;

namespace EMS.Domain.Services.Common
{
    public class WriteOnlyService<TEntity> : IWriteOnlyService<TEntity> where TEntity : IAggregateRoot, new()
    {
        #region Constructor

        private readonly IWriteOnlyRepository<TEntity> _writeOnlyRepository;
        private readonly ValidationResult _validationResult;

        public WriteOnlyService(IWriteOnlyRepository<TEntity> writeOnlyRepository)
        {
            if (writeOnlyRepository == null)
                throw new ArgumentNullException("writeOnlyRepository");

            _writeOnlyRepository = writeOnlyRepository;
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IWriteOnlyRepository<TEntity> WriteOnlyRepository
        {
            get { return _writeOnlyRepository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Implementations

        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            //if (selfValidationEntity != null && !selfValidationEntity.IsValid)
            //    return selfValidationEntity.ValidationResult;


            _writeOnlyRepository.Add(entity);
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

            _writeOnlyRepository.Update(entity);
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

            _writeOnlyRepository.Delete(entity);
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

        ~WriteOnlyService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writeOnlyRepository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
