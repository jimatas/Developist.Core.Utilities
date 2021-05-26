// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Developist.Core.Utilities
{
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument ensureArgument, Expression<Func<T>> argument, string message)
        {
            return ensureArgument.NotNull(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrEmpty
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>). 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>). 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static string NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument, Expression<Func<Guid?>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, Expression<Func<IEnumerable<T>>> argument, string message)
        {
            return ensureArgument.NotNullOrEmpty(argument.GetValue(), argument.GetName(), message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, Expression<Func<TCollection>> argument) where TCollection : IEnumerable<T>
        {
            return ensureArgument.NotNullOrEmpty<TCollection, T>(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static TCollection NotNullOrEmpty<TCollection, T>(this IEnsureArgument ensureArgument, Expression<Func<TCollection>> argument, string message) where TCollection : IEnumerable<T>
        {
            return ensureArgument.NotNullOrEmpty<TCollection, T>(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotNullOrWhiteSpace
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>) or consists entirely of whitespace. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/>, empty or whitespace.</returns>
        [DebuggerHidden]
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName());
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the value returned by the lambda expression is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>) or consists entirely of whitespace. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The value returned by the lambda expression, if it is not <see langword="null"/>, empty or whitespace.</returns>
        [DebuggerHidden]
        public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument, Expression<Func<string>> argument, string message)
        {
            return ensureArgument.NotNullOrWhiteSpace(argument.GetValue(), argument.GetName(), message);
        }
        #endregion

        #region NotOutOfRange
        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the value returned by the lambda expression is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="lowerBound">The inclusive lower bound of the range; <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound of the range; <see langword="null"/> for unbounded.</param>
        /// <returns>The value returned by the lambda expression, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), lowerBound, upperBound);
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if the value returned by the lambda expression is less than <paramref name="lowerBound"/> or greater than <paramref name="upperBound"/>. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound of the range; <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound of the range; <see langword="null"/> for unbounded.</param>
        /// <returns>The value returned by the lambda expression, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, Expression<Func<IComparable<T>>> argument, string message, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName(), message, lowerBound, upperBound);
        }

        /// <summary>
        /// Throws <see cref="InvalidEnumArgumentException"/> if the value returned by the lambda expression is not a member of the enum specified in the generic type parameter. 
        /// Otherwise, simply returns the value.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to check for membership.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method will be called on.</param>
        /// <param name="argument">A lambda expression that evaluates to the value to check. The parameter name to use for the exception will be derived from the expression body.</param>
        /// <returns>The value returned by the lambda expression, if it is a member of the specified enum.</returns>
        [DebuggerHidden]
        public static TEnum NotOutOfRange<TEnum>(this IEnsureArgument ensureArgument, Expression<Func<TEnum>> argument) where TEnum : struct, Enum
        {
            return ensureArgument.NotOutOfRange(argument.GetValue(), argument.GetName());
        }
        #endregion
    }
}
