using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Developist.Core.Utilities.Tests
{
    [TestClass]
    public class NullableExtensionsTests
    {
        #region IsNullOrDefault
        [DataTestMethod]
        [DataRow(null)]
        [DataRow(default(int))]
        public void IsNullOrDefault_CalledOnNullOrDefaultInt32_ReturnsTrue(int? target)
        {
            // Arrange
            
            // Act
            var result = target.IsNullOrDefault();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrDefault_CalledOnNonNullOrDefaultInt32_ReturnsFalse()
        {
            // Arrange
            int? target = 1;

            // Act
            var result = target.IsNullOrDefault();

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        public void IsNullOrDefault_CalledOnNullOrDefaultDateTime_ReturnsTrue()
        {
            foreach (var target in new DateTime?[] { null, default(DateTime), DateTime.MinValue })
            {
                // Arrange
                
                // Act
                var result = target.IsNullOrDefault();

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void IsNullOrDefault_CalledOnNonNullOrDefaultDateTime_ReturnsFalse()
        {
            // Arrange
            DateTime? target = DateTime.MaxValue;

            // Act
            var result = target.IsNullOrDefault();

            // Assert
            Assert.IsFalse(result);
        }
        #endregion

        #region IfNotNull
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

        [TestMethod]
        public void IfNotNull_CalledOnNullGivenAction_DoesNotInvokeAction()
        {
            // Arrange
            object target = null;
            bool result = false;

            // Act
            target.IfNotNull(_ => { result = true; });

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfNotNull_CalledOnNonNullGivenAction_InvokesAction()
        {
            // Arrange
            var target = new object();
            bool result = false;

            // Act
            target.IfNotNull(_ => { result = true; });

            // Assert
            Assert.IsTrue(result);
        }
        #endregion
    }
}
