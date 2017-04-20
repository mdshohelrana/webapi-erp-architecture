using System;
using System.Collections.Generic;
using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Validation;

namespace EMS.Core.Domain.Service
{
    public interface IWriteOnlyService<TEntity> : IDisposable where TEntity : IAggregateRoot, new()
    {
        ValidationResult Add(TEntity entity);

        ValidationResult Add(IEnumerable<TEntity> entities);

        ValidationResult Update(TEntity entity);

        ValidationResult Update(IEnumerable<TEntity> entities);

        ValidationResult Remove(TEntity entity);

        ValidationResult Remove(IEnumerable<TEntity> entities);
    }
}