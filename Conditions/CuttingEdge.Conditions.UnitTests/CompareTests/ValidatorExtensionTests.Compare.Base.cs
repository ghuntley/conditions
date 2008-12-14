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
// with 'XXX'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareXXXTests
    {
        private static readonly XXX One = 1;
        private static readonly XXX Two = 2;
        private static readonly XXX Three = 3;
        private static readonly XXX Four = 4;
        private static readonly XXX Five = 5;

        #region IsXXXInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on XXX x with 'lower bound > x < upper bound' should fail.")]
        public void IsXXXInRangeTest01()
        {
            XXX a = One;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound = x < upper bound' should pass.")]
        public void IsXXXInRangeTest02()
        {
            XXX a = Two;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound < x < upper bound' should pass.")]
        public void IsXXXInRangeTest03()
        {
            XXX a = Three;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound < x = upper bound' should pass.")]
        public void IsXXXInRangeTest04()
        {
            XXX a = Four;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on XXX x with 'lower bound < x > upper bound' should fail.")]
        public void IsXXXInRangeTest05()
        {
            XXX a = Five;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with conditionDescription should pass.")]
        public void IsXXXInRangeTest06()
        {
            XXX a = Four;
            a.Requires().IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXInRangeTest07()
        {
            XXX a = Five;
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

        #endregion // IsXXXInRange

        #region IsXXXNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on XXX x with 'lower bound > x < upper bound' should pass.")]
        public void IsXXXNotInRangeTest01()
        {
            XXX a = One;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound = x < upper bound' should fail.")]
        public void IsXXXNotInRangeTest02()
        {
            XXX a = Two;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x < upper bound' should fail.")]
        public void IsXXXNotInRangeTest03()
        {
            XXX a = Three;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x = upper bound' should fail.")]
        public void IsXXXNotInRangeTest04()
        {
            XXX a = Four;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x > upper bound' should pass.")]
        public void IsXXXNotInRangeTest05()
        {
            XXX a = Five;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on XXX x with conditionDescription should pass.")]
        public void IsXXXNotInRangeTest06()
        {
            XXX a = Five;
            a.Requires().IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotInRangeTest07()
        {
            XXX a = Four;
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

        #endregion // IsXXXNotInRange

        #region IsXXXGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound < x' should fail.")]
        public void IsXXXGreaterThanTest01()
        {
            XXX a = One;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound = x' should fail.")]
        public void IsXXXGreaterThanTest02()
        {
            XXX a = Two;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXGreaterThanTest03()
        {
            XXX a = Three;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on XXX x with conditionDescription should pass.")]
        public void IsXXXGreaterThanTest04()
        {
            XXX a = Three;
            a.Requires().IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXGreaterThanTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXGreaterThan

        #region IsXXXNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXNotGreaterThanTest01()
        {
            XXX a = One;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on XXX x with 'x = upper bound' should pass.")]
        public void IsXXXNotGreaterThanTest02()
        {
            XXX a = Two;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXNotGreaterThanTest03()
        {
            XXX a = Three;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on XXX x with conditionDescription should pass.")]
        public void IsXXXNotGreaterThanTest04()
        {
            XXX a = Two;
            a.Requires().IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotGreaterThanTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXNotGreaterThan

        #region IsXXXGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXGreaterOrEqualTest01()
        {
            XXX a = One;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound = x' should pass.")]
        public void IsXXXGreaterOrEqualTest02()
        {
            XXX a = Two;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXGreaterOrEqualTest03()
        {
            XXX a = Three;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on XXX x with conditionDescription should pass.")]
        public void IsXXXGreaterOrEqualTest04()
        {
            XXX a = Three;
            a.Requires().IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXGreaterOrEqualTest05()
        {
            XXX a = One;
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

        #endregion // IsXXXGreaterOrEqual

        #region IsXXXNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXNotGreaterOrEqualTest01()
        {
            XXX a = One;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x = upper bound' should fail.")]
        public void IsXXXNotGreaterOrEqualTest02()
        {
            XXX a = Two;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXNotGreaterOrEqualTest03()
        {
            XXX a = Three;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on XXX x with conditionDescription should pass.")]
        public void IsXXXNotGreaterOrEqualTest04()
        {
            XXX a = One;
            a.Requires().IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotGreaterOrEqualTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXNotGreaterOrEqual

        #region IsXXXLessThan

        [TestMethod]
        [Description("Calling IsLessThan on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXLessThanTest01()
        {
            XXX a = One;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on XXX x with 'x = upper bound' should fail.")]
        public void IsXXXLessThanTest02()
        {
            XXX a = Two;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXLessThanTest03()
        {
            XXX a = Three;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on XXX x with conditionDescription should pass.")]
        public void IsXXXLessThanTest04()
        {
            XXX a = Two;
            a.Requires().IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXLessThanTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXLessThan

        #region IsXXXNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXNotLessThanTest01()
        {
            XXX a = One;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound = x' should pass.")]
        public void IsXXXNotLessThanTest02()
        {
            XXX a = Two;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXNotLessThanTest03()
        {
            XXX a = Three;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on XXX x with conditionDescription should pass.")]
        public void IsXXXNotLessThanTest04()
        {
            XXX a = Two;
            a.Requires().IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotLessThanTest05()
        {
            XXX a = Two;
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

        #endregion // IsXXXNotLessThan

        #region IsXXXLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXLessOrEqualTest01()
        {
            XXX a = One;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on XXX x with 'x = upper bound' should pass.")]
        public void IsXXXLessOrEqualTest02()
        {
            XXX a = Two;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXLessOrEqualTest03()
        {
            XXX a = Three;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on XXX x with conditionDescription should pass.")]
        public void IsXXXLessOrEqualTest04()
        {
            XXX a = Two;
            a.Requires().IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXLessOrEqualTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXLessOrEqual

        #region IsXXXNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXNotLessOrEqualTest01()
        {
            XXX a = One;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound = x' should fail.")]
        public void IsXXXNotLessOrEqualTest02()
        {
            XXX a = Two;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXNotLessOrEqualTest03()
        {
            XXX a = Three;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on XXX x with conditionDescription should pass.")]
        public void IsXXXNotLessOrEqualTest04()
        {
            XXX a = Three;
            a.Requires().IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotLessOrEqualTest05()
        {
            XXX a = Two;
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

        #region IsXXXEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on XXX x with 'x < other' should fail.")]
        public void IsXXXEqualToTest01()
        {
            XXX a = One;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on XXX x with 'x = other' should pass.")]
        public void IsXXXEqualToTest02()
        {
            XXX a = Two;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on XXX x with 'x > other' should fail.")]
        public void IsXXXEqualToTest03()
        {
            XXX a = Three;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on XXX x with conditionDescription should pass.")]
        public void IsXXXEqualToTest04()
        {
            XXX a = Two;
            a.Requires().IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXEqualToTest05()
        {
            XXX a = Three;
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

        #endregion // IsXXXEqualTo

        #region IsXXXNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on XXX x with 'x < other' should pass.")]
        public void IsXXXNotEqualToTest01()
        {
            XXX a = One;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on XXX x with 'x = other' should fail.")]
        public void IsXXXNotEqualToTest02()
        {
            XXX a = Two;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on XXX x with 'x > other' should pass.")]
        public void IsXXXNotEqualToTest03()
        {
            XXX a = Three;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on XXX x with conditionDescription should pass.")]
        public void IsXXXNotEqualToTest04()
        {
            XXX a = Three;
            a.Requires().IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on XXX should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsXXXNotEqualToTest05()
        {
            XXX a = Two;
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

        #endregion // IsXXXNotEqualTo
    }
}