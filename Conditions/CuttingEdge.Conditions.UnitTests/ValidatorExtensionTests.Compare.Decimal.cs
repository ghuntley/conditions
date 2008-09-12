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
// with 'Decimal'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsDecimalInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should fail.")]
        public void IsDecimalInRangeTest01()
        {
            Decimal a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound = x < upper bound' should pass.")]
        public void IsDecimalInRangeTest02()
        {
            Decimal a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x < upper bound' should pass.")]
        public void IsDecimalInRangeTest03()
        {
            Decimal a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x = upper bound' should pass.")]
        public void IsDecimalInRangeTest04()
        {
            Decimal a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x > upper bound' should fail.")]
        public void IsDecimalInRangeTest05()
        {
            Decimal a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsDecimalInRange

        #region IsDecimalNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound > x < upper bound' should pass.")]
        public void IsDecimalNotInRangeTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x = upper bound' should fail.")]
        public void IsDecimalNotInRangeTest04()
        {
            Decimal a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsDecimalNotInRangeTest05()
        {
            Decimal a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsDecimalNotInRange

        #region IsDecimalGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should fail.")]
        public void IsDecimalGreaterThanTest01()
        {
            Decimal a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalGreaterThanTest02()
        {
            Decimal a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterThanTest03()
        {
            Decimal a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsDecimalGreaterThan

        #region IsDecimalNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterThanTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsDecimalNotGreaterThan

        #region IsDecimalGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalGreaterOrEqualTest01()
        {
            Decimal a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalGreaterOrEqualTest02()
        {
            Decimal a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterOrEqualTest03()
        {
            Decimal a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsDecimalGreaterOrEqual

        #region IsDecimalNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterOrEqualTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsDecimalNotGreaterOrEqual

        #region IsDecimalLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessThanTest01()
        {
            Decimal a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalLessThanTest02()
        {
            Decimal a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessThanTest03()
        {
            Decimal a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsDecimalLessThan

        #region IsDecimalNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessThanTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalNotLessThanTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessThanTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsDecimalNotLessThan

        #region IsDecimalLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest01()
        {
            Decimal a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest02()
        {
            Decimal a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessOrEqualTest03()
        {
            Decimal a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsDecimalLessOrEqual

        #region IsDecimalNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessOrEqualTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalNotLessOrEqualTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessOrEqualTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsDecimalEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should fail.")]
        public void IsDecimalEqualToTest01()
        {
            Decimal a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with 'x = other' should pass.")]
        public void IsDecimalEqualToTest02()
        {
            Decimal a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x > other' should fail.")]
        public void IsDecimalEqualToTest03()
        {
            Decimal a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsDecimalEqualTo

        #region IsDecimalNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x < other' should pass.")]
        public void IsDecimalNotEqualToTest01()
        {
            Decimal a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should fail.")]
        public void IsDecimalNotEqualToTest02()
        {
            Decimal a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x > other' should pass.")]
        public void IsDecimalNotEqualToTest03()
        {
            Decimal a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsDecimalNotEqualTo
    }
}