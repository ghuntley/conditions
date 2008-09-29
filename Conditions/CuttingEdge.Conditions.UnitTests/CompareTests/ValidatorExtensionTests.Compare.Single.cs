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
// with 'Single'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareSingleTests
    {
        #region IsSingleInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should fail.")]
        public void IsSingleInRangeTest01()
        {
            Single a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound = x < upper bound' should pass.")]
        public void IsSingleInRangeTest02()
        {
            Single a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x < upper bound' should pass.")]
        public void IsSingleInRangeTest03()
        {
            Single a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Single x with 'lower bound < x = upper bound' should pass.")]
        public void IsSingleInRangeTest04()
        {
            Single a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Single x with 'lower bound < x > upper bound' should fail.")]
        public void IsSingleInRangeTest05()
        {
            Single a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsSingleInRange

        #region IsSingleNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound > x < upper bound' should pass.")]
        public void IsSingleNotInRangeTest01()
        {
            Single a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest02()
        {
            Single a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest03()
        {
            Single a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x = upper bound' should fail.")]
        public void IsSingleNotInRangeTest04()
        {
            Single a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x > upper bound' should pass.")]
        public void IsSingleNotInRangeTest05()
        {
            Single a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsSingleNotInRange

        #region IsSingleGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should fail.")]
        public void IsSingleGreaterThanTest01()
        {
            Single a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Single x with 'lower bound = x' should fail.")]
        public void IsSingleGreaterThanTest02()
        {
            Single a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterThanTest03()
        {
            Single a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsSingleGreaterThan

        #region IsSingleNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest01()
        {
            Single a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Single x with 'x = upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest02()
        {
            Single a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterThanTest03()
        {
            Single a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsSingleNotGreaterThan

        #region IsSingleGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleGreaterOrEqualTest01()
        {
            Single a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound = x' should pass.")]
        public void IsSingleGreaterOrEqualTest02()
        {
            Single a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterOrEqualTest03()
        {
            Single a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsSingleGreaterOrEqual

        #region IsSingleNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterOrEqualTest01()
        {
            Single a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest02()
        {
            Single a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest03()
        {
            Single a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsSingleNotGreaterOrEqual

        #region IsSingleLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessThanTest01()
        {
            Single a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should fail.")]
        public void IsSingleLessThanTest02()
        {
            Single a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessThanTest03()
        {
            Single a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsSingleLessThan

        #region IsSingleNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessThanTest01()
        {
            Single a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound = x' should pass.")]
        public void IsSingleNotLessThanTest02()
        {
            Single a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessThanTest03()
        {
            Single a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsSingleNotLessThan

        #region IsSingleLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessOrEqualTest01()
        {
            Single a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Single x with 'x = upper bound' should pass.")]
        public void IsSingleLessOrEqualTest02()
        {
            Single a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessOrEqualTest03()
        {
            Single a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsSingleLessOrEqual

        #region IsSingleNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessOrEqualTest01()
        {
            Single a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound = x' should fail.")]
        public void IsSingleNotLessOrEqualTest02()
        {
            Single a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessOrEqualTest03()
        {
            Single a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsSingleEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x < other' should fail.")]
        public void IsSingleEqualToTest01()
        {
            Single a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Single x with 'x = other' should pass.")]
        public void IsSingleEqualToTest02()
        {
            Single a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Single x with 'x > other' should fail.")]
        public void IsSingleEqualToTest03()
        {
            Single a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsSingleEqualTo

        #region IsSingleNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x < other' should pass.")]
        public void IsSingleNotEqualToTest01()
        {
            Single a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should fail.")]
        public void IsSingleNotEqualToTest02()
        {
            Single a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Single x with 'x > other' should pass.")]
        public void IsSingleNotEqualToTest03()
        {
            Single a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsSingleNotEqualTo
    }
}