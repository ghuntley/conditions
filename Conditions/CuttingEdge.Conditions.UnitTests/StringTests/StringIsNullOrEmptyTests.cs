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

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNullOrEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNullOrEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should fail.")]
        public void IsNullOrEmptyTest1()
        {
            string a = "test";
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (\"\") should pass.")]
        public void IsNullOrEmptyTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (null) should pass.")]
        public void IsNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty with conditionDescription parameter should pass.")]
        public void IsNullOrEmptyTest4()
        {
            string a = string.Empty;
            Condition.Requires(a).IsNullOrEmpty(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNullOrEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullOrEmptyTest5()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").IsNullOrEmpty("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should succeed when exceptions are suppressed.")]
        public void IsNullOrEmptyTest6()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsNullOrEmpty();
        }
    }
}