using System;
using System.Linq.Expressions;

namespace EMS.Core.Domain.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}