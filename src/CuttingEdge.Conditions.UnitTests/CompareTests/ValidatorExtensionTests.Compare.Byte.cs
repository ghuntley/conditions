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
// with 'Byte'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareByteTests
    {
        private static readonly Byte One = 1;
        private static readonly Byte Two = 2;
        private static readonly Byte Three = 3;
        private static readonly Byte Four = 4;
        private static readonly Byte Five = 5;

        #region IsByteInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should fail.")]
        public void IsByteInRangeTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest04()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest05()
        {
            Byte a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with conditionDescription should pass.")]
        public void IsByteInRangeTest06()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteInRangeTest07()
        {
            Byte a = Five;
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
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteInRangeTest08()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest04()
        {
            Byte a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest05()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with conditionDescription should pass.")]
        public void IsByteNotInRangeTest06()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotInRangeTest07()
        {
            Byte a = Four;
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
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotInRangeTest08()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsByteNotInRange

        #region IsByteGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterThanTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterThanTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsByteGreaterThan

        #region IsByteNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x = upper bound' should pass.")]
        public void IsByteNotGreaterThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotGreaterThanTest06()
        {
            Byte a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsByteNotGreaterThan

        #region IsByteGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterOrEqualTest05()
        {
            Byte a = One;
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
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterOrEqualTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsByteGreaterOrEqual

        #region IsByteNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterOrEqualTest04()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterOrEqualTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotGreaterOrEqualTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsByteNotGreaterOrEqual

        #region IsByteLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessThanTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsByteLessThan

        #region IsByteNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound = x' should pass.")]
        public void IsByteNotLessThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessThanTest05()
        {
            Byte a = Two;
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
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteNotLessThanTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsByteNotLessThan

        #region IsByteLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteLessOrEqualTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessOrEqualTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessOrEqualTest06()
        {
            Byte a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsByteLessOrEqual

        #region IsByteNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound = x' should fail.")]
        public void IsByteNotLessOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessOrEqualTest05()
        {
            Byte a = Two;
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
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteNotLessOrEqualTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsByteEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteEqualToTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteEqualToTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsEqualTo on Byte x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsByteEqualToTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteNotEqualToTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotEqualToTest05()
        {
            Byte a = Two;
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
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsByteNotEqualToTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsByteNotEqualTo
    }
}