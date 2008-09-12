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

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Double'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsDoubleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should fail.")]
        public void IsDoubleInRangeTest01()
        {
            Double a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound = x < upper bound' should pass.")]
        public void IsDoubleInRangeTest02()
        {
            Double a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x < upper bound' should pass.")]
        public void IsDoubleInRangeTest03()
        {
            Double a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Double x with 'lower bound < x = upper bound' should pass.")]
        public void IsDoubleInRangeTest04()
        {
            Double a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Double x with 'lower bound < x > upper bound' should fail.")]
        public void IsDoubleInRangeTest05()
        {
            Double a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsDoubleInRange

        #region IsDoubleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound > x < upper bound' should pass.")]
        public void IsDoubleNotInRangeTest01()
        {
            Double a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest02()
        {
            Double a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest03()
        {
            Double a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x = upper bound' should fail.")]
        public void IsDoubleNotInRangeTest04()
        {
            Double a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x > upper bound' should pass.")]
        public void IsDoubleNotInRangeTest05()
        {
            Double a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsDoubleNotInRange

        #region IsDoubleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should fail.")]
        public void IsDoubleGreaterThanTest01()
        {
            Double a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleGreaterThanTest02()
        {
            Double a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterThanTest03()
        {
            Double a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsDoubleGreaterThan

        #region IsDoubleNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest01()
        {
            Double a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest02()
        {
            Double a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterThanTest03()
        {
            Double a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsDoubleNotGreaterThan

        #region IsDoubleGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleGreaterOrEqualTest01()
        {
            Double a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleGreaterOrEqualTest02()
        {
            Double a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterOrEqualTest03()
        {
            Double a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsDoubleGreaterOrEqual

        #region IsDoubleNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterOrEqualTest01()
        {
            Double a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest02()
        {
            Double a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest03()
        {
            Double a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsDoubleNotGreaterOrEqual

        #region IsDoubleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessThanTest01()
        {
            Double a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleLessThanTest02()
        {
            Double a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessThanTest03()
        {
            Double a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsDoubleLessThan

        #region IsDoubleNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessThanTest01()
        {
            Double a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleNotLessThanTest02()
        {
            Double a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessThanTest03()
        {
            Double a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsDoubleNotLessThan

        #region IsDoubleLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest01()
        {
            Double a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest02()
        {
            Double a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessOrEqualTest03()
        {
            Double a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsDoubleLessOrEqual

        #region IsDoubleNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessOrEqualTest01()
        {
            Double a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleNotLessOrEqualTest02()
        {
            Double a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessOrEqualTest03()
        {
            Double a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsDoubleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x < other' should fail.")]
        public void IsDoubleEqualToTest01()
        {
            Double a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Double x with 'x = other' should pass.")]
        public void IsDoubleEqualToTest02()
        {
            Double a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Double x with 'x > other' should fail.")]
        public void IsDoubleEqualToTest03()
        {
            Double a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsDoubleEqualTo

        #region IsDoubleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x < other' should pass.")]
        public void IsDoubleNotEqualToTest01()
        {
            Double a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should fail.")]
        public void IsDoubleNotEqualToTest02()
        {
            Double a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Double x with 'x > other' should pass.")]
        public void IsDoubleNotEqualToTest03()
        {
            Double a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsDoubleNotEqualTo
    }
}