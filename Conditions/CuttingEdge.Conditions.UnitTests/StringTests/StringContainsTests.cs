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
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class StringContainsTests
    {
        [TestMethod]
        [Description("Calling Contains on string x with 'x Contains x' should pass.")]
        public void ContainsTest1()
        {
            string a = "test";
            a.Requires().Contains(a);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"es\"' should pass.")]
        public void ContainsTest2()
        {
            string a = "test";
            a.Requires().Contains("es");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should fail.")]
        public void ContainsTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().Contains(null);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"\"' should pass.")]
        public void ContainsTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().Contains(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on string x (null) with 'x Contains \"\"' should fail.")]
        public void ContainsTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().Contains(String.Empty);
        }

        [TestMethod]
        [Description("Calling Contains on string x (null) with 'x Contains null' should pass.")]
        public void ContainsTest6()
        {
            string a = null;
            a.Requires().Contains(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail.")]
        public void ContainsTest7()
        {
            string a = "test";
            a.Requires().Contains("test me");
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail with a correct exception message.")]
        public void ContainsTest8()
        {
            string expectedMessage =
                "a should contain 'test me'." + Environment.NewLine + 
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").Contains("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}