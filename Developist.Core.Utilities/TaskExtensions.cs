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
    }
}
