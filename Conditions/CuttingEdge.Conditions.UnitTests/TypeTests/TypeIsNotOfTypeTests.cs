#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.TypeTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotOfType method.
    /// </summary>
    [TestClass]
    public class TypeIsNotOfTypeTests
    {
        [TestMethod]
        [Description("Calling IsNotOfType on null reference should pass.")]
        public void IsNotOfTypeTest00()
        {
            object o = null;

            // Null objects have no type, so check must always succeed.
            Condition.Requires(o).IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest01()
        {
            object o = "String";

            Condition.Requires(o).IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the real type should fail.")]
        public void IsNotOfTypeTest02()
        {
            object o = "String";

            Condition.Requires(o).IsNotOfType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on an object tested to be the parent type should fail.")]
        public void IsNotOfTypeTest03()
        {
            string s = "String";

            Condition.Requires(s).IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest04()
        {
            string s = "String";

            Condition.Requires(s).IsNotOfType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a System.Object tested to be System.Object type should fail.")]
        public void IsNotOfTypeTest05()
        {
            object o = new object();

            Condition.Requires(o).IsNotOfType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsNotOfType on a down-casted object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest06()
        {
            object o = "String";

            Condition.Requires(o).IsNotOfType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsNotOfType on an object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest07()
        {
            string s = "String";

            Condition.Requires(s).IsNotOfType(typeof(EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on an object implementing ICollection tested not to implement ICollection should fail.")]
        public void IsNotOfTypeTest08()
        {
            ICollection o = new Collection<int>();

            Condition.Requires(o).IsNotOfType(typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a DayOfWeek tested to implement DayOfWeek should fail with an ArgumentException.")]
        public void IsNotOfTypeTest09()
        {
            object day = DayOfWeek.Monday;

            Condition.Requires(day).IsNotOfType(typeof(DayOfWeek));
        }

        [TestMethod]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should succed when exceptions are suppressed.")]
        public void IsNotOfTypeTest10()
        {
            object o = "String";

            Condition.Requires(o).SuppressExceptionsForTest().IsNotOfType(typeof(object));
        }
    }
}