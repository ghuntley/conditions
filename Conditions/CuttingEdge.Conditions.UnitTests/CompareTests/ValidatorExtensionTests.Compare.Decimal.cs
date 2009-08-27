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
// with 'Decimal'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareDecimalTests
    {
        private static readonly Decimal One = 1;
        private static readonly Decimal Two = 2;
        private static readonly Decimal Three = 3;
        private static readonly Decimal Four = 4;
        private static readonly Decimal Five = 5;

        #region IsDecimalInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should fail.")]
        public void IsDecimalInRangeTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound = x < upper bound' should pass.")]
        public void IsDecimalInRangeTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x < upper bound' should pass.")]
        public void IsDecimalInRangeTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x = upper bound' should pass.")]
        public void IsDecimalInRangeTest04()
        {
            Decimal a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x > upper bound' should fail.")]
        public void IsDecimalInRangeTest05()
        {
            Decimal a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalInRangeTest06()
        {
            Decimal a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalInRangeTest07()
        {
            Decimal a = Five;
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

        #endregion // IsDecimalInRange

        #region IsDecimalNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound > x < upper bound' should pass.")]
        public void IsDecimalNotInRangeTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x = upper bound' should fail.")]
        public void IsDecimalNotInRangeTest04()
        {
            Decimal a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsDecimalNotInRangeTest05()
        {
            Decimal a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotInRangeTest06()
        {
            Decimal a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotInRangeTest07()
        {
            Decimal a = Four;
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

        #endregion // IsDecimalNotInRange

        #region IsDecimalGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should fail.")]
        public void IsDecimalGreaterThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalGreaterThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterThanTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterThanTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalGreaterThan

        #region IsDecimalNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterThanTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalNotGreaterThan

        #region IsDecimalGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalGreaterOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalGreaterOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterOrEqualTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterOrEqualTest05()
        {
            Decimal a = One;
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

        #endregion // IsDecimalGreaterOrEqual

        #region IsDecimalNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterOrEqualTest04()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterOrEqualTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalNotGreaterOrEqual

        #region IsDecimalLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalLessThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessThanTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalLessThan

        #region IsDecimalNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalNotLessThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessThanTest05()
        {
            Decimal a = Two;
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

        #endregion // IsDecimalNotLessThan

        #region IsDecimalLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessOrEqualTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessOrEqualTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalLessOrEqual

        #region IsDecimalNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalNotLessOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessOrEqualTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessOrEqualTest05()
        {
            Decimal a = Two;
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

        #region IsDecimalEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should fail.")]
        public void IsDecimalEqualToTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with 'x = other' should pass.")]
        public void IsDecimalEqualToTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x > other' should fail.")]
        public void IsDecimalEqualToTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalEqualToTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalEqualToTest05()
        {
            Decimal a = Three;
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

        #endregion // IsDecimalEqualTo

        #region IsDecimalNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x < other' should pass.")]
        public void IsDecimalNotEqualToTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should fail.")]
        public void IsDecimalNotEqualToTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x > other' should pass.")]
        public void IsDecimalNotEqualToTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotEqualToTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotEqualToTest05()
        {
            Decimal a = Two;
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

        #endregion // IsDecimalNotEqualTo
    }
}