using System;
using System.Collections.Generic;
using EMS.Core.Domain.Specification;

namespace EMS.Core.Application
{
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable where TEntity : class, new()
    {
        TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false);

        IEnumerable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false);

        IEnumerable<TEntity> GetAll(bool @readonly = false);

        TEntity GetById(object id, bool @readonly = false);
    }
}