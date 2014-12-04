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
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class StringContainsTests
    {
        [TestMethod]
        [Description("Calling Contains on string x with 'x Contains x' should pass.")]
        public void ContainsTest01()
        {
            string a = "test";
            Condition.Requires(a).Contains(a);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"es\"' should pass.")]
        public void ContainsTest02()
        {
            string a = "test";
            Condition.Requires(a).Contains("es");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should fail.")]
        public void ContainsTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).Contains(null);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"\"' should pass.")]
        public void ContainsTest04()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).Contains(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on string x (null) with 'x Contains \"\"' should fail.")]
        public void ContainsTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).Contains(String.Empty);
        }

        [TestMethod]
        [Description("Calling Contains on string x (null) with 'x Contains null' should pass.")]
        public void ContainsTest06()
        {
            string a = null;
            Condition.Requires(a).Contains(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail.")]
        public void ContainsTest07()
        {
            string a = "test";
            Condition.Requires(a).Contains("test me");
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail with a correct exception message.")]
        public void ContainsTest08()
        {
            string expectedMessage =
                "a should contain 'test me'." + Environment.NewLine + 
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").Contains("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling Contains with conditionDescription parameter should pass.")]
        public void ContainsTest09()
        {
            string a = null;
            Condition.Requires(a).Contains(null, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing Contains should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void ContainsTest10()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").Contains("test me", "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should succeed when exceptions are suppressed.")]
        public void ContainsTest11()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().Contains(null);
        }
    }
}