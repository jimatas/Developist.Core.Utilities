// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

namespace Developist.Core.Utilities.Tests.Fixture
{
    public class DisposableResourceSpy : DisposableBase
    {
        public int ReleaseManagedResourcesCallCount { get; private set; }
        public int ReleaseUnanagedResourcesCallCount { get; private set; }

        protected override void ReleaseManagedResources()
        {
            ReleaseManagedResourcesCallCount++;
            base.ReleaseManagedResources();
        }

        protected override void ReleaseUnmanagedResources()
        {
            ReleaseUnanagedResourcesCallCount++;
            base.ReleaseUnmanagedResources();
        }
    }
}
