// Copyright (c) 2022 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Developist.Core.Utilities
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable WithoutCapturingContext(this Task task)
            => task.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredTaskAwaitable<TResult> WithoutCapturingContext<TResult>(this Task<TResult> task)
            => task.ConfigureAwait(continueOnCapturedContext: false);

#if NETSTANDARD2_1_OR_GREATER
        public static ConfiguredValueTaskAwaitable WithoutCapturingContext(this ValueTask task)
            => task.ConfigureAwait(continueOnCapturedContext: false);

        public static ConfiguredValueTaskAwaitable<TResult> WithoutCapturingContext<TResult>(this ValueTask<TResult> task)
            => task.ConfigureAwait(continueOnCapturedContext: false);
#endif
    }
}
