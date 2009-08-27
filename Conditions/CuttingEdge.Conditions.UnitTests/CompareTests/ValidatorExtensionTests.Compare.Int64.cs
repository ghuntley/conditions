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

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Int64'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareInt64Tests
    {
        private static readonly Int64 One = 1;
        private static readonly Int64 Two = 2;
        private static readonly Int64 Three = 3;
        private static readonly Int64 Four = 4;
        private static readonly Int64 Five = 5;

        #region IsInt64InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt64InRangeTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt64InRangeTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt64InRangeTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt64InRangeTest04()
        {
            Int64 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt64InRangeTest05()
        {
            Int64 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with conditionDescription should pass.")]
        public void IsInt64InRangeTest06()
        {
            Int64 a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64InRangeTest07()
        {
            Int64 a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64InRange

        #region IsInt64NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt64NotInRangeTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt64NotInRangeTest04()
        {
            Int64 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt64NotInRangeTest05()
        {
            Int64 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotInRangeTest06()
        {
            Int64 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotInRangeTest07()
        {
            Int64 a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64NotInRange

        #region IsInt64GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should fail.")]
        public void IsInt64GreaterThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64GreaterThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64GreaterThanTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64GreaterThanTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64GreaterThan

        #region IsInt64NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotGreaterThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotGreaterThanTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64NotGreaterThan

        #region IsInt64GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64GreaterOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64GreaterOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64GreaterOrEqualTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64GreaterOrEqualTest05()
        {
            Int64 a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64GreaterOrEqual

        #region IsInt64NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotGreaterOrEqualTest04()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotGreaterOrEqualTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64NotGreaterOrEqual

        #region IsInt64LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64LessThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64LessThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64LessThanTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64LessThan

        #region IsInt64NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64NotLessThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotLessThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotLessThanTest05()
        {
            Int64 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64NotLessThan

        #region IsInt64LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64LessOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64LessOrEqualTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64LessOrEqualTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64LessOrEqual

        #region IsInt64NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64NotLessOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotLessOrEqualTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotLessOrEqualTest05()
        {
            Int64 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsNotLessOrEqual

        #region IsInt64EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should fail.")]
        public void IsInt64EqualToTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int64 x with 'x = other' should pass.")]
        public void IsInt64EqualToTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x > other' should fail.")]
        public void IsInt64EqualToTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int64 x with conditionDescription should pass.")]
        public void IsInt64EqualToTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64EqualToTest05()
        {
            Int64 a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64EqualTo

        #region IsInt64NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x < other' should pass.")]
        public void IsInt64NotEqualToTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should fail.")]
        public void IsInt64NotEqualToTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x > other' should pass.")]
        public void IsInt64NotEqualToTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotEqualToTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotEqualToTest05()
        {
            Int64 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt64NotEqualTo
    }
}