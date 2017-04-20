using System.Collections.Generic;
using EMS.Core.Domain.Specification;

namespace EMS.Core.Application
{
    public interface IReadOnlyAppService<TEntity> where TEntity : class, new()
    {
        TEntity FindBy(ISpecification<TEntity> spec);

        IEnumerable<TEntity> FilterBy(ISpecification<TEntity> spec);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object id);
    }
}