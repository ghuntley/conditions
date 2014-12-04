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
// with 'Int16'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareInt16Tests
    {
        private static readonly Int16 One = 1;
        private static readonly Int16 Two = 2;
        private static readonly Int16 Three = 3;
        private static readonly Int16 Four = 4;
        private static readonly Int16 Five = 5;

        #region IsInt16InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt16InRangeTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt16InRangeTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt16InRangeTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt16InRangeTest04()
        {
            Int16 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt16InRangeTest05()
        {
            Int16 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16InRangeTest06()
        {
            Int16 a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16InRangeTest07()
        {
            Int16 a = Five;
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

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16InRangeTest08()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt16InRange

        #region IsInt16NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt16NotInRangeTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt16NotInRangeTest04()
        {
            Int16 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt16NotInRangeTest05()
        {
            Int16 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotInRangeTest06()
        {
            Int16 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotInRangeTest07()
        {
            Int16 a = Four;
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

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotInRangeTest08()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt16NotInRange

        #region IsInt16GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should fail.")]
        public void IsInt16GreaterThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16GreaterThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterThanTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterThanTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterThanTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt16GreaterThan

        #region IsInt16NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterThanTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotGreaterThanTest06()
        {
            Int16 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsInt16NotGreaterThan

        #region IsInt16GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16GreaterOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16GreaterOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterOrEqualTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterOrEqualTest05()
        {
            Int16 a = One;
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

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterOrEqualTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsInt16GreaterOrEqual

        #region IsInt16NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterOrEqualTest04()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterOrEqualTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotGreaterOrEqualTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsInt16NotGreaterOrEqual

        #region IsInt16LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16LessThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessThanTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessThanTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt16LessThan

        #region IsInt16NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16NotLessThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessThanTest05()
        {
            Int16 a = Two;
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

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16NotLessThanTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsInt16NotLessThan

        #region IsInt16LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16LessOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessOrEqualTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessOrEqualTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessOrEqualTest06()
        {
            Int16 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsInt16LessOrEqual

        #region IsInt16NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16NotLessOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessOrEqualTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessOrEqualTest05()
        {
            Int16 a = Two;
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

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16NotLessOrEqualTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt16EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should fail.")]
        public void IsInt16EqualToTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x = other' should pass.")]
        public void IsInt16EqualToTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x > other' should fail.")]
        public void IsInt16EqualToTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16EqualToTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16EqualToTest05()
        {
            Int16 a = Three;
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

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt16EqualToTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt16EqualTo

        #region IsInt16NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x < other' should pass.")]
        public void IsInt16NotEqualToTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should fail.")]
        public void IsInt16NotEqualToTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x > other' should pass.")]
        public void IsInt16NotEqualToTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotEqualToTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotEqualToTest05()
        {
            Int16 a = Two;
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

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsInt16NotEqualToTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt16NotEqualTo
    }
}