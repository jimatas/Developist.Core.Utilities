// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Linq.Expressions;

namespace Developist.Core.Utilities
{
    internal static class ExpressionExtensions
    {
        /// <summary>
        /// Gets the name of the member that is accessed by the lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="expression">The lambda expression to get the name of the accessed member for.</param>
        /// <returns>The name of the field or property that is being accessed.</returns>
        public static string GetName<T>(this Expression<Func<T>> expression)
        {
            // Handles potentially boxed values produced by Expression.Convert()
            return (expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression)?.Member.Name;
        }

        /// <summary>
        /// Invokes the lambda expression and returns its value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="expression">The lambda expression to return the value of.</param>
        /// <returns>The value returned by the lambda expression.</returns>
        public static T GetValue<T>(this Expression<Func<T>> expression) => expression.Compile().Invoke();
    }
}
