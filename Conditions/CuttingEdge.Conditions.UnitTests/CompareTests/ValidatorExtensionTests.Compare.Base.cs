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
// with 'XXX'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsXXXInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on XXX x with 'lower bound > x < upper bound' should fail.")]
        public void IsXXXInRangeTest01()
        {
            XXX a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound = x < upper bound' should pass.")]
        public void IsXXXInRangeTest02()
        {
            XXX a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound < x < upper bound' should pass.")]
        public void IsXXXInRangeTest03()
        {
            XXX a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on XXX x with 'lower bound < x = upper bound' should pass.")]
        public void IsXXXInRangeTest04()
        {
            XXX a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on XXX x with 'lower bound < x > upper bound' should fail.")]
        public void IsXXXInRangeTest05()
        {
            XXX a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsXXXInRange

        #region IsXXXNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on XXX x with 'lower bound > x < upper bound' should pass.")]
        public void IsXXXNotInRangeTest01()
        {
            XXX a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound = x < upper bound' should fail.")]
        public void IsXXXNotInRangeTest02()
        {
            XXX a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x < upper bound' should fail.")]
        public void IsXXXNotInRangeTest03()
        {
            XXX a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x = upper bound' should fail.")]
        public void IsXXXNotInRangeTest04()
        {
            XXX a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on XXX x with 'lower bound < x > upper bound' should pass.")]
        public void IsXXXNotInRangeTest05()
        {
            XXX a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsXXXNotInRange

        #region IsXXXGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound < x' should fail.")]
        public void IsXXXGreaterThanTest01()
        {
            XXX a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound = x' should fail.")]
        public void IsXXXGreaterThanTest02()
        {
            XXX a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXGreaterThanTest03()
        {
            XXX a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsXXXGreaterThan

        #region IsXXXNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXNotGreaterThanTest01()
        {
            XXX a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on XXX x with 'x = upper bound' should pass.")]
        public void IsXXXNotGreaterThanTest02()
        {
            XXX a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXNotGreaterThanTest03()
        {
            XXX a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsXXXNotGreaterThan

        #region IsXXXGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXGreaterOrEqualTest01()
        {
            XXX a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound = x' should pass.")]
        public void IsXXXGreaterOrEqualTest02()
        {
            XXX a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXGreaterOrEqualTest03()
        {
            XXX a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsXXXGreaterOrEqual

        #region IsXXXNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXNotGreaterOrEqualTest01()
        {
            XXX a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x = upper bound' should fail.")]
        public void IsXXXNotGreaterOrEqualTest02()
        {
            XXX a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXNotGreaterOrEqualTest03()
        {
            XXX a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsXXXNotGreaterOrEqual

        #region IsXXXLessThan

        [TestMethod]
        [Description("Calling IsLessThan on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXLessThanTest01()
        {
            XXX a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on XXX x with 'x = upper bound' should fail.")]
        public void IsXXXLessThanTest02()
        {
            XXX a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXLessThanTest03()
        {
            XXX a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsXXXLessThan

        #region IsXXXNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXNotLessThanTest01()
        {
            XXX a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound = x' should pass.")]
        public void IsXXXNotLessThanTest02()
        {
            XXX a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXNotLessThanTest03()
        {
            XXX a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsXXXNotLessThan

        #region IsXXXLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on XXX x with 'x < upper bound' should pass.")]
        public void IsXXXLessOrEqualTest01()
        {
            XXX a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on XXX x with 'x = upper bound' should pass.")]
        public void IsXXXLessOrEqualTest02()
        {
            XXX a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on XXX x with 'x > upper bound' should fail.")]
        public void IsXXXLessOrEqualTest03()
        {
            XXX a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsXXXLessOrEqual

        #region IsXXXNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound > x' should fail.")]
        public void IsXXXNotLessOrEqualTest01()
        {
            XXX a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound = x' should fail.")]
        public void IsXXXNotLessOrEqualTest02()
        {
            XXX a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on XXX x with 'lower bound < x' should pass.")]
        public void IsXXXNotLessOrEqualTest03()
        {
            XXX a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsXXXEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on XXX x with 'x < other' should fail.")]
        public void IsXXXEqualToTest01()
        {
            XXX a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on XXX x with 'x = other' should pass.")]
        public void IsXXXEqualToTest02()
        {
            XXX a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on XXX x with 'x > other' should fail.")]
        public void IsXXXEqualToTest03()
        {
            XXX a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsXXXEqualTo

        #region IsXXXNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on XXX x with 'x < other' should pass.")]
        public void IsXXXNotEqualToTest01()
        {
            XXX a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on XXX x with 'x = other' should fail.")]
        public void IsXXXNotEqualToTest02()
        {
            XXX a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on XXX x with 'x > other' should pass.")]
        public void IsXXXNotEqualToTest03()
        {
            XXX a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsXXXNotEqualTo
    }
}