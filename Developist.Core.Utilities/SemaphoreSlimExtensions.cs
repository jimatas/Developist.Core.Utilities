// Copyright (c) 2022 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Developist.Core.Utilities
{
    public static class SemaphoreSlimExtensions
    {
        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore, int millisecondsTimeout)
        {
            semaphore.Wait(millisecondsTimeout);
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static IDisposable WaitAndRelease(this SemaphoreSlim semaphore, TimeSpan timeout)
        {
            semaphore.Wait(timeout);
            return new SemaphoreSlimReleaser(semaphore);
        }

#if NETSTANDARD2_1_OR_GREATER
        public static async Task<IAsyncDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IAsyncDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, int millisecondsTimeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(millisecondsTimeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IAsyncDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(timeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }
#else
        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, int millisecondsTimeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(millisecondsTimeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }

        public static async Task<IDisposable> WaitAndReleaseAsync(this SemaphoreSlim semaphore, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            await semaphore.WaitAsync(timeout, cancellationToken).WithoutCapturingContext();
            return new SemaphoreSlimReleaser(semaphore);
        }
#endif

        private class SemaphoreSlimReleaser
#if NETSTANDARD2_1_OR_GREATER
            : AsyncDisposableBase
#else
            : DisposableBase
#endif
        {
            private readonly SemaphoreSlim semaphore;
            public SemaphoreSlimReleaser(SemaphoreSlim semaphore) => this.semaphore = semaphore;

#if NETSTANDARD2_1_OR_GREATER
            protected override async ValueTask ReleaseManagedResourcesAsync()
            {
                semaphore.Release();
                await base.ReleaseManagedResourcesAsync().WithoutCapturingContext();
            }
#else
            protected override void ReleaseManagedResources()
            {
                semaphore.Release();
                base.ReleaseManagedResources();
            }
#endif
        }
    }
}
