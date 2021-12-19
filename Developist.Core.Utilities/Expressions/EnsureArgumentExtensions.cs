// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Developist.Core.Utilities
{
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName());
        }

        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument, string message)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrEmpty
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, Expression<Func<TCollection>> argument) 
            where TCollection : IEnumerable<T>
        {
            return ensureArgument.NotNullOrEmpty<TCollection, T>(argument.GetValue(), argument.GetName());
        }

        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, Expression<Func<TCollection>> argument, string message) 
            where TCollection : IEnumerable<T>
        {
            return ensureArgument.NotNullOrEmpty<TCollection, T>(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrWhiteSpace
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName());
        }

        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotOutOfRange
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), lowerBound, upperBound);
        }

        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, string message, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), message, lowerBound, upperBound);
        }

        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument ensureArgument, Expression<Func<TEnum>> argument) 
            where TEnum : struct, Enum
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName());
        }
        #endregion
    }
}
