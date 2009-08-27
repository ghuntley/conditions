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
// with 'Double'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareDoubleTests
    {
        private static readonly Double One = 1;
        private static readonly Double Two = 2;
        private static readonly Double Three = 3;
        private static readonly Double Four = 4;
        private static readonly Double Five = 5;

        #region IsDoubleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should fail.")]
        public void IsDoubleInRangeTest01()
        {
            Double a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound = x < upper bound' should pass.")]
        public void IsDoubleInRangeTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x < upper bound' should pass.")]
        public void IsDoubleInRangeTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x = upper bound' should pass.")]
        public void IsDoubleInRangeTest04()
        {
            Double a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound < x > upper bound' should fail.")]
        public void IsDoubleInRangeTest05()
        {
            Double a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with conditionDescription should pass.")]
        public void IsDoubleInRangeTest06()
        {
            Double a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleInRangeTest07()
        {
            Double a = Five;
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

        #endregion // IsDoubleInRange

        #region IsDoubleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound > x < upper bound' should pass.")]
        public void IsDoubleNotInRangeTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x = upper bound' should fail.")]
        public void IsDoubleNotInRangeTest04()
        {
            Double a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x > upper bound' should pass.")]
        public void IsDoubleNotInRangeTest05()
        {
            Double a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with conditionDescription should pass.")]
        public void IsDoubleNotInRangeTest06()
        {
            Double a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotInRangeTest07()
        {
            Double a = Four;
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

        #endregion // IsDoubleNotInRange

        #region IsDoubleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should fail.")]
        public void IsDoubleGreaterThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleGreaterThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Double x with conditionDescription should pass.")]
        public void IsDoubleGreaterThanTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleGreaterThanTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleGreaterThan

        #region IsDoubleNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Double x with conditionDescription should pass.")]
        public void IsDoubleNotGreaterThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotGreaterThanTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleNotGreaterThan

        #region IsDoubleGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleGreaterOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleGreaterOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleGreaterOrEqualTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleGreaterOrEqualTest05()
        {
            Double a = One;
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

        #endregion // IsDoubleGreaterOrEqual

        #region IsDoubleNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleNotGreaterOrEqualTest04()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotGreaterOrEqualTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleNotGreaterOrEqual

        #region IsDoubleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleLessThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Double x with conditionDescription should pass.")]
        public void IsDoubleLessThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleLessThanTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleLessThan

        #region IsDoubleNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleNotLessThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Double x with conditionDescription should pass.")]
        public void IsDoubleNotLessThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotLessThanTest05()
        {
            Double a = Two;
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

        #endregion // IsDoubleNotLessThan

        #region IsDoubleLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleLessOrEqualTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleLessOrEqualTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleLessOrEqual

        #region IsDoubleNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleNotLessOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleNotLessOrEqualTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotLessOrEqualTest05()
        {
            Double a = Two;
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

        #region IsDoubleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x < other' should fail.")]
        public void IsDoubleEqualToTest01()
        {
            Double a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Double x with 'x = other' should pass.")]
        public void IsDoubleEqualToTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x > other' should fail.")]
        public void IsDoubleEqualToTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Double x with conditionDescription should pass.")]
        public void IsDoubleEqualToTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleEqualToTest05()
        {
            Double a = Three;
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

        #endregion // IsDoubleEqualTo

        #region IsDoubleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x < other' should pass.")]
        public void IsDoubleNotEqualToTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should fail.")]
        public void IsDoubleNotEqualToTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x > other' should pass.")]
        public void IsDoubleNotEqualToTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with conditionDescription should pass.")]
        public void IsDoubleNotEqualToTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotEqualToTest05()
        {
            Double a = Two;
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

        #endregion // IsDoubleNotEqualTo
    }
}