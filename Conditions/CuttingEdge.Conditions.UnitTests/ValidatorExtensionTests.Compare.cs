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

using System;
using System.Data.SqlTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsInRange

        [TestMethod]
        [Description("Calling IsInRange on integer x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest1()
        {
            int a = 3;
            a.Requires().IsInRange(1, 5);
        }

        [TestMethod]
        [Description("Calling IsInRange a integer x with 'lower bound = x = upper bound' should pass.")]
        public void IsInRangeTest2()
        {
            int a = 3;
            a.Requires().IsInRange(3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on integer x with 'lower bound > x > upper bound' should fail.")]
        public void IsInRangeTest3()
        {
            int a = 3;
            a.Requires().IsInRange(4, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on double x with 'lower bound < x < upper bound' should fail.")]
        public void IsInRangeTest4()
        {
            double a = 3.0001;
            a.Requires().IsInRange(-100, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on integer x with 'lower bound > x < upper bound' should fail.")]
        public void IsInRangeTest5()
        {
            decimal a = 3;
            a.Requires().IsInRange(10, 1);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest6()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound > null < upper bound' should fail.")]
        public void IsInRangeTest7()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest8()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x > null' should fail.")]
        public void IsInRangeTest9()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null < upper bound' should pass.")]
        public void IsInRangeTest10()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null = null' should pass.")]
        public void IsInRangeTest11()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable struct x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest12()
        {
            // SqlInt32 does not implement IComparable<SqlInt32>, only IComparable.
            SqlInt32 value = 3;
            SqlInt32 min = 1;
            SqlInt32 max = 10;
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on string x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest13()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest15()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on Nullable<int> x with '(int)lower bound < x < (int)upper bound' should pass.")]
        public void IsInRangeTest16()
        {
            int? value = 3;
            int min = 1;
            int max = 10;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsInRange(DayOfWeek.Sunday, DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x > upper bound' should fail.")]
        public void IsInRangeTest18()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Nullable<int> x with '(int)lower bound < x > (int)upper bound' should fail.")]
        public void IsInRangeTest19()
        {
            int? value = 10;
            int min = 1;
            int max = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            value.Requires().IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsInRangeTest20()
        {
            DayOfWeek weekDay = DayOfWeek.Saturday;
            weekDay.Requires().IsInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        #endregion // IsInRange

        #region IsNotInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on integer x with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest1()
        {
            int a = 3;
            a.Requires().IsNotInRange(1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on integer x with 'lower bound = x = upper bound' should fail.")]
        public void IsNotInRangeTest2()
        {
            int a = 3;
            a.Requires().IsNotInRange(a, a);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on integer x with 'lower bound > x < upper bound' should pass.")]
        public void IsNotInRangeTest3()
        {
            int a = 3;
            a.Requires().IsNotInRange(4, 100);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on double x with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest4()
        {
            double a = 3.0001;
            a.Requires().IsNotInRange(-100, 3);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest5()
        {
            decimal a = 3;
            // The range is always invalid and will always pass. We don't want argument checks in the
            // IsNotInRange method to check whether min <= max. This will slow down and the user could end
            // up do extra checks on these input values. The user would then end up with more code than coding
            // the check by hand.
            a.Requires().IsNotInRange(10, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest6()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound > null < upper bound' should pass.")]
        public void IsNotInRangeTest7()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null < x < upper bound' should fail.")]
        public void IsNotInRangeTest8()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x > null' should pass.")]
        public void IsNotInRangeTest9()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null < upper bound' should fail.")]
        public void IsNotInRangeTest10()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null = null' should fail.")]
        public void IsNotInRangeTest11()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable struct with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest12()
        {
            // SqlInt32 does not implement IComparable<SqlInt32>, only IComparable.
            SqlInt32 value = 3;
            SqlInt32 min = 1;
            SqlInt32 max = 10;
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on string with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest13()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest15()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound > x < (int)upper bound' should pass.")]
        public void IsNotInRangeTest17()
        {
            int? value = 3;
            int min = 10; // min and max are normal integers
            int max = 100;

            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest18()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotInRange(DayOfWeek.Sunday, DayOfWeek.Thursday);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest19()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            value.Requires().IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotInRangeTest20()
        {
            DayOfWeek wednesday = DayOfWeek.Wednesday;
            wednesday.Requires().IsNotInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound < x < (int)upper bound' should fail.")]
        public void IsNotInRangeTest21()
        {
            int? value = 90;
            int min = 10; // min and max are normal integers
            int max = 100;

            value.Requires().IsNotInRange(min, max);
        }

        #endregion // IsNotInRange

        #region IsGreaterThan

        [TestMethod]
        [Description("Calling IsGreaterThan on integer x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest01()
        {
            int a = 3;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on integer x with 'negetive lower bound < x' should pass.")]
        public void IsGreaterThanTest02()
        {
            int a = 0;
            a.Requires().IsGreaterThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on integer x with 'lower bound = x' should fail.")]
        public void IsGreaterThanTest03()
        {
            int a = 3;
            a.Requires().IsGreaterThan(3);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on integer x with 'lower bound > x' should fail.")]
        public void IsGreaterThanTest04()
        {
            decimal a = 3;
            a.Requires().IsGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < null' should fail.")]
        public void IsGreaterThanTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            value.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsGreaterThanTest08()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            value.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound = x' should fail.")]
        public void IsGreaterThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsGreaterThan(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsGreaterThan(DayOfWeek.Sunday);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsGreaterThanTest11()
        {
            int? a = 3;
            int min = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsGreaterThanTest12()
        {
            int? a = 2;
            int min = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest13()
        {
            int? a = 3;
            int? min = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsGreaterThanTest14()
        {
            int? a = 2;
            int? min = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound > x' should fail with an InvalidEnumArgumentException.")]
        public void IsGreaterThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsGreaterThan(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterThan

        #region IsNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on integer x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest01()
        {
            int a = 3;
            a.Requires().IsNotGreaterThan(4);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on integer x with 'x < negative upper bound' should pass.")]
        public void IsNotGreaterThanTest02()
        {
            int a = -2;
            a.Requires().IsNotGreaterThan(-1);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on integer x with 'lower bound = x' should pass.")]
        public void IsNotGreaterThanTest03()
        {
            int a = 3;
            a.Requires().IsNotGreaterThan(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on integer x with 'x > upper bound' should fail.")]
        public void IsNotGreaterThanTest04()
        {
            decimal a = 3;
            a.Requires().IsNotGreaterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest05()
        {
            ComparableClass value = new ComparableClass(1);
            ComparableClass min = new ComparableClass(3);
            value.Requires().IsNotGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterThanTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            value.Requires().IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterThanTest07()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'null = null' should pass.")]
        public void IsNotGreaterThanTest08()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            value.Requires().IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'lower bound = x' should pass.")]
        public void IsNotGreaterThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsNotGreaterThan(value);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Enum x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotGreaterThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Nullable<int> x with 'x < (max)lower bound' should pass.")]
        public void IsNotGreaterThanTest11()
        {
            int? a = 2;
            int max = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsNotGreaterThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsNotGreaterThanTest12()
        {
            int? a = 3;
            int max = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsNotGreaterThan(max);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest13()
        {
            int? a = 2;
            int? max = 3;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsNotGreaterThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Nullable<int> x with 'x > lower bound' should fail.")]
        public void IsNotGreaterThanTest14()
        {
            int? a = 3;
            int? max = 2;
            // There is a special overload that takes T's instead of Nullable<T>'s, because C# type inference
            // doesn't work well with types that can implicitly be converted to types that are arguments in
            // method overloads in the candidate set.
            a.Requires().IsNotGreaterThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotGreaterThan on Enum x with 'x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotGreaterThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotGreaterThan(DayOfWeek.Thursday);
        }

        #endregion // IsNotGreaterThan

        #region IsGreaterOrEqual

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on integer x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest01()
        {
            int a = 3;
            a.Requires().IsGreaterOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on integer x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest02()
        {
            int a = 3;
            a.Requires().IsGreaterOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on integer x with 'lower bound > x' should fail.")]
        public void IsGreaterOrEqualTest03()
        {
            int a = 3;
            a.Requires().IsGreaterOrEqual(4);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on decimal x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest04()
        {
            decimal a = 3;
            a.Requires().IsGreaterOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            value.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'null < null' should pass.")]
        public void IsGreaterOrEqualTest08()
        {
            ComparableClass value = null;
            value.Requires().IsGreaterOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualTest09()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            value.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass min = null;
            value.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest11()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsGreaterOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest12()
        {
            int? a = 3;
            int min = 2; // min is a normal integer
            a.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsGreaterOrEqualTest13()
        {
            int? a = 2;
            int min = 3; // min is a normal integer
            a.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest14()
        {
            int? a = 3;
            int? min = 2;
            a.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsGreaterOrEqualTest15()
        {
            int? a = 2;
            int? min = 3;
            a.Requires().IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Enum x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsGreaterOrEqual(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsGreaterOrEqual on Enum x with 'lower bound < x' should fail with an InvalidEnumArgumentException.")]
        public void IsGreaterOrEqualTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsGreaterOrEqual(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterOrEqual

        #region IsNotGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on integer x with 'x = upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest01()
        {
            int a = 3;
            a.Requires().IsNotGreaterOrEqual(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on integer x with 'x > upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest02()
        {
            int a = 3;
            a.Requires().IsNotGreaterOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on integer x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest03()
        {
            int a = 3;
            a.Requires().IsNotGreaterOrEqual(4);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on decimal x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest04()
        {
            decimal a = 3;
            a.Requires().IsNotGreaterOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest06()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterOrEqualTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            value.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotGreaterOrEqualTest08()
        {
            ComparableClass value = null;
            value.Requires().IsNotGreaterOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest09()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            value.Requires().IsNotGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass max = null;
            value.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x = upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest11()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsNotGreaterOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest12()
        {
            int? a = 3;
            int max = 2; // max is a normal integer
            a.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest13()
        {
            int? a = 2;
            int max = 3; // max is a normal integer
            a.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest14()
        {
            int? a = 3;
            int? min = 2;
            a.Requires().IsNotGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest15()
        {
            int? a = 2;
            int? max = 3;
            a.Requires().IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotGreaterOrEqual on Enum x with 'x = upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotGreaterOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotGreaterOrEqual(friday);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Enum x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotGreaterOrEqual(DayOfWeek.Saturday);
        }

        #endregion // IsNotGreaterOrEqual

        #region IsLessThan

        [TestMethod]
        [Description("Calling IsLessThan on integer x with 'x < upper bound' should pass.")]
        public void IsLessThanTest01()
        {
            int a = 3;
            a.Requires().IsLessThan(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on integer x with 'x = upper bound' should fail.")]
        public void IsLessThanTest02()
        {
            int a = 3;
            a.Requires().IsLessThan(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on integer x with 'x > upper bound' should fail.")]
        public void IsLessThanTest03()
        {
            int a = 3;
            a.Requires().IsLessThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > upper bound' should fail.")]
        public void IsLessThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessThanTest06()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            value.Requires().IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsLessThanTest08()
        {
            ComparableClass value = null;
            value.Requires().IsLessThan(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x = x' should fail.")]
        public void IsLessThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsLessThan(value);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessThanTest10()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            a.Requires().IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessThanTest11()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            a.Requires().IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessThanTest12()
        {
            int? a = 3;
            int? max = 4;
            a.Requires().IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessThanTest13()
        {
            int? a = 4;
            int? max = 3;
            a.Requires().IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should pass.")]
        public void IsLessThanTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsLessThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsLessThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsLessThan(DayOfWeek.Thursday);
        }

        #endregion // IsLessThan

        #region IsNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on integer x with 'lower bound > x' should fail.")]
        public void IsNotLessThanTest01()
        {
            int a = 3;
            a.Requires().IsNotLessThan(4);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on integer x with 'lower bound = x' should pass.")]
        public void IsNotLessThanTest02()
        {
            int a = 3;
            a.Requires().IsNotLessThan(3);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on integer x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest03()
        {
            int a = 3;
            a.Requires().IsNotLessThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessThanTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            value.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'null = null' should pass.")]
        public void IsNotLessThanTest08()
        {
            ComparableClass value = null;
            value.Requires().IsNotLessThan(null);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'x = x' should pass.")]
        public void IsNotLessThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsNotLessThan(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsNotLessThanTest10()
        {
            int? a = 3;
            int min = 4; // min is a normal integer
            a.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsNotLessThanTest11()
        {
            int? a = 4;
            int min = 3; // min is a normal integer
            a.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsNotLessThanTest12()
        {
            int? a = 3;
            int? min = 4;
            a.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest13()
        {
            int? a = 4;
            int? min = 3;
            a.Requires().IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotLessThan on Enum x with 'lower bound > x' should fail with an InvalidEnumArgumentException.")]
        public void IsNotLessThanTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotLessThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Enum x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotLessThan(DayOfWeek.Thursday);
        }

        #endregion // IsNotLessThan

        #region IsLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on integer x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualTest01()
        {
            int a = 3;
            a.Requires().IsLessOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on integer x with 'x < upper bound' should pass.")]
        public void IsLessOrEqualTest02()
        {
            int a = 3;
            a.Requires().IsLessOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on integer x with 'x > upper bound' should fail.")]
        public void IsLessOrEqualTest03()
        {
            int a = 3;
            a.Requires().IsLessOrEqual(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x < upper bound' should pass.")]
        public void IsLessOrEqualTest04()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualTest05()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            value.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            value.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null = null' should pass.")]
        public void IsLessOrEqualTest07()
        {
            ComparableClass value = null;
            value.Requires().IsLessOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualTest08()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(Int32.MinValue);
            value.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualTest09()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass max = null;
            value.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsLessOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessOrEqualTest11()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            a.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessOrEqualTest12()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            a.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessOrEqualTest13()
        {
            int? a = 3;
            int? max = 4;
            a.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessOrEqualTest14()
        {
            int? a = 4;
            int? max = 3;
            a.Requires().IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Enum x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsLessOrEqual(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsLessOrEqual on Enum x with 'x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsLessOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsLessOrEqual(DayOfWeek.Thursday);
        }

        #endregion // IsLessOrEqual

        #region IsNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on integer x with 'lower bound = x' should fail.")]
        public void IsNotLessOrEqualTest01()
        {
            int a = 3;
            a.Requires().IsNotLessOrEqual(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on integer x with 'lower bound > x' should fail.")]
        public void IsNotLessOrEqualTest02()
        {
            int a = 3;
            a.Requires().IsNotLessOrEqual(4);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on integer x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest03()
        {
            int a = 3;
            a.Requires().IsNotLessOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest04()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessOrEqualTest05()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            value.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessOrEqualTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            value.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotLessOrEqualTest07()
        {
            ComparableClass value = null;
            value.Requires().IsNotLessOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessOrEqualTest08()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            value.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessOrEqualTest09()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass min = null;
            value.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound = x' should fail.")]
        public void IsNotLessOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(0);
            value.Requires().IsNotLessOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsNotLessOrEqualTest11()
        {
            int? a = 3;
            int min = 4; // min is a normal integer
            a.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest12()
        {
            int? a = 4;
            int min = 3; // min is a normal integer
            a.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsNotLessOrEqualTest13()
        {
            int? a = 3;
            int? min = 4;
            a.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest14()
        {
            int? a = 4;
            int? min = 3;
            a.Requires().IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotLessOrEqual on Enum x with 'lower bound = x' should fail with an InvalidEnumArgumentException.")]
        public void IsNotLessOrEqualTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotLessOrEqual(friday);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Enum x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotLessOrEqual(DayOfWeek.Thursday);
        }

        #endregion // IsNotLessOrEqual

        #region IsEqualTo

        [TestMethod]
        [Description("Calling IsEqualTo on integer x with 'x = other' should pass.")]
        public void IsEqualToTest1()
        {
            int a = 3;
            a.Requires().IsEqualTo(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on integer x with 'x != other' should fail.")]
        public void IsEqualToTest2()
        {
            int a = 3;
            a.Requires().IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on double x with 'x = other' should pass.")]
        public void IsEqualToTest3()
        {
            double a = 3.0;
            a.Requires().IsEqualTo(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on double x with 'x != other' should fail.")]
        public void IsEqualToTest4()
        {
            double a = 3;
            a.Requires().IsEqualTo(4);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x = other' should pass.")]
        public void IsEqualToTest5()
        {
            ComparableClass a = new ComparableClass();
            a.Requires().IsEqualTo(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null != other' should fail.")]
        public void IsEqualToTest6()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x != null' should fail.")]
        public void IsEqualToTest7()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null = null' should pass.")]
        public void IsEqualToTest8()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = (int)other' should pass.")]
        public void IsEqualToTest9()
        {
            int? a = 3;
            int b = (int)a; // b is a normal integer
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Enum x with 'x = other' should pass.")]
        public void IsEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsEqualTo(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest11()
        {
            int? a = null;
            int b = 4; // b is a normal integer
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest12()
        {
            int? a = null;
            int? b = 4;
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = x' should pass.")]
        public void IsEqualToTest13()
        {
            int? a = 6;
            int? b = a;
            a.Requires().IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsEqualTo on Enum x with 'x != other' should fail with an InvalidEnumArgumentException.")]
        public void IsEqualToTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsEqualTo(DayOfWeek.Saturday);
        }

        #endregion // IsEqualTo

        #region IsNotEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on integer x with 'x = other' should fail.")]
        public void IsNotEqualToTest1()
        {
            int a = 3;
            a.Requires().IsNotEqualTo(3);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on integer x with 'x != other' should pass.")]
        public void IsNotEqualToTest2()
        {
            int a = 3;
            a.Requires().IsNotEqualTo(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on double x with 'x = other' should fail.")]
        public void IsNotEqualToTest3()
        {
            double a = 3.0;
            a.Requires().IsNotEqualTo(a);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on integer x with 'x != other' should pass.")]
        public void IsNotEqualToTest4()
        {
            double a = 3;
            a.Requires().IsNotEqualTo(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x = other' should fail.")]
        public void IsNotEqualToTest5()
        {
            ComparableClass a = new ComparableClass();
            a.Requires().IsNotEqualTo(a);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null != other' should pass.")]
        public void IsNotEqualToTest6()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x != null' should pass.")]
        public void IsNotEqualToTest7()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotEqualToTest8()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x != (int)other' should pass.")]
        public void IsNotEqualToTest9()
        {
            int? a = 3;
            int b = 4;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Enum x with 'x != other' should pass.")]
        public void IsNotEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotEqualTo(DayOfWeek.Sunday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x = x' should fail with ArgumentNullException.")]
        public void IsNotEqualToTest11()
        {
            int? a = null;
            int? b = null;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x != y' should pass.")]
        public void IsNotEqualToTest12()
        {
            int? a = null;
            int? b = 4;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x = (int)other' should fail.")]
        public void IsNotEqualToTest13()
        {
            int? a = 4;
            int b = 4;
            a.Requires().IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotEqualTo on Enum x with 'x == other' should fail with an InvalidEnumArgumentException.")]
        public void IsNotEqualToTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            friday.Requires().IsNotEqualTo(friday);
        }

        #endregion // IsNotEqualTo

        #region Helper classes

        private sealed class ComparableClass : IComparable<ComparableClass>, IComparable
        {
            private readonly int value;

            public ComparableClass()
            {
            }

            public ComparableClass(int value)
            {
                this.value = value;
            }

            public int CompareTo(ComparableClass other)
            {
                if (other == null)
                {
                    return 1;
                }

                return this.value.CompareTo(other.value);
            }

            public int CompareTo(object obj)
            {
                ComparableClass other = obj as ComparableClass;

                return other != null ? this.CompareTo(other) : 1;
            }
        }

        #endregion // Helper classes
    }
}