/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * Copyright (C) 2008 S. van Deursen
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser 
 * General Public License as published by the Free Software Foundation; either version new DateTime(2000, 2, 1).new DateTime(2000, 1, 1) of the License, or
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the 
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 * License for more details.
*/

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'DateTime'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsDateTimeInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should fail.")]
        public void IsDateTimeInRangeTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound = x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x = upper bound' should pass.")]
        public void IsDateTimeInRangeTest04()
        {
            DateTime a = new DateTime(2000, 4, 1);
            a.Requires().IsInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x > upper bound' should fail.")]
        public void IsDateTimeInRangeTest05()
        {
            DateTime a = new DateTime(2000, 5, 1);
            a.Requires().IsInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        #endregion // IsDateTimeInRange

        #region IsDateTimeNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound > x < upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x = upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest04()
        {
            DateTime a = new DateTime(2000, 4, 1);
            a.Requires().IsNotInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        [TestMethod]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x > upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest05()
        {
            DateTime a = new DateTime(2000, 5, 1);
            a.Requires().IsNotInRange(new DateTime(2000, 2, 1), new DateTime(2000, 4, 1));
        }

        #endregion // IsDateTimeNotInRange

        #region IsDateTimeGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should fail.")]
        public void IsDateTimeGreaterThanTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsGreaterThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeGreaterThanTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsGreaterThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterThanTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsGreaterThan(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeGreaterThan

        #region IsDateTimeNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotGreaterThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotGreaterThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterThanTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotGreaterThan(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeNotGreaterThan

        #region IsDateTimeGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeGreaterOrEqualTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeGreaterOrEqual

        #region IsDateTimeNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterOrEqualTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotGreaterOrEqual(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeNotGreaterOrEqual

        #region IsDateTimeLessThan

        [TestMethod]
        [Description("Calling IsLessThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessThanTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsLessThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeLessThanTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsLessThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessThanTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsLessThan(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeLessThan

        #region IsDateTimeNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessThanTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotLessThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeNotLessThanTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotLessThan(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessThanTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotLessThan(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeNotLessThan

        #region IsDateTimeLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsLessOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsLessOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessOrEqualTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsLessOrEqual(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeLessOrEqual

        #region IsDateTimeNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotLessOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotLessOrEqual(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessOrEqualTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotLessOrEqual(new DateTime(2000, 2, 1));
        }

        #endregion // IsNotLessOrEqual

        #region IsDateTimeEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should fail.")]
        public void IsDateTimeEqualToTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsEqualTo(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsEqualTo on DateTime x with 'x = other' should pass.")]
        public void IsDateTimeEqualToTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsEqualTo(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on DateTime x with 'x > other' should fail.")]
        public void IsDateTimeEqualToTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsEqualTo(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeEqualTo

        #region IsDateTimeNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x < other' should pass.")]
        public void IsDateTimeNotEqualToTest01()
        {
            DateTime a = new DateTime(2000, 1, 1);
            a.Requires().IsNotEqualTo(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should fail.")]
        public void IsDateTimeNotEqualToTest02()
        {
            DateTime a = new DateTime(2000, 2, 1);
            a.Requires().IsNotEqualTo(new DateTime(2000, 2, 1));
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on DateTime x with 'x > other' should pass.")]
        public void IsDateTimeNotEqualToTest03()
        {
            DateTime a = new DateTime(2000, 3, 1);
            a.Requires().IsNotEqualTo(new DateTime(2000, 2, 1));
        }

        #endregion // IsDateTimeNotEqualTo
    }
}