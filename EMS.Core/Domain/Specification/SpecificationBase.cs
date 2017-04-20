using System;
using System.Linq.Expressions;

namespace EMS.Core.Domain.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private Func<T, bool> _compiledExpression;

        private Func<T, bool> CompiledExpression
        {
            get { return _compiledExpression ?? (_compiledExpression = SpecExpression.Compile()); }
        }

        public virtual Expression<Func<T, bool>> SpecExpression { get; }

        public virtual bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}