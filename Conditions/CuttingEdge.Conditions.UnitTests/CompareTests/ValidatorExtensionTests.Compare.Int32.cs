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
// with 'Int32'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompateInt32Tests
    {
        #region IsInt32InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt32InRangeTest01()
        {
            Int32 a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt32InRangeTest02()
        {
            Int32 a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt32InRangeTest03()
        {
            Int32 a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt32InRangeTest04()
        {
            Int32 a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int32 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt32InRangeTest05()
        {
            Int32 a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsInt32InRange

        #region IsInt32NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt32NotInRangeTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt32NotInRangeTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt32NotInRangeTest04()
        {
            Int32 a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int32 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt32NotInRangeTest05()
        {
            Int32 a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsInt32NotInRange

        #region IsInt32GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should fail.")]
        public void IsInt32GreaterThanTest01()
        {
            Int32 a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound = x' should fail.")]
        public void IsInt32GreaterThanTest02()
        {
            Int32 a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterThanTest03()
        {
            Int32 a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsInt32GreaterThan

        #region IsInt32NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32NotGreaterThanTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x = upper bound' should pass.")]
        public void IsInt32NotGreaterThanTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32NotGreaterThanTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsInt32NotGreaterThan

        #region IsInt32GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32GreaterOrEqualTest01()
        {
            Int32 a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound = x' should pass.")]
        public void IsInt32GreaterOrEqualTest02()
        {
            Int32 a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32GreaterOrEqualTest03()
        {
            Int32 a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsInt32GreaterOrEqual

        #region IsInt32NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32NotGreaterOrEqualTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x = upper bound' should fail.")]
        public void IsInt32NotGreaterOrEqualTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32NotGreaterOrEqualTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsInt32NotGreaterOrEqual

        #region IsInt32LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessThanTest01()
        {
            Int32 a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x = upper bound' should fail.")]
        public void IsInt32LessThanTest02()
        {
            Int32 a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessThanTest03()
        {
            Int32 a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsInt32LessThan

        #region IsInt32NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32NotLessThanTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound = x' should pass.")]
        public void IsInt32NotLessThanTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32NotLessThanTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsInt32NotLessThan

        #region IsInt32LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with 'x < upper bound' should pass.")]
        public void IsInt32LessOrEqualTest01()
        {
            Int32 a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int32 x with 'x = upper bound' should pass.")]
        public void IsInt32LessOrEqualTest02()
        {
            Int32 a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int32 x with 'x > upper bound' should fail.")]
        public void IsInt32LessOrEqualTest03()
        {
            Int32 a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsInt32LessOrEqual

        #region IsInt32NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound > x' should fail.")]
        public void IsInt32NotLessOrEqualTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound = x' should fail.")]
        public void IsInt32NotLessOrEqualTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int32 x with 'lower bound < x' should pass.")]
        public void IsInt32NotLessOrEqualTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt32EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x < other' should fail.")]
        public void IsInt32EqualToTest01()
        {
            Int32 a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int32 x with 'x = other' should pass.")]
        public void IsInt32EqualToTest02()
        {
            Int32 a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int32 x with 'x > other' should fail.")]
        public void IsInt32EqualToTest03()
        {
            Int32 a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsInt32EqualTo

        #region IsInt32NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x < other' should pass.")]
        public void IsInt32NotEqualToTest01()
        {
            Int32 a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int32 x with 'x = other' should fail.")]
        public void IsInt32NotEqualToTest02()
        {
            Int32 a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int32 x with 'x > other' should pass.")]
        public void IsInt32NotEqualToTest03()
        {
            Int32 a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsInt32NotEqualTo
    }
}