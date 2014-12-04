using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsEmptyTests
    {
        [TestMethod]
        [Description("Calling IsEmpty on string x with 'x == String.Empty' should pass.")]
        public void IsStringEmptyTest1()
        {
            string s = String.Empty;
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest2()
        {
            string s = null;
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest3()
        {
            string s = "test";
            Condition.Requires(s).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty with conditionDescription parameter should pass.")]
        public void IsStringEmptyTest4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsEmpty(string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsStringEmptyTest5()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").IsEmpty("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsEmpty on string x with 'x != String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringEmptyTest6()
        {
            string s = null;
            Condition.Requires(s).SuppressExceptionsForTest().IsEmpty();
        }
    }
}