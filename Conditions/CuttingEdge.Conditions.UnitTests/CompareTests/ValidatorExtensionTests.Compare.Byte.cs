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
// with 'Byte'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareByteTests
    {
        #region IsByteInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should fail.")]
        public void IsByteInRangeTest01()
        {
            Byte a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest02()
        {
            Byte a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest03()
        {
            Byte a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest04()
        {
            Byte a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest05()
        {
            Byte a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest01()
        {
            Byte a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest02()
        {
            Byte a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest03()
        {
            Byte a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest04()
        {
            Byte a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest05()
        {
            Byte a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsByteNotInRange

        #region IsByteGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest01()
        {
            Byte a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest02()
        {
            Byte a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest03()
        {
            Byte a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsByteGreaterThan

        #region IsByteNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterThanTest01()
        {
            Byte a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x = upper bound' should pass.")]
        public void IsByteNotGreaterThanTest02()
        {
            Byte a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterThanTest03()
        {
            Byte a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsByteNotGreaterThan

        #region IsByteGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualTest01()
        {
            Byte a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualTest02()
        {
            Byte a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualTest03()
        {
            Byte a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsByteGreaterOrEqual

        #region IsByteNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterOrEqualTest01()
        {
            Byte a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest02()
        {
            Byte a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest03()
        {
            Byte a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsByteNotGreaterOrEqual

        #region IsByteLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest01()
        {
            Byte a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest02()
        {
            Byte a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest03()
        {
            Byte a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsByteLessThan

        #region IsByteNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessThanTest01()
        {
            Byte a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound = x' should pass.")]
        public void IsByteNotLessThanTest02()
        {
            Byte a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessThanTest03()
        {
            Byte a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsByteNotLessThan

        #region IsByteLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualTest01()
        {
            Byte a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualTest02()
        {
            Byte a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualTest03()
        {
            Byte a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsByteLessOrEqual

        #region IsByteNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessOrEqualTest01()
        {
            Byte a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound = x' should fail.")]
        public void IsByteNotLessOrEqualTest02()
        {
            Byte a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessOrEqualTest03()
        {
            Byte a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsByteEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest01()
        {
            Byte a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest02()
        {
            Byte a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest03()
        {
            Byte a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest01()
        {
            Byte a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest02()
        {
            Byte a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest03()
        {
            Byte a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsByteNotEqualTo
    }
}