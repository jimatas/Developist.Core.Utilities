// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

namespace Developist.Core.Utilities
{
    /// <summary>
    /// Entry point for using the guard functionality.
    /// </summary>
    /// <remarks>
    /// For example, <c>var nonNullValue = Ensure.Argument.NotNull(value, nameof(value));</c>
    /// </remarks>
    public static class Ensure
    {
        /// <summary>
        /// This static read-only field references an instance of a class that implements the <see cref="IEnsureArgument"/> interface.
        /// All the guard clauses are available through this instance.
        /// </summary>
        public static readonly IEnsureArgument Argument = new EnsureArgument();

        private class EnsureArgument : IEnsureArgument
        {
        }
    }
}
