﻿

namespace Cine.Dominio._4._4_Method
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    public static partial class ExtensionMethod
    {
        public class ParameterRebinder : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

            public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this._map = map;
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (_map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }

            public static Expression<T> Compose<T> (this Expression<T> first, Expression <T> second, Func<Expression, Expression, Expression> merge)
            {
                var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

                var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

                return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
            }

          
            public static Expression<Func<T, bool>>And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
            {
                return first.Compose(second, Expression.And);
                

            }

            public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
            {
                return first.Compose(second, Expression.Or);
            }
        
    }
}
