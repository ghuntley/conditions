#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Data.SqlTypes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareGenericTests
    {
        #region IsInRange

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest6()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound > null < upper bound' should fail.")]
        public void IsInRangeTest7()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest8()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on IComparable<T> object x with 'lower bound < x > null' should fail.")]
        public void IsInRangeTest9()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null < upper bound' should pass.")]
        public void IsInRangeTest10()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable<T> object x with 'null = null = null' should pass.")]
        public void IsInRangeTest11()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on IComparable struct x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest12()
        {
            // SqlInt32 does not implement IComparable<SqlInt32>, only IComparable.
            SqlInt32 value = 3;
            SqlInt32 min = 1;
            SqlInt32 max = 10;
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on string x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest13()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x < upper bound' should pass.")]
        public void IsInRangeTest15()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            Condition.Requires(value).IsInRange(min, max);
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
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x < upper bound' should pass.")]
        public void IsInRangeTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsInRange(DayOfWeek.Sunday, DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Nullable<int> x with 'null < x > upper bound' should fail.")]
        public void IsInRangeTest18()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            Condition.Requires(value).IsInRange(min, max);
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
            Condition.Requires(value).IsInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsInRange on System.Enum x with 'lower bound < x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsInRangeTest20()
        {
            DayOfWeek weekDay = DayOfWeek.Saturday;
            Condition.Requires(weekDay).IsInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        #endregion // IsInRange

        #region IsNotInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest6()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound > null < upper bound' should pass.")]
        public void IsNotInRangeTest7()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null < x < upper bound' should fail.")]
        public void IsNotInRangeTest8()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on IComparable<T> object with 'lower bound < x > null' should pass.")]
        public void IsNotInRangeTest9()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            ComparableClass max = null;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null < upper bound' should fail.")]
        public void IsNotInRangeTest10()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = new ComparableClass(10);
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotInRange on IComparable<T> object with 'null = null = null' should fail.")]
        public void IsNotInRangeTest11()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            ComparableClass max = null;
            Condition.Requires(value).IsNotInRange(min, max);
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
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on string with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest13()
        {
            string value = "c";
            string min = "a";
            string max = "j";
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x < upper bound' should fail.")]
        public void IsNotInRangeTest15()
        {
            int? value = 3;
            int? min = null;
            int? max = 10;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound > x < (int)upper bound' should pass.")]
        public void IsNotInRangeTest17()
        {
            int? value = 3;
            int min = 10; // min and max are normal integers
            int max = 100;

            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest18()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotInRange(DayOfWeek.Sunday, DayOfWeek.Thursday);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Nullable<int> with 'lower bound < x > upper bound' should pass.")]
        public void IsNotInRangeTest19()
        {
            int? value = 10;
            int? min = null;
            int? max = 3;
            Condition.Requires(value).IsNotInRange(min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotInRange on Enum with 'lower bound < x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotInRangeTest20()
        {
            DayOfWeek wednesday = DayOfWeek.Wednesday;
            Condition.Requires(wednesday).IsNotInRange(DayOfWeek.Monday, DayOfWeek.Friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Nullable<int> with '(int)lower bound < x < (int)upper bound' should fail.")]
        public void IsNotInRangeTest21()
        {
            int? value = 90;
            int min = 10; // min and max are normal integers
            int max = 100;

            Condition.Requires(value).IsNotInRange(min, max);
        }

        #endregion // IsNotInRange

        #region IsGreaterThan

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound < null' should fail.")]
        public void IsGreaterThanTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsGreaterThanTest08()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on IComparable<T> object x with 'lower bound = x' should fail.")]
        public void IsGreaterThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsGreaterThan(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound < x' should pass.")]
        public void IsGreaterThanTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterThan(DayOfWeek.Sunday);
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
            Condition.Requires(a).IsGreaterThan(min);
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
            Condition.Requires(a).IsGreaterThan(min);
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
            Condition.Requires(a).IsGreaterThan(min);
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
            Condition.Requires(a).IsGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsGreaterThan on Enum x with 'lower bound > x' should fail with an InvalidEnumArgumentException.")]
        public void IsGreaterThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterThan(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterThan

        #region IsNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest05()
        {
            ComparableClass value = new ComparableClass(1);
            ComparableClass min = new ComparableClass(3);
            Condition.Requires(value).IsNotGreaterThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterThanTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterThanTest07()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'null = null' should pass.")]
        public void IsNotGreaterThanTest08()
        {
            ComparableClass value = null;
            ComparableClass min = null;
            Condition.Requires(value).IsNotGreaterThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on IComparable<T> object x with 'lower bound = x' should pass.")]
        public void IsNotGreaterThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsNotGreaterThan(value);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Enum x with 'x < upper bound' should pass.")]
        public void IsNotGreaterThanTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotGreaterThan(DayOfWeek.Saturday);
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
            Condition.Requires(a).IsNotGreaterThan(max);
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
            Condition.Requires(a).IsNotGreaterThan(max);
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
            Condition.Requires(a).IsNotGreaterThan(max);
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
            Condition.Requires(a).IsNotGreaterThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotGreaterThan on Enum x with 'x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotGreaterThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotGreaterThan(DayOfWeek.Thursday);
        }

        #endregion // IsNotGreaterThan

        #region IsGreaterOrEqual

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'null < null' should pass.")]
        public void IsGreaterOrEqualTest08()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsGreaterOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsGreaterOrEqualTest09()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsGreaterOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass min = null;
            Condition.Requires(value).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on IComparable<T> object x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest11()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsGreaterOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest12()
        {
            int? a = 3;
            int min = 2; // min is a normal integer
            Condition.Requires(a).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsGreaterOrEqualTest13()
        {
            int? a = 2;
            int min = 3; // min is a normal integer
            Condition.Requires(a).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsGreaterOrEqualTest14()
        {
            int? a = 3;
            int? min = 2;
            Condition.Requires(a).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsGreaterOrEqualTest15()
        {
            int? a = 2;
            int? min = 3;
            Condition.Requires(a).IsGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Enum x with 'lower bound = x' should pass.")]
        public void IsGreaterOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterOrEqual(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsGreaterOrEqual on Enum x with 'lower bound < x' should fail with an InvalidEnumArgumentException.")]
        public void IsGreaterOrEqualTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsGreaterOrEqual(DayOfWeek.Saturday);
        }

        #endregion // IsGreaterOrEqual

        #region IsNotGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest06()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterOrEqualTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            Condition.Requires(value).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotGreaterOrEqualTest08()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsNotGreaterOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest09()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsNotGreaterOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsNotGreaterOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass max = null;
            Condition.Requires(value).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on IComparable<T> object x with 'x = upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest11()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsNotGreaterOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest12()
        {
            int? a = 3;
            int max = 2; // max is a normal integer
            Condition.Requires(a).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest13()
        {
            int? a = 2;
            int max = 3; // max is a normal integer
            Condition.Requires(a).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsNotGreaterOrEqualTest14()
        {
            int? a = 3;
            int? min = 2;
            Condition.Requires(a).IsNotGreaterOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest15()
        {
            int? a = 2;
            int? max = 3;
            Condition.Requires(a).IsNotGreaterOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotGreaterOrEqual on Enum x with 'x = upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsNotGreaterOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotGreaterOrEqual(friday);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Enum x with 'x < upper bound' should pass.")]
        public void IsNotGreaterOrEqualTest17()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotGreaterOrEqual(DayOfWeek.Saturday);
        }

        #endregion // IsNotGreaterOrEqual

        #region IsLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > upper bound' should fail.")]
        public void IsLessThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessThanTest06()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            Condition.Requires(value).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'null = null' should fail.")]
        public void IsLessThanTest08()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsLessThan(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on IComparable<T> object x with 'x = x' should fail.")]
        public void IsLessThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsLessThan(value);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessThanTest10()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessThanTest11()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessThanTest12()
        {
            int? a = 3;
            int? max = 4;
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessThanTest13()
        {
            int? a = 4;
            int? max = 3;
            Condition.Requires(a).IsLessThan(max);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should pass.")]
        public void IsLessThanTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsLessThan on Enum x with 'x < upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsLessThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessThan(DayOfWeek.Thursday);
        }

        #endregion // IsLessThan

        #region IsNotLessThan

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest05()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessThanTest06()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessThanTest07()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'null = null' should pass.")]
        public void IsNotLessThanTest08()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsNotLessThan(null);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on IComparable<T> object x with 'x = x' should pass.")]
        public void IsNotLessThanTest09()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsNotLessThan(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsNotLessThanTest10()
        {
            int? a = 3;
            int min = 4; // min is a normal integer
            Condition.Requires(a).IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Nullable<int> x with '(int)lower bound < x' should pass.")]
        public void IsNotLessThanTest11()
        {
            int? a = 4;
            int min = 3; // min is a normal integer
            Condition.Requires(a).IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsNotLessThanTest12()
        {
            int? a = 3;
            int? min = 4;
            Condition.Requires(a).IsNotLessThan(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest13()
        {
            int? a = 4;
            int? min = 3;
            Condition.Requires(a).IsNotLessThan(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotLessThan on Enum x with 'lower bound > x' should fail with an InvalidEnumArgumentException.")]
        public void IsNotLessThanTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotLessThan(DayOfWeek.Saturday);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Enum x with 'lower bound < x' should pass.")]
        public void IsNotLessThanTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotLessThan(DayOfWeek.Thursday);
        }

        #endregion // IsNotLessThan

        #region IsLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x < upper bound' should fail.")]
        public void IsLessOrEqualTest04()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualTest05()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(1);
            Condition.Requires(value).IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass max = null;
            Condition.Requires(value).IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null = null' should pass.")]
        public void IsLessOrEqualTest07()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsLessOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'null < upper bound' should pass.")]
        public void IsLessOrEqualTest08()
        {
            ComparableClass value = null;
            ComparableClass max = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x > null' should fail.")]
        public void IsLessOrEqualTest09()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass max = null;
            Condition.Requires(value).IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on IComparable<T> object x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsLessOrEqual(value);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x < (int)upper bound' should pass.")]
        public void IsLessOrEqualTest11()
        {
            int? a = 3;
            int max = 4; // max is a normal integer
            Condition.Requires(a).IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x > (int)upper bound' should fail.")]
        public void IsLessOrEqualTest12()
        {
            int? a = 4;
            int max = 3; // max is a normal integer
            Condition.Requires(a).IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x < upper bound' should pass.")]
        public void IsLessOrEqualTest13()
        {
            int? a = 3;
            int? max = 4;
            Condition.Requires(a).IsLessOrEqual(max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Nullable<int> x with 'x > upper bound' should fail.")]
        public void IsLessOrEqualTest14()
        {
            int? a = 4;
            int? max = 3;
            Condition.Requires(a).IsLessOrEqual(max);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Enum x with 'x = upper bound' should pass.")]
        public void IsLessOrEqualTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessOrEqual(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsLessOrEqual on Enum x with 'x > upper bound' should fail with an InvalidEnumArgumentException.")]
        public void IsLessOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsLessOrEqual(DayOfWeek.Thursday);
        }

        #endregion // IsLessOrEqual

        #region IsNotLessOrEqual

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest04()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessOrEqualTest05()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(1);
            Condition.Requires(value).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessOrEqualTest06()
        {
            ComparableClass value = new ComparableClass(3);
            ComparableClass min = null;
            Condition.Requires(value).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotLessOrEqualTest07()
        {
            ComparableClass value = null;
            Condition.Requires(value).IsNotLessOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound > null' should fail.")]
        public void IsNotLessOrEqualTest08()
        {
            ComparableClass value = null;
            ComparableClass min = new ComparableClass(Int32.MinValue);
            Condition.Requires(value).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'null < x' should pass.")]
        public void IsNotLessOrEqualTest09()
        {
            ComparableClass value = new ComparableClass(Int32.MinValue);
            ComparableClass min = null;
            Condition.Requires(value).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on IComparable<T> object x with 'lower bound = x' should fail.")]
        public void IsNotLessOrEqualTest10()
        {
            ComparableClass value = new ComparableClass(0);
            Condition.Requires(value).IsNotLessOrEqual(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with '(int)lower bound > x' should fail.")]
        public void IsNotLessOrEqualTest11()
        {
            int? a = 3;
            int min = 4; // min is a normal integer
            Condition.Requires(a).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest12()
        {
            int? a = 4;
            int min = 3; // min is a normal integer
            Condition.Requires(a).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound > x' should fail.")]
        public void IsNotLessOrEqualTest13()
        {
            int? a = 3;
            int? min = 4;
            Condition.Requires(a).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Nullable<int> x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest14()
        {
            int? a = 4;
            int? min = 3;
            Condition.Requires(a).IsNotLessOrEqual(min);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotLessOrEqual on Enum x with 'lower bound = x' should fail with an InvalidEnumArgumentException.")]
        public void IsNotLessOrEqualTest15()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotLessOrEqual(friday);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Enum x with 'lower bound < x' should pass.")]
        public void IsNotLessOrEqualTest16()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotLessOrEqual(DayOfWeek.Thursday);
        }

        #endregion // IsNotLessOrEqual

        #region IsEqualTo

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x = other' should pass.")]
        public void IsEqualToTest5()
        {
            ComparableClass a = new ComparableClass();
            Condition.Requires(a).IsEqualTo(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null != other' should fail.")]
        public void IsEqualToTest6()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'x != null' should fail.")]
        public void IsEqualToTest7()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on IComparable<T> object x with 'null = null' should pass.")]
        public void IsEqualToTest8()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = (int)other' should pass.")]
        public void IsEqualToTest9()
        {
            int? a = 3;
            int b = (int)a; // b is a normal integer
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Enum x with 'x = other' should pass.")]
        public void IsEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsEqualTo(friday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest11()
        {
            int? a = null;
            int b = 4; // b is a normal integer
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEqualTo on x == null with 'x = 4' should fail with ArgumentNullException.")]
        public void IsEqualToTest12()
        {
            int? a = null;
            int? b = 4;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Nullable<T> x with 'x = x' should pass.")]
        public void IsEqualToTest13()
        {
            int? a = 6;
            int? b = a;
            Condition.Requires(a).IsEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsEqualTo on Enum x with 'x != other' should fail with an InvalidEnumArgumentException.")]
        public void IsEqualToTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsEqualTo(DayOfWeek.Saturday);
        }

        #endregion // IsEqualTo

        #region IsNotEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x = other' should fail.")]
        public void IsNotEqualToTest5()
        {
            ComparableClass a = new ComparableClass();
            Condition.Requires(a).IsNotEqualTo(a);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null != other' should pass.")]
        public void IsNotEqualToTest6()
        {
            ComparableClass a = null;
            ComparableClass b = new ComparableClass();
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'x != null' should pass.")]
        public void IsNotEqualToTest7()
        {
            ComparableClass a = new ComparableClass();
            ComparableClass b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on IComparable<T> object x with 'null = null' should fail.")]
        public void IsNotEqualToTest8()
        {
            ComparableClass a = null;
            ComparableClass b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x != (int)other' should pass.")]
        public void IsNotEqualToTest9()
        {
            int? a = 3;
            int b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Enum x with 'x != other' should pass.")]
        public void IsNotEqualToTest10()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotEqualTo(DayOfWeek.Sunday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x = x' should fail with ArgumentNullException.")]
        public void IsNotEqualToTest11()
        {
            int? a = null;
            int? b = null;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Nullable<int> x = null with 'x != y' should pass.")]
        public void IsNotEqualToTest12()
        {
            int? a = null;
            int? b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Nullable<int> x with 'x = (int)other' should fail.")]
        public void IsNotEqualToTest13()
        {
            int? a = 4;
            int b = 4;
            Condition.Requires(a).IsNotEqualTo(b);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling IsNotEqualTo on Enum x with 'x == other' should fail with an InvalidEnumArgumentException.")]
        public void IsNotEqualToTest14()
        {
            DayOfWeek friday = DayOfWeek.Friday;
            Condition.Requires(friday).IsNotEqualTo(friday);
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