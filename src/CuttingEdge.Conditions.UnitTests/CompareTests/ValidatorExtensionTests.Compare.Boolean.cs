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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareBooleanTests
    {
        #region IsTrue

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' should pass.")]
        public void IsTrueTest01()
        {
            bool b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean x with 'x == false' should fail.")]
        public void IsTrueTest02()
        {
            bool b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' should pass.")]
        public void IsTrueTest03()
        {
            bool? b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean? x with 'x == false' should fail.")]
        public void IsTrueTest04()
        {
            bool? b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsTrue on Boolean? x with 'x == null' should fail.")]
        public void IsTrueTest05()
        {
            bool? b = null;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' and conditionDescription should pass.")]
        public void IsTrueTest06()
        {
            bool b = true;
            Condition.Requires(b).IsTrue(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' and conditionDescription should pass.")]
        public void IsTrueTest07()
        {
            bool? b = true;
            Condition.Requires(b).IsTrue(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsTrue on Boolean should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsTrueTest08()
        {
            bool b = false;
            try
            {
                Condition.Requires(b, "b").IsTrue("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling a failing IsTrue on Boolean? should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsTrueTest09()
        {
            bool? b = false;
            try
            {
                Condition.Requires(b, "b").IsTrue("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == false' should succeed when exceptions are suppressed.")]
        public void IsTrueTest10()
        {
            bool b = false;
            Condition.Requires(b).SuppressExceptionsForTest().IsTrue();
        }

        #endregion // IsTrue

        #region IsFalse

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' should pass.")]
        public void IsFalseTest01()
        {
            bool b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean x with 'x == true' should fail.")]
        public void IsFalseTest02()
        {
            bool b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' should pass.")]
        public void IsFalseTest03()
        {
            bool? b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean? x with 'x == true' should fail.")]
        public void IsFalseTest04()
        {
            bool? b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsFalse on Boolean? x with 'x == null' should fail.")]
        public void IsFalseTest05()
        {
            bool? b = null;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' and conditionDescription should pass.")]
        public void IsFalseTest06()
        {
            bool b = false;
            Condition.Requires(b).IsFalse(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' and conditionDescription should pass.")]
        public void IsFalseTest07()
        {
            bool? b = false;
            Condition.Requires(b).IsFalse(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsFalse on Boolean should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsFalseTest08()
        {
            bool b = true;
            try
            {
                Condition.Requires(b, "b").IsFalse("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling a failing IsFalse on Boolean? should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsFalseTest09()
        {
            bool? b = true;
            try
            {
                Condition.Requires(b, "b").IsFalse("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == true' should succeed when exceptions are suppressed.")]
        public void IsFalseTest10()
        {
            bool b = true;
            Condition.Requires(b).SuppressExceptionsForTest().IsFalse();
        }

        #endregion // IsFalse
    }
}
