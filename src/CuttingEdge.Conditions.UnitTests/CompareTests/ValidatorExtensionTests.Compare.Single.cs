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
// with 'Single'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareSingleTests
    {
        private static readonly Single One = 1;
        private static readonly Single Two = 2;
        private static readonly Single Three = 3;
        private static readonly Single Four = 4;
        private static readonly Single Five = 5;

        #region IsSingleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should fail.")]
        public void IsSingleInRangeTest01()
        {
            Single a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound = x < upper bound' should pass.")]
        public void IsSingleInRangeTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x < upper bound' should pass.")]
        public void IsSingleInRangeTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x = upper bound' should pass.")]
        public void IsSingleInRangeTest04()
        {
            Single a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound < x > upper bound' should fail.")]
        public void IsSingleInRangeTest05()
        {
            Single a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with conditionDescription should pass.")]
        public void IsSingleInRangeTest06()
        {
            Single a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleInRangeTest07()
        {
            Single a = Five;
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
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleInRangeTest08()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsSingleInRange

        #region IsSingleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound > x < upper bound' should pass.")]
        public void IsSingleNotInRangeTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x = upper bound' should fail.")]
        public void IsSingleNotInRangeTest04()
        {
            Single a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x > upper bound' should pass.")]
        public void IsSingleNotInRangeTest05()
        {
            Single a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with conditionDescription should pass.")]
        public void IsSingleNotInRangeTest06()
        {
            Single a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotInRangeTest07()
        {
            Single a = Four;
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
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotInRangeTest08()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsSingleNotInRange

        #region IsSingleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should fail.")]
        public void IsSingleGreaterThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound = x' should fail.")]
        public void IsSingleGreaterThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterThanTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterThanTest05()
        {
            Single a = Three;
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
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterThanTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsSingleGreaterThan

        #region IsSingleNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x = upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterThanTest05()
        {
            Single a = Three;
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
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotGreaterThanTest06()
        {
            Single a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsSingleNotGreaterThan

        #region IsSingleGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleGreaterOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound = x' should pass.")]
        public void IsSingleGreaterOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterOrEqualTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterOrEqualTest05()
        {
            Single a = One;
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
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterOrEqualTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsSingleGreaterOrEqual

        #region IsSingleNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterOrEqualTest04()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterOrEqualTest05()
        {
            Single a = Three;
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
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotGreaterOrEqualTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsSingleNotGreaterOrEqual

        #region IsSingleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should fail.")]
        public void IsSingleLessThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleLessThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessThanTest05()
        {
            Single a = Three;
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
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessThanTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsSingleLessThan

        #region IsSingleNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound = x' should pass.")]
        public void IsSingleNotLessThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessThanTest05()
        {
            Single a = Two;
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
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleNotLessThanTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsSingleNotLessThan

        #region IsSingleLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x = upper bound' should pass.")]
        public void IsSingleLessOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleLessOrEqualTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessOrEqualTest05()
        {
            Single a = Three;
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
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessOrEqualTest06()
        {
            Single a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsSingleLessOrEqual

        #region IsSingleNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound = x' should fail.")]
        public void IsSingleNotLessOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessOrEqualTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessOrEqualTest05()
        {
            Single a = Two;
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
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleNotLessOrEqualTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsSingleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x < other' should fail.")]
        public void IsSingleEqualToTest01()
        {
            Single a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with 'x = other' should pass.")]
        public void IsSingleEqualToTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x > other' should fail.")]
        public void IsSingleEqualToTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleEqualToTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleEqualToTest05()
        {
            Single a = Three;
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
        [Description("Calling IsEqualTo on Single x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsSingleEqualToTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsSingleEqualTo

        #region IsSingleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x < other' should pass.")]
        public void IsSingleNotEqualToTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should fail.")]
        public void IsSingleNotEqualToTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x > other' should pass.")]
        public void IsSingleNotEqualToTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleNotEqualToTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotEqualToTest05()
        {
            Single a = Two;
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
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsSingleNotEqualToTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsSingleNotEqualTo
    }
}