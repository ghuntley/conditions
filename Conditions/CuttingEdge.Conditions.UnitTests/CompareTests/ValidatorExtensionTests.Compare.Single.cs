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
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound = x < upper bound' should pass.")]
        public void IsSingleInRangeTest02()
        {
            Single a = Two;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x < upper bound' should pass.")]
        public void IsSingleInRangeTest03()
        {
            Single a = Three;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x = upper bound' should pass.")]
        public void IsSingleInRangeTest04()
        {
            Single a = Four;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound < x > upper bound' should fail.")]
        public void IsSingleInRangeTest05()
        {
            Single a = Five;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with conditionDescription should pass.")]
        public void IsSingleInRangeTest06()
        {
            Single a = Four;
            a.Requires().IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleInRangeTest07()
        {
            Single a = Five;
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

        #endregion // IsSingleInRange

        #region IsSingleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound > x < upper bound' should pass.")]
        public void IsSingleNotInRangeTest01()
        {
            Single a = One;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest02()
        {
            Single a = Two;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest03()
        {
            Single a = Three;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x = upper bound' should fail.")]
        public void IsSingleNotInRangeTest04()
        {
            Single a = Four;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x > upper bound' should pass.")]
        public void IsSingleNotInRangeTest05()
        {
            Single a = Five;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with conditionDescription should pass.")]
        public void IsSingleNotInRangeTest06()
        {
            Single a = Five;
            a.Requires().IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotInRangeTest07()
        {
            Single a = Four;
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

        #endregion // IsSingleNotInRange

        #region IsSingleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should fail.")]
        public void IsSingleGreaterThanTest01()
        {
            Single a = One;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound = x' should fail.")]
        public void IsSingleGreaterThanTest02()
        {
            Single a = Two;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterThanTest03()
        {
            Single a = Three;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterThanTest04()
        {
            Single a = Three;
            a.Requires().IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterThanTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleGreaterThan

        #region IsSingleNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest01()
        {
            Single a = One;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x = upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest02()
        {
            Single a = Two;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterThanTest03()
        {
            Single a = Three;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterThanTest04()
        {
            Single a = Two;
            a.Requires().IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterThanTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleNotGreaterThan

        #region IsSingleGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleGreaterOrEqualTest01()
        {
            Single a = One;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound = x' should pass.")]
        public void IsSingleGreaterOrEqualTest02()
        {
            Single a = Two;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterOrEqualTest03()
        {
            Single a = Three;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterOrEqualTest04()
        {
            Single a = Three;
            a.Requires().IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterOrEqualTest05()
        {
            Single a = One;
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

        #endregion // IsSingleGreaterOrEqual

        #region IsSingleNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterOrEqualTest01()
        {
            Single a = One;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest02()
        {
            Single a = Two;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest03()
        {
            Single a = Three;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterOrEqualTest04()
        {
            Single a = One;
            a.Requires().IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterOrEqualTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleNotGreaterOrEqual

        #region IsSingleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessThanTest01()
        {
            Single a = One;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should fail.")]
        public void IsSingleLessThanTest02()
        {
            Single a = Two;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessThanTest03()
        {
            Single a = Three;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleLessThanTest04()
        {
            Single a = Two;
            a.Requires().IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessThanTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleLessThan

        #region IsSingleNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessThanTest01()
        {
            Single a = One;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound = x' should pass.")]
        public void IsSingleNotLessThanTest02()
        {
            Single a = Two;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessThanTest03()
        {
            Single a = Three;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessThanTest04()
        {
            Single a = Two;
            a.Requires().IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessThanTest05()
        {
            Single a = Two;
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

        #endregion // IsSingleNotLessThan

        #region IsSingleLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessOrEqualTest01()
        {
            Single a = One;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x = upper bound' should pass.")]
        public void IsSingleLessOrEqualTest02()
        {
            Single a = Two;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessOrEqualTest03()
        {
            Single a = Three;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleLessOrEqualTest04()
        {
            Single a = Two;
            a.Requires().IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessOrEqualTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleLessOrEqual

        #region IsSingleNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessOrEqualTest01()
        {
            Single a = One;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound = x' should fail.")]
        public void IsSingleNotLessOrEqualTest02()
        {
            Single a = Two;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessOrEqualTest03()
        {
            Single a = Three;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessOrEqualTest04()
        {
            Single a = Three;
            a.Requires().IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessOrEqualTest05()
        {
            Single a = Two;
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

        #region IsSingleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x < other' should fail.")]
        public void IsSingleEqualToTest01()
        {
            Single a = One;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with 'x = other' should pass.")]
        public void IsSingleEqualToTest02()
        {
            Single a = Two;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x > other' should fail.")]
        public void IsSingleEqualToTest03()
        {
            Single a = Three;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleEqualToTest04()
        {
            Single a = Two;
            a.Requires().IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleEqualToTest05()
        {
            Single a = Three;
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

        #endregion // IsSingleEqualTo

        #region IsSingleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x < other' should pass.")]
        public void IsSingleNotEqualToTest01()
        {
            Single a = One;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should fail.")]
        public void IsSingleNotEqualToTest02()
        {
            Single a = Two;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x > other' should pass.")]
        public void IsSingleNotEqualToTest03()
        {
            Single a = Three;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleNotEqualToTest04()
        {
            Single a = Three;
            a.Requires().IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotEqualToTest05()
        {
            Single a = Two;
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

        #endregion // IsSingleNotEqualTo
    }
}