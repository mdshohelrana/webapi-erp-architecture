using System;
using System.Linq.Expressions;

namespace EMS.Core.Domain.Specification
{
    public class Negated<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _inner;

        public Negated(ISpecification<T> inner)
        {
            _inner = inner;
        }

        // NegatedSpecification
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof (T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.Not(
                        Expression.Invoke(_inner.SpecExpression, objParam)
                        ),
                    objParam
                    );

                return newExpr;
            }
        }
    }
}