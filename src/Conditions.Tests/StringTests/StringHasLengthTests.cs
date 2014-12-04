using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.HasLength method.
    /// </summary>
    [TestClass]
    public class StringHasLengthTests
    {
        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest01()
        {
            string a = "test";
            Condition.Requires(a).HasLength(4);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest02()
        {
            string a = "test";
            Condition.Requires(a).HasLength(3);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest03()
        {
            string a = String.Empty;
            Condition.Requires(a).HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest04()
        {
            string a = String.Empty;
            Condition.Requires(a).HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'null = expected length' should pass.")]
        public void HasLengthTest05()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling HasLength on string x with 'null != expected length' should fail.")]
        public void HasLengthTest06()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength with conditionDescription parameter should pass.")]
        public void HasLengthTest07()
        {
            string a = string.Empty;
            Condition.Requires(a).HasLength(0, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing HasLength should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void HasLengthTest08()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").HasLength(1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling HasLength on string x with 'x.Length != expected length' should succeed when exceptions are suppressed."
            )]
        public void HasLengthTest09()
        {
            string a = String.Empty;
            Condition.Requires(a).SuppressExceptionsForTest().HasLength(1);
        }
    }
}