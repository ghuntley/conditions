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
        [Description("Calling Otherwise with a exception type that doesn't have a 'public ctor(string)' should fail.")]
        [ExpectedException(typeof(TypeInitializationException))]
        public void OtherwiseTest01()
        {
            int a = 3;
            a.Requires().Otherwise<SqlException>(String.Empty);
        }

        [TestMethod]
        [Description("Calling Otherwise with a exception type that does have a 'public ctor(string)' should pass.")]
        public void OtherwiseTest02()
        {
            int a = 3;
            a.Requires().Otherwise<Exception>(String.Empty);
        }

        [TestMethod]
        [Description("Calling Otherwise must result in an exception with the supplied exception message.")]
        public void OtherwiseTest03()
        {
            const string Message = "[the message to be thrown]";
            try
            {
                int a = 3;
                a.Requires().Otherwise<Exception>(Message).IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(Message, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified InvalidOperationException exception being thrown.")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OtherwiseTest04()
        {
            int a = 3;
            a.Requires().Otherwise<InvalidOperationException>(String.Empty).IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified IOException exception being thrown.")]
        [ExpectedException(typeof(IOException))]
        public void OtherwiseTest05()
        {
            int a = 3;
            a.Requires().Otherwise<IOException>(String.Empty).IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling Otherwise will result in the specified ObjectDisposedException exception being thrown.")]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void OtherwiseTest06()
        {
            int a = 3;
            a.Requires().Otherwise<ObjectDisposedException>(String.Empty).IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling the parameterless Otherwise method will result in an exception message of the original requires validator.")]
        public void OtherwiseTest07()
        {
            string expectedMessage = String.Empty;

            int a = 3;

            try
            {
                a.Requires().IsEqualTo(4);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedMessage = ex.Message;
            }

            try
            {
                a.Requires().Otherwise<InvalidOperationException>().IsEqualTo(4);
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
                a.Ensures().IsEqualTo(4);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                expectedMessage = ex.Message;
            }

            try
            {
                a.Ensures().Otherwise<InvalidOperationException>().IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}
