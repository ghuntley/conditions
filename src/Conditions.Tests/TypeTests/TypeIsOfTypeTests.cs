using System;
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.TypeTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsOfType method.
    /// </summary>
    [TestClass]
    public class TypeIsOfTypeTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsOfType on null reference should fail.")]
        public void IsOfTypeTest00()
        {
            object o = null;

            Condition.Requires(o).IsOfType(typeof (EventArgs));
        }

        [TestMethod]
        [Description("Calling IsOfType on a down-casted object tested to be the down-casted type should pass.")]
        public void IsOfTypeTest01()
        {
            object o = "String";

            Condition.Requires(o).IsOfType(typeof (object));
        }

        [TestMethod]
        [Description("Calling IsOfType on a down-casted object tested to be the real type should pass.")]
        public void IsOfTypeTest02()
        {
            object o = "String";

            Condition.Requires(o).IsOfType(typeof (string));
        }

        [TestMethod]
        [Description("Calling IsOfType on a object tested to be it's parent type should pass.")]
        public void IsOfTypeTest03()
        {
            string s = "String";

            Condition.Requires(s).IsOfType(typeof (object));
        }

        [TestMethod]
        [Description("Calling IsOfType on a object tested to be it's own type should pass.")]
        public void IsOfTypeTest04()
        {
            string s = "String";

            Condition.Requires(s).IsOfType(typeof (string));
        }

        [TestMethod]
        [Description("Calling IsOfType on a System.Object tested to be System.Object should pass.")]
        public void IsOfTypeTest05()
        {
            object o = new object();

            Condition.Requires(o).IsOfType(typeof (object));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsOfType on a down-casted object tested to be a non comparable type should fail.")]
        public void IsOfTypeTest06()
        {
            object o = "String";

            Condition.Requires(o).IsOfType(typeof (EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsOfType on a object tested to be a non comparable type should fail.")]
        public void IsOfTypeTest07()
        {
            string s = "String";

            Condition.Requires(s).IsOfType(typeof (EventArgs));
        }

        [TestMethod]
        [Description(
            "Calling IsOfType on an object implementing ICollection tested to implement ICollection should pass.")]
        public void IsOfTypeTest08()
        {
            ICollection o = new Collection<int>();

            Condition.Requires(o).IsOfType(typeof (ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description(
            "Calling IsOfType on an enum tested to implement ICollection should fail with an ArgumentException.")]
        public void IsOfTypeTest09()
        {
            object day = DayOfWeek.Monday;

            Condition.Requires(day).IsOfType(typeof (ICollection));
        }

        [TestMethod]
        [Description("Calling IsOfType on null reference should succeed when exceptions are suppressed.")]
        public void IsOfTypeTest10()
        {
            object o = null;

            Condition.Requires(o).SuppressExceptionsForTest().IsOfType(typeof (EventArgs));
        }
    }
}