using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    [TestClass]
    public class StringIsShorterOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual00()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual01()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual02()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual03()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual04()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual05()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqual06()
        {
            string a = null;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsShorterOrEqual on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqual07()
        {
            string a = null;
            // A null value is considered to have a length of 0 characters.
            Condition.Requires(a).IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual with conditionDescription parameter should pass.")]
        public void IsShorterOrEqual08()
        {
            string a = string.Empty;
            Condition.Requires(a).IsShorterOrEqual(0, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsShorterOrEqual09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsShorterOrEqual(-1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should succeed when exceptions are suppressed."
            )]
        public void IsShorterOrEqual10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterOrEqual(1);
        }
    }
}