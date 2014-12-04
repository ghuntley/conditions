using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNullOrWhiteSpace method.
    /// </summary>
    [TestClass]
    public class StringIsNullOrWhiteSpaceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrWhiteSpace on string x with x = 'a' should fail.")]
        public void IsNullOrWhiteSpaceTest1()
        {
            string a = "a";
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string '' should pass.")]
        public void IsNullOrWhiteSpaceTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string null should pass.")]
        public void IsNullOrWhiteSpaceTest3()
        {
            string a = null;
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on string containing only white space characters should pass.")]
        public void IsNullOrWhiteSpaceTest4()
        {
            string a = "\t  \n\r";
            Condition.Requires(a).IsNullOrWhiteSpace();
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace with conditionDescription parameter should pass.")]
        public void IsNullOrWhiteSpaceTest5()
        {
            string a = string.Empty;
            Condition.Requires(a).IsNullOrWhiteSpace(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNullOrWhiteSpace should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullOrWhiteSpaceTest6()
        {
            string a = "invalid string";
            try
            {
                Condition.Requires(a, "a").IsNullOrWhiteSpace("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNullOrWhiteSpace on an invalid string should succeed when exceptions are suppressed.")]
        public void IsNullOrWhiteSpaceTest7()
        {
            string a = "invalid string";
            Condition.Requires(a).SuppressExceptionsForTest().IsNullOrWhiteSpace();
        }
    }
}