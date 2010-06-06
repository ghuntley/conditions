using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    [TestClass]
    public class StringIsNotNullOrWhiteSpaceTests
    {
        [TestMethod]
        [Description("Calling IsNotNullOrWhiteSpace on string x with x = 'a' should succeed.")]
        public void IsNotNullOrWhiteSpaceTest1()
        {
            string a = "a";
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNullOrWhiteSpace on string '' should fail.")]
        public void IsNotNullOrWhiteSpaceTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNullOrWhiteSpace on string null should fail.")]
        public void IsNotNullOrWhiteSpaceTest3()
        {
            string a = null;
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNullOrWhiteSpace on string containing only white space characters should fail.")]
        public void IsNotNullOrWhiteSpaceTest4()
        {
            string a = "\t  \n\r";
            Condition.Requires(a).IsNotNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNotNullOrWhiteSpace with conditionDescription parameter should pass.")]
        public void IsNotNullOrWhiteSpaceTest5()
        {
            string a = "valid string";
            Condition.Requires(a).IsNotNullOrWhiteSpace(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNullOrWhiteSpace should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullOrWhiteSpaceTest6()
        {
            string invalidString = string.Empty;
            try
            {
                Condition.Requires(invalidString, "invalidString").IsNotNullOrWhiteSpace("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe invalidString xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNotNullOrWhiteSpace on an invalid string should succeed when exceptions are suppressed.")]
        public void IsNotNullOrWhiteSpaceTest7()
        {
            string invalidString = string.Empty;
            Condition.Requires(invalidString).SuppressExceptionsForTest().IsNotNullOrWhiteSpace();
        }
    }
}
