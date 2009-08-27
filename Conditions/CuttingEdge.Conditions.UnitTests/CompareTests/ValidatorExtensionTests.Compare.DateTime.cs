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
// with 'DateTime'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareDateTimeTests
    {
        private static readonly DateTime One = new DateTime(2000, 1, 1);
        private static readonly DateTime Two = new DateTime(2000, 1, 2);
        private static readonly DateTime Three = new DateTime(2000, 1, 3);
        private static readonly DateTime Four = new DateTime(2000, 1, 4);
        private static readonly DateTime Five = new DateTime(2000, 1, 5);

        #region IsDateTimeInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should fail.")]
        public void IsDateTimeInRangeTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound = x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x = upper bound' should pass.")]
        public void IsDateTimeInRangeTest04()
        {
            DateTime a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x > upper bound' should fail.")]
        public void IsDateTimeInRangeTest05()
        {
            DateTime a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeInRangeTest06()
        {
            DateTime a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeInRangeTest07()
        {
            DateTime a = Five;
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

        #endregion // IsDateTimeInRange

        #region IsDateTimeNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound > x < upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x = upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest04()
        {
            DateTime a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x > upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest05()
        {
            DateTime a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotInRangeTest06()
        {
            DateTime a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotInRangeTest07()
        {
            DateTime a = Four;
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

        #endregion // IsDateTimeNotInRange

        #region IsDateTimeGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should fail.")]
        public void IsDateTimeGreaterThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeGreaterThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeGreaterThanTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeGreaterThanTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeGreaterThan

        #region IsDateTimeNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotGreaterThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotGreaterThanTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeNotGreaterThan

        #region IsDateTimeGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeGreaterOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeGreaterOrEqualTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeGreaterOrEqualTest05()
        {
            DateTime a = One;
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

        #endregion // IsDateTimeGreaterOrEqual

        #region IsDateTimeNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotGreaterOrEqualTest04()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotGreaterOrEqualTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeNotGreaterOrEqual

        #region IsDateTimeLessThan

        [TestMethod]
        [Description("Calling IsLessThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeLessThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeLessThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeLessThanTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeLessThan

        #region IsDateTimeNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeNotLessThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotLessThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotLessThanTest05()
        {
            DateTime a = Two;
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

        #endregion // IsDateTimeNotLessThan

        #region IsDateTimeLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeLessOrEqualTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeLessOrEqualTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeLessOrEqual

        #region IsDateTimeNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotLessOrEqualTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotLessOrEqualTest05()
        {
            DateTime a = Two;
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

        #region IsDateTimeEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should fail.")]
        public void IsDateTimeEqualToTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on DateTime x with 'x = other' should pass.")]
        public void IsDateTimeEqualToTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x > other' should fail.")]
        public void IsDateTimeEqualToTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeEqualToTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeEqualToTest05()
        {
            DateTime a = Three;
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

        #endregion // IsDateTimeEqualTo

        #region IsDateTimeNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x < other' should pass.")]
        public void IsDateTimeNotEqualToTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should fail.")]
        public void IsDateTimeNotEqualToTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x > other' should pass.")]
        public void IsDateTimeNotEqualToTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotEqualToTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotEqualToTest05()
        {
            DateTime a = Two;
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

        #endregion // IsDateTimeNotEqualTo
    }
}