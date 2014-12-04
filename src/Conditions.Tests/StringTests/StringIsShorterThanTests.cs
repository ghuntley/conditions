using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterThan method.
    /// </summary>
    [TestClass]
    public class StringIsShorterThanTests
    {
        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterThan01()
        {
            string a = "test";
            Condition.Requires(a).IsShorterThan(5);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length = upped bound' should fail.")]
        public void IsShorterThan02()
        {
            string a = "test";
            Condition.Requires(a).IsShorterThan(4);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan03()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan04()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'null < upped bound' should pass.")]
        public void IsShorterThan05()
        {
            string a = null;
            Condition.Requires(a).IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsShorterThan on string x with 'null = upped bound' should fail.")]
        public void IsShorterThan06()
        {
            string a = null;
            // A null string is considered to have a length of 0.
            Condition.Requires(a).IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan with conditionDescription parameter should pass.")]
        public void IsShorterThan07()
        {
            string a = string.Empty;
            Condition.Requires(a).IsShorterThan(1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsShorterThan should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsShorterThan08()
        {
            string a = "x";
            try
            {
                Condition.Requires(a, "a").IsShorterThan(1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsShorterThan on string x with 'x.Length = upped bound' should succeed when exceptions are suppressed."
            )]
        public void IsShorterThan09()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterThan(4);
        }
    }
}