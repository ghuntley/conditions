using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotStartWith method.
    /// </summary>
    [TestClass]
    public class StringDoesNotStartWithTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should fail.")]
        public void DoesNotStartWithTest01()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"tes\"' should fail.")]
        public void DoesNotStartWithTest02()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("tes");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith null' should pass.")]
        public void DoesNotStartWithTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotStartWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"\"' should fail.")]
        public void DoesNotStartWithTest04()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith \"\"' should pass.")]
        public void DoesNotStartWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith null' should fail.")]
        public void DoesNotStartWithTest06()
        {
            string a = null;
            Condition.Requires(a).DoesNotStartWith(null);
        }

        [TestMethod]
        [Description(
            "Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test me\"' should pass.")]
        public void DoesNotStartWithTest07()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("test me");
        }

        [TestMethod]
        [Description(
            "Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test\"' should fail with a correct exception message."
            )]
        public void DoesNotStartWithTest08()
        {
            string expectedMessage =
                "a should not start with 'test'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").DoesNotStartWith("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith with conditionDescription parameter should pass.")]
        public void DoesNotStartWithTest09()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("test me", string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing DoesNotStartWith should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void DoesNotStartWithTest10()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").DoesNotStartWith("test", "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith should be language dependent.")]
        public void DoesNotStartWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hi ya'all";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "HI";

                Condition.Requires(a).DoesNotStartWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [TestMethod]
        [Description(
            "Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should succeed when exceptions are suppressed."
            )]
        public void DoesNotStartWithTest12()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotStartWith(a);
        }
    }
}