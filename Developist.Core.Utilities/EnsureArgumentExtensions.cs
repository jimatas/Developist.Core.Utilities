// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Developist.Core.Utilities
{
    [DebuggerStepThrough]
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        public static T NotNull<T>(this IEnsureArgument ensureArgument, T value, string paramName)
        {
            return ensureArgument.NotNull(value, paramName, message: "Value cannot be null.");
        }

        public static T NotNull<T>(this IEnsureArgument _, T value, string paramName, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return value;
        }
        #endregion

        #region NotNullOrEmpty
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value.Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value.Length == 0)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName);
        }

        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName, string message)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName, message);
        }

        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, TCollection value, string paramName)
            where TCollection : IEnumerable<T>
        {
            ensureArgument.NotNull(value, paramName);

            if (!value.Any())
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, TCollection value, string paramName, string message)
            where TCollection : IEnumerable<T>
        {
            ensureArgument.NotNull(value, paramName, message);

            if (!value.Any())
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }
        #endregion

        #region NotNullOrWhiteSpace
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNullOrEmpty(value, paramName);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be whitespace.", paramName);
            }

            return value;
        }

        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, string value, string paramName, string message)
        {
            ensureArgument.NotNullOrEmpty(value, paramName, message);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }
        #endregion

        #region NotOutOfRange
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, IComparable<T> value, string paramName, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(value, paramName, DefaultMessage(), lowerBound, upperBound);

            string DefaultMessage()
            {
                var message = "Value cannot be";
                if (lowerBound != null)
                {
                    message += $" less than {lowerBound}";
                }

                if (upperBound != null)
                {
                    if (lowerBound != null)
                    {
                        message += " or";
                    }
                    message += $" greater than {upperBound}";
                }
                message += ".";

                return message;
            }
        }

        public static T NotOutOfRange<T>(this IEnsureArgument _, IComparable<T> value, string paramName, string message, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            if ((lowerBound != null && Comparer<T>.Default.Compare((T)value, (T)lowerBound) < 0) ||
                (upperBound != null && Comparer<T>.Default.Compare((T)value, (T)upperBound) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return (T)value;
        }

        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument _, TEnum value, string paramName)
            where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new InvalidEnumArgumentException(paramName, Convert.ToInt32(value), typeof(TEnum));
            }

            return value;
        }
        #endregion
    }
}
