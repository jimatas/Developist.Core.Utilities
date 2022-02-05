// Copyright (c) 2022 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;
using System.Threading.Tasks;

namespace Developist.Core.Utilities
{
    public class AsyncDisposableBase : DisposableBase, IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().WithoutCapturingContext();
            Dispose(disposing: false);

            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (IsDisposed)
            {
                return;
            }

            await ReleaseManagedResourcesAsync().WithoutCapturingContext();

            IsDisposed = true;
        }

        protected virtual ValueTask ReleaseManagedResourcesAsync() => default;
    }
}
