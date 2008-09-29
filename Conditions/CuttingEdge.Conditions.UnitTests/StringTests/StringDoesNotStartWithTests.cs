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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotStartWith method.
    /// </summary>
    [TestClass]
    public class StringDoesNotStartWithTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should fail.")]
        public void DoesNotStartWithTest1()
        {
            string a = "test";
            a.Requires().DoesNotStartWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"tes\"' should fail.")]
        public void DoesNotStartWithTest2()
        {
            string a = "test";
            a.Requires().DoesNotStartWith("tes");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith null' should pass.")]
        public void DoesNotStartWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotStartWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"\"' should fail.")]
        public void DoesNotStartWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith \"\"' should pass.")]
        public void DoesNotStartWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith null' should fail.")]
        public void DoesNotStartWithTest6()
        {
            string a = null;
            a.Requires().DoesNotStartWith(null);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test me\"' should pass.")]
        public void DoesNotStartWithTest7()
        {
            string a = "test";
            a.Requires().DoesNotStartWith("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotStartWithTest8()
        {
            string expectedMessage =
                "a should not start with 'test'." + Environment.NewLine +
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotStartWith("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}