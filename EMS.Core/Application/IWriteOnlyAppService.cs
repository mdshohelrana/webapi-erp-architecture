using System.Collections.Generic;
using EMS.Core.Domain.Validation;

namespace EMS.Core.Application
{
    public interface IWriteOnlyAppService<TEntity> where TEntity : class, new()
    {
        ValidationResult Create(TEntity entity);

        ValidationResult Create(IEnumerable<TEntity> entities);

        ValidationResult Update(TEntity entity);

        ValidationResult Update(IEnumerable<TEntity> entities);

        ValidationResult Remove(object id);

        ValidationResult Remove(IEnumerable<TEntity> entities);
    }
}