using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.NullTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNull method.
    /// </summary>
    [TestClass]
    public class NullIsNullTests
    {
        [TestMethod]
        [Description("Calling IsNull on null should pass.")]
        public void IsNullTest01()
        {
            object o = null;
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNull on a reference should fail.")]
        public void IsNullTest02()
        {
            object o = new object();
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull on a null Nullable<T> should pass.")]
        public void IsNullTest03()
        {
            int? i = null;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNull on a set Nullable<T> should fail.")]
        public void IsNullTest04()
        {
            int? i = 3;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNull on an object containing an enum should fail with ArgumentException.")]
        public void IsNullTest05()
        {
            object i = DayOfWeek.Sunday;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull with conditionDescription parameter should pass.")]
        public void IsNullTest06()
        {
            object o = null;
            Condition.Requires(o).IsNull(string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsNull should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsNullTest07()
        {
            object o = new object();
            try
            {
                Condition.Requires(o, "o").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe o xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNullTest08()
        {
            int? i = null;
            Condition.Requires(i).IsNull(string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsNullTest09()
        {
            int? i = 4;
            try
            {
                Condition.Requires(i, "i").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe i xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNull on a reference should succeed when exceptions are suppressed.")]
        public void IsNullTest10()
        {
            object o = new object();
            Condition.Requires(o).SuppressExceptionsForTest().IsNull();
        }
    }
}