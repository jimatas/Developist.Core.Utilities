// Copyright (c) 2021 Jim Atas. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for details.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Developist.Core.Utilities.Tests
{
    [TestClass]
    public class NullConditionalTests
    {
        [TestMethod]
        public void IfNotNull_CalledOnNullGivenExpressionSettingVariable_DoesNotSetVariable()
        {
            // Arrange
            object target = null;
            var called = false;

            // Act
            target.IfNotNull(_ => called = true);

            // Assert
            Assert.IsFalse(called);
        }

        [TestMethod]
        public void IfNotNull_CalledOnNonNullGivenExpressionSettingVariable_SetsVariable()
        {
            // Arrange
            object target = new object();
            var called = false;

            // Act
            target.IfNotNull(_ => called = true);

            // Assert
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void IfNotNull_CalledOnNullGivenExpressionReturningNewObject_ReturnsNull()
        {
            // Arrange
            object target = null;

            // Act
            var result = target.IfNotNull(_ => new object());

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotNull_CalledOnNonNullGivenExpressionReturningNewObject_ReturnsNewObject()
        {
            // Arrange
            var target = new object();

            // Act
            var result = target.IfNotNull(_ => new object());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, target);
        }

        [TestMethod]
        public void IfNotNull_CalledOnNonNullGivenExpressionReturningSelf_ReturnsSelf()
        {
            // Arrange
            var target = new object();

            // Act
            var result = target.IfNotNull(self => self);

            // Assert
            Assert.AreEqual(result, target);
        }
    }
}
