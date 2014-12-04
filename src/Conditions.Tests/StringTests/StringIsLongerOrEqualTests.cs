using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerOrEqual method.
    /// </summary>
    [TestClass]
    public class StringIsLongerOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerOrEqualTest00()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest01()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest02()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with '-1 < x.Length' should pass.")]
        public void IsLongerOrEqualTest03()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest04()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest05()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = null' should pass.")]
        public void IsLongerOrEqualTest06()
        {
            string a = null;
            Condition.Requires(a).IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > null' should fail.")]
        public void IsLongerOrEqualTest07()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual with conditionDescription parameter should pass.")]
        public void IsLongerOrEqualTest08()
        {
            string a = string.Empty;
            Condition.Requires(a).IsLongerOrEqual(0, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsLongerOrEqualTest09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsLongerOrEqual(1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should succeed when exceptions are suppressed."
            )]
        public void IsLongerOrEqualTest10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsLongerOrEqual(5);
        }
    }
}