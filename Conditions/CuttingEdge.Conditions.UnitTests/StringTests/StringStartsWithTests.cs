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
    /// Tests the ValidatorExtensions.StartsWith method.
    /// </summary>
    [TestClass]
    public class StringStartsWithTests
    {
        [TestMethod]
        [Description("Calling StartsWith on string x with 'x StartsWith x' should pass.")]
        public void StartsWithTest1()
        {
            string a = "test";
            a.Requires().StartsWith(a);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"tes\"' should pass.")]
        public void StartsWithTest2()
        {
            string a = "test";
            a.Requires().StartsWith("tes");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should fail.")]
        public void StartsWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().StartsWith(null);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"\"' should pass.")]
        public void StartsWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().StartsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling StartsWith on string x (null) with 'x StartsWith \"\"' should fail.")]
        public void StartsWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().StartsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should pass.")]
        public void StartsWithTest6()
        {
            string a = null;
            a.Requires().StartsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail.")]
        public void StartsWithTest7()
        {
            string a = "test";
            a.Requires().StartsWith("test me");
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail with a correct exception message.")]
        public void StartsWithTest8()
        {
            string expectedMessage =
                "a should start with 'test me'." + Environment.NewLine +
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").StartsWith("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}