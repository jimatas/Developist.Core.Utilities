// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;

namespace Developist.Core.Utilities
{
    /// <summary>
    /// Provides functionality similar to C# 6.0's null conditional operator.
    /// </summary>
    public static class NullConditional
    {
        /// <summary>
        /// Evaluates the specified expression and returns its value, but only if the object this method is called on is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the target object.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="target">The target object.</param>
        /// <param name="expression">The expression to evaluate. The target object will be passed in as the argument.</param>
        /// <returns>The value returned by the expression.</returns>
        public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> expression)
        {
            if (target is not null)
            {
                return expression(target);
            }

            return default;
        }

        /// <summary>
        /// Evaluates the specified expression, but only if the object this method is called on is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the target object.</typeparam>
        /// <param name="target">The target object.</param>
        /// <param name="expression">The expression to evaluate. The target object will be passed in as the argument.</param>
        public static void IfNotNull<T>(this T target, Action<T> expression)
        {
            if (target is not null)
            {
                expression(target);
            }
        }
    }
}
