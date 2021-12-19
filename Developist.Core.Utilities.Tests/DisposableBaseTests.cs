// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using Developist.Core.Utilities.Tests.Fixture;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Developist.Core.Utilities.Tests
{
    [TestClass]
    public class DisposableBaseTests
    {
        [TestMethod]
        public void NewInstance_ByDefault_IsNotDisposed()
        {
            // Arrange
            var resource = new DisposableResourceSpy();

            // Act

            // Assert
            Assert.IsFalse(resource.IsDisposed);
        }

        [TestMethod]
        public void Dispose_ByDefault_Disposes()
        {
            // Arrange
            var resource = new DisposableResourceSpy();

            // Act
            resource.Dispose();

            // Assert
            Assert.IsTrue(resource.IsDisposed);
        }

        [TestMethod]
        public void Dispose_ByDefault_CallsAllHooks()
        {
            // Arrange
            var resource = new DisposableResourceSpy();

            // Act
            resource.Dispose();

            // Assert
            Assert.AreEqual(1, resource.ReleaseManagedResourcesCallCount);
            Assert.AreEqual(1, resource.ReleaseUnanagedResourcesCallCount);
        }

        [TestMethod]
        public void Dispose_CalledTwice_CallsHooksOnlyOnce()
        {
            // Arrange
            var resource = new DisposableResourceSpy();

            // Act
            resource.Dispose();
            resource.Dispose();

            // Assert
            Assert.AreEqual(1, resource.ReleaseManagedResourcesCallCount);
            Assert.AreEqual(1, resource.ReleaseUnanagedResourcesCallCount);
        }
    }
}
