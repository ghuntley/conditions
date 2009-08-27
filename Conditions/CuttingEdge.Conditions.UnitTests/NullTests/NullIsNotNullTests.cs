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
    /// Tests the ValidatorExtensions.IsNotNull method.
    /// </summary>
    [TestClass]
    public class NullIsNotNullTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullTest1()
        {
            object o = null;
            Condition.Requires(o).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a reference should pass.")]
        public void IsNotNullTest2()
        {
            object o = new object();
            Condition.Requires(o).IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on a null Nullable<T> should fail.")]
        public void IsNotNullTest3()
        {
            int? i = null;
            Condition.Requires(i).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a set Nullable<T> should pass.")]
        public void IsNotNullTest4()
        {
            int? i = 3;
            Condition.Requires(i).IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull with conditionDescription parameter should pass.")]
        public void IsNotNullTest5()
        {
            object o = new object();
            Condition.Requires(o).IsNotNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest6()
        {
            object o = null;
            try
            {
                Condition.Requires(o, "o").IsNotNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe o xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNotNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNotNullTest7()
        {
            int? i = 4;
            Condition.Requires(i).IsNotNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest8()
        {
            int? i = null;
            try
            {
                Condition.Requires(i, "i").IsNotNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe i xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNotNull on null should succeed when exceptions are suppressed.")]
        public void IsNotNullTest9()
        {
            object o = null;
            Condition.Requires(o).SuppressExceptionsForTest().IsNotNull();
        }
    }
}