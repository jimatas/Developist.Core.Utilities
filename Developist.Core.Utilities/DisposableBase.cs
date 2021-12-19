// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using System;

namespace Developist.Core.Utilities
{
    public abstract class DisposableBase : IDisposable
    {
        ~DisposableBase()
        {
            Dispose(disposing: false);
        }

        public bool IsDisposed { get; protected set; }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                ReleaseManagedResources();
            }
            ReleaseUnmanagedResources();

            IsDisposed = true;
        }

        protected virtual void ReleaseManagedResources() { }
        protected virtual void ReleaseUnmanagedResources() { }
    }
}
