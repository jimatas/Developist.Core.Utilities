// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Linq.Expressions;

namespace Developist.Core.Utilities
{
    internal static class ExpressionExtensions
    {
        public static string GetName<T>(this Expression<Func<T>> expression)
        {
            return (expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression)?.Member.Name;
        }

        public static T GetValue<T>(this Expression<Func<T>> expression) => expression.Compile().Invoke();
    }
}
