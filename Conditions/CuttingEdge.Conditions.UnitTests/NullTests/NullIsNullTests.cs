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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.NullTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNull method.
    /// </summary>
    [TestClass]
    public class NullIsNullTests
    {
        [TestMethod]
        [Description("Calling IsNull on null should pass.")]
        public void IsNullTest1()
        {
            object o = null;
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a reference should fail.")]
        public void IsNullTest2()
        {
            object o = new object();
            Condition.Requires(o).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull on a null Nullable<T> should pass.")]
        public void IsNullTest3()
        {
            int? i = null;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a set Nullable<T> should fail.")]
        public void IsNullTest4()
        {
            int? i = 3;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on an object containing an enum should fail with ArgumentException.")]
        public void IsNullTest5()
        {
            object i = DayOfWeek.Sunday;
            Condition.Requires(i).IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull with conditionDescription parameter should pass.")]
        public void IsNullTest6()
        {
            object o = null;
            Condition.Requires(o).IsNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest7()
        {
            object o = new object();
            try
            {
                Condition.Requires(o, "o").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe o xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNullTest8()
        {
            int? i = null;
            Condition.Requires(i).IsNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest9()
        {
            int? i = 4;
            try
            {
                Condition.Requires(i, "i").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe i xyz"));
            }
        }
    }
}