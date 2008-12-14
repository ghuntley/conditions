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
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNotEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should fail.")]
        public void IsStringNotEmptyTest1()
        {
            string s = String.Empty;
            s.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest2()
        {
            string s = null;
            s.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest3()
        {
            string s = "test";
            s.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty with conditionDescription parameter should pass.")]
        public void IsStringNotEmptyTest4()
        {
            string a = "test";
            a.Requires().IsNotEmpty(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsStringNotEmptyTest5()
        {
            string a = string.Empty;
            try
            {
                a.Requires("a").IsNotEmpty("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }
    }
}