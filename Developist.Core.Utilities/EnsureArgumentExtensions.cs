// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Developist.Core.Utilities
{
    /// <summary>
    /// Defines commonly used guard clauses, which are implemented as extension methods on the <see cref="IEnsureArgument"/> type. 
    /// </summary>
    public static partial class EnsureArgumentExtensions
    {
        #region NotNull
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/>.</returns>
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
        /// <returns>The supplied value, if it is not <see langword="null"/>.</returns>
        [DebuggerHidden]
        public static T NotNull<T>(this IEnsureArgument _, T value, string paramName, string message)
        {
            return value ?? throw new ArgumentNullException(paramName, message);
        }
        #endregion

        #region NotNullOrEmpty
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="Guid.Empty"/>). 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
        [DebuggerHidden]
        public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument, IEnumerable<T> value, string paramName, string message)
        {
            return ensureArgument.NotNullOrEmpty<IEnumerable<T>, T>(value, paramName, message);
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>. 
        /// Throws <see cref="ArgumentException"/> if it is empty. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the value to check.</typeparam>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/> or empty.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>) or consists entirely of whitespace. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/>, empty or whitespace.</returns>
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
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <see langword="null"/>.
        /// Throws <see cref="ArgumentException"/> if it is empty (<see cref="string.Empty"/>) or consists entirely of whitespace. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="message">The custom message to use for the exception.</param>
        /// <returns>The supplied value, if it is not <see langword="null"/>, empty or whitespace.</returns>
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
        /// <param name="ensureArgument">The <see cref="IEnsureArgument"/> instance this method is being defined on.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <param name="lowerBound">The inclusive lower bound of the range; <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound of the range; <see langword="null"/> for unbounded.</param>
        /// <returns>The supplied value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument ensureArgument, IComparable<T> value, string paramName, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            return ensureArgument.NotOutOfRange(value, paramName, DefaultMessage(), lowerBound, upperBound);

            // Generate a default message to use for the exception, incorporating the boundary parameters.
            string DefaultMessage()
            {
                var message = "Value cannot be";
                if (lowerBound is not null)
                {
                    message += $" less than {lowerBound}";
                }

                if (upperBound is not null)
                {
                    if (lowerBound is not null)
                    {
                        message += " or";
                    }
                    message += $" greater than {upperBound}";
                }
                message += ".";

                return message;
            }
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
        /// <param name="lowerBound">The inclusive lower bound of the range; <see langword="null"/> for unbounded.</param>
        /// <param name="upperBound">The inclusive upper bound of the range; <see langword="null"/> for unbounded.</param>
        /// <returns>The supplied value, if it is within bounds.</returns>
        [DebuggerHidden]
        public static T NotOutOfRange<T>(this IEnsureArgument _, IComparable<T> value, string paramName, string message, IComparable<T> lowerBound = null, IComparable<T> upperBound = null)
        {
            if ((lowerBound is not null && Comparer<T>.Default.Compare((T)value, (T)lowerBound) < 0) ||
                (upperBound is not null && Comparer<T>.Default.Compare((T)value, (T)upperBound) > 0))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }

            return (T)value;
        }

        /// <summary>
        /// Throws <see cref="InvalidEnumArgumentException"/> if <paramref name="value"/> is not a member of the enum specified in the generic type parameter. 
        /// Otherwise, simply returns <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to check for membership.</typeparam>
        /// <param name="_"></param>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The parameter name to use for the exception.</param>
        /// <returns>The supplied value, if it is a member of the specified enum.</returns>
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
    }
}
