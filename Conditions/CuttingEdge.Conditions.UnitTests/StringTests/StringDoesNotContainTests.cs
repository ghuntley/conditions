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
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    [TestClass]
    public class StringDoesNotContainTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should fail.")]
        public void DoesNotContainTest1()
        {
            string a = "test";
            a.Requires().DoesNotContain(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"es\"' should fail.")]
        public void DoesNotContainTest2()
        {
            string a = "test";
            a.Requires().DoesNotContain("es");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain null' should pass.")]
        public void DoesNotContainTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotContain(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"\"' should fail.")]
        public void DoesNotContainTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotContain(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain \"\"' should pass.")]
        public void DoesNotContainTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotContain(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain null' should fail.")]
        public void DoesNotContainTest6()
        {
            string a = null;
            a.Requires().DoesNotContain(null);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test me\"' should pass.")]
        public void DoesNotContainTest7()
        {
            string a = "test";
            a.Requires().DoesNotContain("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test\"' should fail with a correct exception message.")]
        public void DoesNotContainTest8()
        {
            string expectedMessage =
                "a should not contain 'test'." + Environment.NewLine +
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotContain("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}