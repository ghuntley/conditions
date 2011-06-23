using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public class AlternativeExceptionConditionTests
    {
        [TestMethod]
        [Description("WithExceptionOnFailure called with a valid exception type does not return null.")]
        public void WithExceptionOnFailure_WithValidExceptionType_ReturnsAnInstance()
        {
            // Act
            var condition = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            Assert.IsNotNull(condition);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType1_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // Act
            Condition.WithExceptionOnFailure<ObjectDisposedException>().Requires(value).IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType2_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // First call WithExceptionOnFailure for another exception type.
            Condition.WithExceptionOnFailure<KeyNotFoundException>();

            // Act 
            Condition.WithExceptionOnFailure<ApplicationException>().Requires(value).IsNotNull();
        }

        [TestMethod]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected message.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedMessage()
        {
            // Arrange
            string expectedMessage = 
                "The type must be concrete and have a public constructor with a single string argument.";

            try
            {
                // Act
                Condition.WithExceptionOnFailure<NoValidConstructorException>();

                // Assert
                Assert.Fail("Exception was expected.");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(expectedMessage), "Invalid exception message: " + ex.Message);
            }
        }

        [TestMethod]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected parameter name.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedParamName()
        {
            // Arrange
            string expectedParamName = "TException";

            try
            {
                // Act
                Condition.WithExceptionOnFailure<NoValidConstructorException>();

                // Assert
                Assert.Fail("Exception was expected.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expectedParamName, ex.ParamName, "Invalid ParamName.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("WithExceptionOnFailure called with an abstract exception type throws an exception of type ArgumentException.")]
        public void WithExceptionOnFailure_WithAbstractExceptionType_ThrowsExpectedExceptionType()
        {
            // Act
            Condition.WithExceptionOnFailure<AbstractException>();
        }

        [TestMethod]
        [Description("WithExceptionOnFailure called multiple times with the same exception type, always returns the same instance.")]
        public void WithExceptionOnFailure_CalledMultipleTimesWithTheSameExceptionType_ReturnsTheSameInstance()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for the same exception type are " +
                "expected to return the same instance for performance reasons.";

            Assert.AreEqual(condition1, condition2, 
                assertMessage);
        }

        [TestMethod]
        [Description("WithExceptionOnFailure called multiple times with the different exception type, always returns different instances.")]
        public void WithExceptionOnFailure_CalledWithDifferentExceptionType_ReturnsDifferentInstances()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<ObjectDisposedException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for different exception type are " +
                "expected to return different instances, because each type will get its own condition type.";

            Assert.AreNotEqual(condition1, condition2, assertMessage);
        }

        public class NoValidConstructorException : Exception
        {
            public NoValidConstructorException() 
            { 
            }
        }

        public abstract class AbstractException : Exception
        {
            public AbstractException(string message)
            {
            }
        }
    }
}