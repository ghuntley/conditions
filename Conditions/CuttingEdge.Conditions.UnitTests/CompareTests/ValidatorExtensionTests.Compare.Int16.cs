#region Copyright (c) 2008 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * Copyright (C) 2008 S. van Deursen
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser 
 * General Public License as published by the Free Software Foundation; either version 2.1 of the License, or
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the 
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 * License for more details.
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
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt16InRangeTest02()
        {
            Int16 a = Two;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt16InRangeTest03()
        {
            Int16 a = Three;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt16InRangeTest04()
        {
            Int16 a = Four;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt16InRangeTest05()
        {
            Int16 a = Five;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16InRangeTest06()
        {
            Int16 a = Four;
            a.Requires().IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16InRangeTest07()
        {
            Int16 a = Five;
            try
            {
                a.Requires("a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16InRange

        #region IsInt16NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt16NotInRangeTest01()
        {
            Int16 a = One;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt16NotInRangeTest04()
        {
            Int16 a = Four;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt16NotInRangeTest05()
        {
            Int16 a = Five;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotInRangeTest06()
        {
            Int16 a = Five;
            a.Requires().IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotInRangeTest07()
        {
            Int16 a = Four;
            try
            {
                a.Requires("a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16NotInRange

        #region IsInt16GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should fail.")]
        public void IsInt16GreaterThanTest01()
        {
            Int16 a = One;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16GreaterThanTest02()
        {
            Int16 a = Two;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterThanTest03()
        {
            Int16 a = Three;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterThanTest04()
        {
            Int16 a = Three;
            a.Requires().IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterThanTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16GreaterThan

        #region IsInt16NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest01()
        {
            Int16 a = One;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterThanTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterThanTest04()
        {
            Int16 a = Two;
            a.Requires().IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterThanTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16NotGreaterThan

        #region IsInt16GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16GreaterOrEqualTest01()
        {
            Int16 a = One;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16GreaterOrEqualTest02()
        {
            Int16 a = Two;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterOrEqualTest03()
        {
            Int16 a = Three;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterOrEqualTest04()
        {
            Int16 a = Three;
            a.Requires().IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterOrEqualTest05()
        {
            Int16 a = One;
            try
            {
                a.Requires("a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16GreaterOrEqual

        #region IsInt16NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterOrEqualTest01()
        {
            Int16 a = One;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterOrEqualTest04()
        {
            Int16 a = One;
            a.Requires().IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterOrEqualTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16NotGreaterOrEqual

        #region IsInt16LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessThanTest01()
        {
            Int16 a = One;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16LessThanTest02()
        {
            Int16 a = Two;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessThanTest03()
        {
            Int16 a = Three;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessThanTest04()
        {
            Int16 a = Two;
            a.Requires().IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessThanTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsLessThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16LessThan

        #region IsInt16NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessThanTest01()
        {
            Int16 a = One;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16NotLessThanTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessThanTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessThanTest04()
        {
            Int16 a = Two;
            a.Requires().IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessThanTest05()
        {
            Int16 a = Two;
            try
            {
                a.Requires("a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16NotLessThan

        #region IsInt16LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessOrEqualTest01()
        {
            Int16 a = One;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16LessOrEqualTest02()
        {
            Int16 a = Two;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessOrEqualTest03()
        {
            Int16 a = Three;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessOrEqualTest04()
        {
            Int16 a = Two;
            a.Requires().IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessOrEqualTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16LessOrEqual

        #region IsInt16NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessOrEqualTest01()
        {
            Int16 a = One;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16NotLessOrEqualTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessOrEqualTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessOrEqualTest04()
        {
            Int16 a = Three;
            a.Requires().IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessOrEqualTest05()
        {
            Int16 a = Two;
            try
            {
                a.Requires("a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsNotLessOrEqual

        #region IsInt16EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should fail.")]
        public void IsInt16EqualToTest01()
        {
            Int16 a = One;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x = other' should pass.")]
        public void IsInt16EqualToTest02()
        {
            Int16 a = Two;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x > other' should fail.")]
        public void IsInt16EqualToTest03()
        {
            Int16 a = Three;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16EqualToTest04()
        {
            Int16 a = Two;
            a.Requires().IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16EqualToTest05()
        {
            Int16 a = Three;
            try
            {
                a.Requires("a").IsEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16EqualTo

        #region IsInt16NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x < other' should pass.")]
        public void IsInt16NotEqualToTest01()
        {
            Int16 a = One;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should fail.")]
        public void IsInt16NotEqualToTest02()
        {
            Int16 a = Two;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x > other' should pass.")]
        public void IsInt16NotEqualToTest03()
        {
            Int16 a = Three;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotEqualToTest04()
        {
            Int16 a = Three;
            a.Requires().IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotEqualToTest05()
        {
            Int16 a = Two;
            try
            {
                a.Requires("a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsInt16NotEqualTo
    }
}