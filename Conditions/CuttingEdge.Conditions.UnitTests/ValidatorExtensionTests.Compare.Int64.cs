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
// with 'Int64'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsInt64InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt64InRangeTest01()
        {
            Int64 a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt64InRangeTest02()
        {
            Int64 a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt64InRangeTest03()
        {
            Int64 a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt64InRangeTest04()
        {
            Int64 a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt64InRangeTest05()
        {
            Int64 a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsInt64InRange

        #region IsInt64NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt64NotInRangeTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt64NotInRangeTest04()
        {
            Int64 a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt64NotInRangeTest05()
        {
            Int64 a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsInt64NotInRange

        #region IsInt64GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should fail.")]
        public void IsInt64GreaterThanTest01()
        {
            Int64 a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64GreaterThanTest02()
        {
            Int64 a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterThanTest03()
        {
            Int64 a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsInt64GreaterThan

        #region IsInt64NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterThanTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsInt64NotGreaterThan

        #region IsInt64GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64GreaterOrEqualTest01()
        {
            Int64 a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64GreaterOrEqualTest02()
        {
            Int64 a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterOrEqualTest03()
        {
            Int64 a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsInt64GreaterOrEqual

        #region IsInt64NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterOrEqualTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsInt64NotGreaterOrEqual

        #region IsInt64LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessThanTest01()
        {
            Int64 a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64LessThanTest02()
        {
            Int64 a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessThanTest03()
        {
            Int64 a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsInt64LessThan

        #region IsInt64NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessThanTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64NotLessThanTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessThanTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsInt64NotLessThan

        #region IsInt64LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessOrEqualTest01()
        {
            Int64 a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64LessOrEqualTest02()
        {
            Int64 a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessOrEqualTest03()
        {
            Int64 a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsInt64LessOrEqual

        #region IsInt64NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessOrEqualTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64NotLessOrEqualTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessOrEqualTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt64EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should fail.")]
        public void IsInt64EqualToTest01()
        {
            Int64 a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int64 x with 'x = other' should pass.")]
        public void IsInt64EqualToTest02()
        {
            Int64 a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int64 x with 'x > other' should fail.")]
        public void IsInt64EqualToTest03()
        {
            Int64 a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsInt64EqualTo

        #region IsInt64NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x < other' should pass.")]
        public void IsInt64NotEqualToTest01()
        {
            Int64 a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should fail.")]
        public void IsInt64NotEqualToTest02()
        {
            Int64 a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int64 x with 'x > other' should pass.")]
        public void IsInt64NotEqualToTest03()
        {
            Int64 a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsInt64NotEqualTo
    }
}