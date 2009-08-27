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
// with 'Int32'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareInt32Tests
    {
        private static readonly Int32 One = 1;
        private static readonly Int32 Two = 2;
        private static readonly Int32 Three = 3;
        private static readonly Int32 Four = 4;
        private static readonly Int32 Five = 5;

        #region IsInt32InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt32InRangeTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt32InRangeTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt32InRangeTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt32InRangeTest04()
        {
            Int32 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt32InRangeTest05()
        {
            Int32 a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with conditionDescription should pass.")]
        public void IsInt32InRangeTest06()
        {
            Int32 a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32InRangeTest07()
        {
            Int32 a = Five;
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

        #endregion // IsInt32InRange

        #region IsInt32NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt32NotInRangeTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt32NotInRangeTest04()
        {
            Int32 a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt32NotInRangeTest05()
        {
            Int32 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotInRangeTest06()
        {
            Int32 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotInRangeTest07()
        {
            Int32 a = Four;
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

        #endregion // IsInt32NotInRange

        #region IsInt32GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should fail.")]
        public void IsInt32GreaterThanTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound = x' should fail.")]
        public void IsInt32GreaterThanTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterThanTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int32 x with conditionDescription should pass.")]
        public void IsInt32GreaterThanTest04()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32GreaterThanTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32GreaterThan

        #region IsInt32NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32NotGreaterThanTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x = upper bound' should pass.")]
        public void IsInt32NotGreaterThanTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32NotGreaterThanTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotGreaterThanTest04()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotGreaterThanTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32NotGreaterThan

        #region IsInt32GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32GreaterOrEqualTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound = x' should pass.")]
        public void IsInt32GreaterOrEqualTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterOrEqualTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with conditionDescription should pass.")]
        public void IsInt32GreaterOrEqualTest04()
        {
            Int32 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32GreaterOrEqualTest05()
        {
            Int32 a = One;
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

        #endregion // IsInt32GreaterOrEqual

        #region IsInt32NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32NotGreaterOrEqualTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x = upper bound' should fail.")]
        public void IsInt32NotGreaterOrEqualTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32NotGreaterOrEqualTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotGreaterOrEqualTest04()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotGreaterOrEqualTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32NotGreaterOrEqual

        #region IsInt32LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessThanTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x = upper bound' should fail.")]
        public void IsInt32LessThanTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessThanTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int32 x with conditionDescription should pass.")]
        public void IsInt32LessThanTest04()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32LessThanTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32LessThan

        #region IsInt32NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32NotLessThanTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound = x' should pass.")]
        public void IsInt32NotLessThanTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32NotLessThanTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotLessThanTest04()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotLessThanTest05()
        {
            Int32 a = Two;
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

        #endregion // IsInt32NotLessThan

        #region IsInt32LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessOrEqualTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with 'x = upper bound' should pass.")]
        public void IsInt32LessOrEqualTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessOrEqualTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with conditionDescription should pass.")]
        public void IsInt32LessOrEqualTest04()
        {
            Int32 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32LessOrEqualTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32LessOrEqual

        #region IsInt32NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32NotLessOrEqualTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound = x' should fail.")]
        public void IsInt32NotLessOrEqualTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32NotLessOrEqualTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotLessOrEqualTest04()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotLessOrEqualTest05()
        {
            Int32 a = Two;
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

        #region IsInt32EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x < other' should fail.")]
        public void IsInt32EqualToTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int32 x with 'x = other' should pass.")]
        public void IsInt32EqualToTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x > other' should fail.")]
        public void IsInt32EqualToTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int32 x with conditionDescription should pass.")]
        public void IsInt32EqualToTest04()
        {
            Int32 a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32EqualToTest05()
        {
            Int32 a = Three;
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

        #endregion // IsInt32EqualTo

        #region IsInt32NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x < other' should pass.")]
        public void IsInt32NotEqualToTest01()
        {
            Int32 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int32 x with 'x = other' should fail.")]
        public void IsInt32NotEqualToTest02()
        {
            Int32 a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x > other' should pass.")]
        public void IsInt32NotEqualToTest03()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with conditionDescription should pass.")]
        public void IsInt32NotEqualToTest04()
        {
            Int32 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Int32 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt32NotEqualToTest05()
        {
            Int32 a = Two;
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

        #endregion // IsInt32NotEqualTo
    }
}