// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Developist.Core.Utilities
{
    /// <summary>
    /// Defines commonly used guard clauses, which are implemented as extension methods on the <see cref="IEnsureArgument"/> type. 
    /// </summary>
    public static class EnsureArgumentExtensions
    {
        #region NotNull
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, T value, string paramName)
        {
            return ensureArgument.NotNull(value, paramName, message: "Value cannot be null.");
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="_"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument _, T value, string paramName, string message)
        {
            return value ?? throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> with a default message if the expression evaluates to <see langword="null"/>. 
        /// Otherwise, simply returns its value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="parameter">An expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> parameter)
        {
            return ensureArgument.NotNull(parameter, message: "Value cannot be null.");
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> with a custom message if the expression evaluates to <see langword="null"/>. 
        /// Otherwise, simply returns its value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="parameter">An expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> parameter, string message)
        {
            return ensureArgument.NotNull(parameter.GetValue(), parameter.GetName(), message);
        }
        #endregion

        #region NotNullOrEmpty
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value.Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, string value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value.Length == 0)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName)
        {
            ensureArgument.NotNull(value, paramName);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Guid? value, string paramName, string message)
        {
            ensureArgument.NotNull(value, paramName, message);

            if (value == Guid.Empty)
            {
                throw new ArgumentException(message, paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName, string message)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static TEnumerable NotNullOrEmpty<TEnumerable, T>(this IEnsureArgument ensureArgument, TEnumerable value, string paramName) where TEnumerable : IEnumerable<T>
        {
            ensureArgument.NotNull(value, paramName);

            if (!value.Any())
            {
                throw new ArgumentException(message: "Value cannot be empty.", paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static TEnumerable NotNullOrEmpty<TEnumerable, T>(this IEnsureArgument ensureArgument, TEnumerable value, string paramName, string message) where TEnumerable : IEnumerable<T>
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
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty or consists entirely of whitespace. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/>, empty or completely whitespace.</returns>
        [DebuggerHidden]
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, string value, string paramName)
        {
            ensureArgument.NotNullOrEmpty(value, paramName);

            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(message: "Value cannot be whitespace.", paramName);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>, or <see cref="ArgumentException"/> if it is empty or consists entirely of whitespace. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value, if it is not <see langword="null"/>, empty or completely whitespace.</returns>
        [DebuggerHidden]
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
        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound, or <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound, or <see langword="null"/> for unbounded.</param>
        /// <returns>The value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, T value, string paramName, T? lowerBound = null, T? upperBound = null) where T : struct, IComparable<T>
        {
            return ensureArgument.NotOutOfRange(value, paramName, message: "Value is out of range.", lowerBound, upperBound);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="_"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound, or <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound, or <see langword="null"/> for unbounded.</param>
        /// <returns>The value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument _, T value, string paramName, string message, T? lowerBound = null, T? upperBound = null) where T : struct, IComparable<T>
        {
            if ((lowerBound is not null && Comparer<T>.Default.Compare(value, (T)lowerBound) < 0) ||
                (upperBound is not null && Comparer<T>.Default.Compare(value, (T)upperBound) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound, or <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound, or <see langword="null"/> for unbounded.</param>
        /// <returns>The value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, T value, string paramName, T lowerBound = null, T upperBound = null) where T : class, IComparable<T>
        {
            return ensureArgument.NotOutOfRange(value, paramName, message: "Value is out of range.", lowerBound, upperBound);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="_"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound, or <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound, or <see langword="null"/> for unbounded.</param>
        /// <returns>The value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument _, T value, string paramName, string message, T lowerBound = null, T upperBound = null) where T : class, IComparable<T>
        {
            if ((lowerBound is not null && Comparer<T>.Default.Compare(value, lowerBound) < 0) ||
                (upperBound is not null && Comparer<T>.Default.Compare(value, upperBound) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return value;
        }

        /// <summary>
        /// Throws <see cref="InvalidEnumArgumentException"/> if <paramref name="value"/> is not a member of the enum specified in the generic type parameter. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to check for membership.</typeparam>
        /// <param name="_"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The value, if it is a member of the specified enum.</returns>
        [DebuggerHidden]
        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument _, TEnum value, string paramName) where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(value))
            {
                throw new InvalidEnumArgumentException(paramName, Convert.ToInt32(value), typeof(TEnum));
            }

            return value;
        }
        #endregion

        #region Helpers
        private static T GetValue<T>(this Expression<Func<T>> expression) => expression.Compile().Invoke();

        private static string GetName<T>(this Expression<Func<T>> expression)
        {
            // Handles a potentially boxed value produced by Expression.Convert()
            return (expression.Body as MemberExpression ?? (expression.Body as UnaryExpression)?.Operand as MemberExpression)?.Member.Name;
        }
        #endregion
    }
}
