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
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest02()
        {
            Byte a = Two;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest03()
        {
            Byte a = Three;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest04()
        {
            Byte a = Four;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest05()
        {
            Byte a = Five;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with conditionDescription should pass.")]
        public void IsByteInRangeTest06()
        {
            Byte a = Four;
            a.Requires().IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteInRangeTest07()
        {
            Byte a = Five;
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

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest01()
        {
            Byte a = One;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest02()
        {
            Byte a = Two;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest03()
        {
            Byte a = Three;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest04()
        {
            Byte a = Four;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest05()
        {
            Byte a = Five;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with conditionDescription should pass.")]
        public void IsByteNotInRangeTest06()
        {
            Byte a = Five;
            a.Requires().IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotInRangeTest07()
        {
            Byte a = Four;
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

        #endregion // IsByteNotInRange

        #region IsByteGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest01()
        {
            Byte a = One;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest02()
        {
            Byte a = Two;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest03()
        {
            Byte a = Three;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterThanTest04()
        {
            Byte a = Three;
            a.Requires().IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterThanTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteGreaterThan

        #region IsByteNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterThanTest01()
        {
            Byte a = One;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x = upper bound' should pass.")]
        public void IsByteNotGreaterThanTest02()
        {
            Byte a = Two;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterThanTest03()
        {
            Byte a = Three;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterThanTest04()
        {
            Byte a = Two;
            a.Requires().IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterThanTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteNotGreaterThan

        #region IsByteGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualTest01()
        {
            Byte a = One;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualTest02()
        {
            Byte a = Two;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualTest03()
        {
            Byte a = Three;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterOrEqualTest04()
        {
            Byte a = Three;
            a.Requires().IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterOrEqualTest05()
        {
            Byte a = One;
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

        #endregion // IsByteGreaterOrEqual

        #region IsByteNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterOrEqualTest01()
        {
            Byte a = One;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest02()
        {
            Byte a = Two;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest03()
        {
            Byte a = Three;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterOrEqualTest04()
        {
            Byte a = One;
            a.Requires().IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterOrEqualTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteNotGreaterOrEqual

        #region IsByteLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest01()
        {
            Byte a = One;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest02()
        {
            Byte a = Two;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest03()
        {
            Byte a = Three;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteLessThanTest04()
        {
            Byte a = Two;
            a.Requires().IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessThanTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteLessThan

        #region IsByteNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessThanTest01()
        {
            Byte a = One;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound = x' should pass.")]
        public void IsByteNotLessThanTest02()
        {
            Byte a = Two;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessThanTest03()
        {
            Byte a = Three;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessThanTest04()
        {
            Byte a = Two;
            a.Requires().IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessThanTest05()
        {
            Byte a = Two;
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

        #endregion // IsByteNotLessThan

        #region IsByteLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualTest01()
        {
            Byte a = One;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualTest02()
        {
            Byte a = Two;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualTest03()
        {
            Byte a = Three;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteLessOrEqualTest04()
        {
            Byte a = Two;
            a.Requires().IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessOrEqualTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteLessOrEqual

        #region IsByteNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessOrEqualTest01()
        {
            Byte a = One;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound = x' should fail.")]
        public void IsByteNotLessOrEqualTest02()
        {
            Byte a = Two;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessOrEqualTest03()
        {
            Byte a = Three;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessOrEqualTest04()
        {
            Byte a = Three;
            a.Requires().IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessOrEqualTest05()
        {
            Byte a = Two;
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

        #region IsByteEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest01()
        {
            Byte a = One;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest02()
        {
            Byte a = Two;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest03()
        {
            Byte a = Three;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteEqualToTest04()
        {
            Byte a = Two;
            a.Requires().IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteEqualToTest05()
        {
            Byte a = Three;
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

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest01()
        {
            Byte a = One;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest02()
        {
            Byte a = Two;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest03()
        {
            Byte a = Three;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteNotEqualToTest04()
        {
            Byte a = Three;
            a.Requires().IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotEqualToTest05()
        {
            Byte a = Two;
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

        #endregion // IsByteNotEqualTo
    }
}