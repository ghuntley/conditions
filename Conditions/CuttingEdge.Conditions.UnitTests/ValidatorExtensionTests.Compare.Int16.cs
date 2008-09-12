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
// with 'Int16'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsInt16InRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt16InRangeTest01()
        {
            Int16 a = 1;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt16InRangeTest02()
        {
            Int16 a = 2;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt16InRangeTest03()
        {
            Int16 a = 3;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt16InRangeTest04()
        {
            Int16 a = 4;
            a.Requires().IsInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt16InRangeTest05()
        {
            Int16 a = 5;
            a.Requires().IsInRange(2, 4);
        }

        #endregion // IsInt16InRange

        #region IsInt16NotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt16NotInRangeTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt16NotInRangeTest04()
        {
            Int16 a = 4;
            a.Requires().IsNotInRange(2, 4);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt16NotInRangeTest05()
        {
            Int16 a = 5;
            a.Requires().IsNotInRange(2, 4);
        }

        #endregion // IsInt16NotInRange

        #region IsInt16GreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should fail.")]
        public void IsInt16GreaterThanTest01()
        {
            Int16 a = 1;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16GreaterThanTest02()
        {
            Int16 a = 2;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterThanTest03()
        {
            Int16 a = 3;
            a.Requires().IsGreaterThan(2);
        }

        #endregion // IsInt16GreaterThan

        #region IsInt16NotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterThanTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        #endregion // IsInt16NotGreaterThan

        #region IsInt16GreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16GreaterOrEqualTest01()
        {
            Int16 a = 1;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16GreaterOrEqualTest02()
        {
            Int16 a = 2;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterOrEqualTest03()
        {
            Int16 a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        #endregion // IsInt16GreaterOrEqual

        #region IsInt16NotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterOrEqualTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        #endregion // IsInt16NotGreaterOrEqual

        #region IsInt16LessThan

        [TestMethod]
        [Description("Calling IsLessThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessThanTest01()
        {
            Int16 a = 1;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16LessThanTest02()
        {
            Int16 a = 2;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessThanTest03()
        {
            Int16 a = 3;
            a.Requires().IsLessThan(2);
        }

        #endregion // IsInt16LessThan

        #region IsInt16NotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessThanTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16NotLessThanTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessThanTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotLessThan(2);
        }

        #endregion // IsInt16NotLessThan

        #region IsInt16LessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessOrEqualTest01()
        {
            Int16 a = 1;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16LessOrEqualTest02()
        {
            Int16 a = 2;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessOrEqualTest03()
        {
            Int16 a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        #endregion // IsInt16LessOrEqual

        #region IsInt16NotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessOrEqualTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16NotLessOrEqualTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessOrEqualTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt16EqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should fail.")]
        public void IsInt16EqualToTest01()
        {
            Int16 a = 1;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Int16 x with 'x = other' should pass.")]
        public void IsInt16EqualToTest02()
        {
            Int16 a = 2;
            a.Requires().IsEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Int16 x with 'x > other' should fail.")]
        public void IsInt16EqualToTest03()
        {
            Int16 a = 3;
            a.Requires().IsEqualTo(2);
        }

        #endregion // IsInt16EqualTo

        #region IsInt16NotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x < other' should pass.")]
        public void IsInt16NotEqualToTest01()
        {
            Int16 a = 1;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should fail.")]
        public void IsInt16NotEqualToTest02()
        {
            Int16 a = 2;
            a.Requires().IsNotEqualTo(2);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Int16 x with 'x > other' should pass.")]
        public void IsInt16NotEqualToTest03()
        {
            Int16 a = 3;
            a.Requires().IsNotEqualTo(2);
        }

        #endregion // IsInt16NotEqualTo
    }
}