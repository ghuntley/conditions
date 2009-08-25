using System;
using System.Data.SqlClient;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    /// <summary>
    /// Summary description for ValidatorOtherwiseTests
    /// </summary>
    [TestClass]
    public class ValidatorOtherwiseTests
    {
        [TestMethod]
        [Description("Calling Otherwise with a exception type that doesn't have a 'public ctor(string)' should fail with a TypeInitializationException.")]
        [ExpectedException(typeof(TypeInitializationException))]
        public void OtherwiseTest01()
        {
            int a = 3;
            Condition.Requires(a).Otherwise<SqlException>();
        }

        [TestMethod]
        [Description("Calling Otherwise with a exception type that does have a 'public ctor(string)' should pass.")]
        public void OtherwiseTest02()
        {
            int a = 3;
            Condition.Requires(a).Otherwise<Exception>();
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified InvalidOperationException exception being thrown.")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OtherwiseTest04()
        {
            int a = 3;
            Condition.Requires(a).Otherwise<InvalidOperationException>().IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified IOException exception being thrown.")]
        [ExpectedException(typeof(IOException))]
        public void OtherwiseTest05()
        {
            int a = 3;
            Condition.Requires(a).Otherwise<IOException>().IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified ObjectDisposedException exception being thrown.")]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void OtherwiseTest06()
        {
            int a = 3;
            Condition.Requires(a).Otherwise<ObjectDisposedException>().IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling the parameterless Otherwise method will result in an exception message of the original requires validator.")]
        public void OtherwiseTest07()
        {
            string expectedMessage = String.Empty;

            int a = 3;

            try
            {
                Condition.Requires(a).IsEqualTo(4);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedMessage = ex.Message;
            }

            try
            {
                Condition.Requires(a).Otherwise<InvalidOperationException>().IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling the parameterless Otherwise method will result in an exception message of the original ensures validator.")]
        public void OtherwiseTest08()
        {
            string expectedMessage = String.Empty;

            int a = 3;

            try
            {
                Condition.Ensures(a).IsEqualTo(4);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedMessage = ex.Message;
            }

            try
            {
                Condition.Ensures(a).Otherwise<InvalidOperationException>().IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling Otherwise with a exception type that that is abstract should fail with a TypeInitializationException.")]
        [ExpectedException(typeof(TypeInitializationException))]
        public void OtherwiseTest09()
        {
            Assert.IsTrue(typeof(AbstractException).IsAbstract);

            int a = 3;
            Condition.Requires(a).Otherwise<AbstractException>();
        }

        internal abstract class AbstractException : Exception
        {
            public AbstractException(string message)
                : base(message)
            {
            }
        }
    }
}
