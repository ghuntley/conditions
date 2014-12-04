using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    [TestClass]
    public class StringDoesNotHaveLengthTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest01()
        {
            string a = "test";
            Condition.Requires(a).DoesNotHaveLength(4);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length = 1' should fail.")]
        public void DoesNotHaveLengthTest02()
        {
            string a = "t";
            Condition.Requires(a).DoesNotHaveLength(1);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest03()
        {
            string a = "test";
            Condition.Requires(a).DoesNotHaveLength(3);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest04()
        {
            string a = String.Empty;
            Condition.Requires(a).DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest05()
        {
            string a = String.Empty;
            Condition.Requires(a).DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling DoesNotHaveLength on string x with 'null = expected length' should fail.")]
        public void DoesNotHaveLengthTest06()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest07()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).DoesNotHaveLength(1);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength with conditionDescription parameter should pass.")]
        public void DoesNotHaveLengthTest08()
        {
            string a = string.Empty;
            Condition.Requires(a).DoesNotHaveLength(1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing DoesNotHaveLength should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void DoesNotHaveLengthTest09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").DoesNotHaveLength(0, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description(
            "Calling DoesNotHaveLength on string x with 'x.Length = expected length' should succeed when exceptions are suppressed."
            )]
        public void DoesNotHaveLengthTest10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotHaveLength(4);
        }
    }
}