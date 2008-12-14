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
    /// Tests the ValidatorExtensions.IsNotNullOrEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsNotNullOrEmptyTests
    {
        [TestMethod]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should pass.")]
        public void IsNotNullOrEmptyTest1()
        {
            string a = "test";
            a.Requires().IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string (\"\") should fail.")]
        public void IsNotNullOrEmptyTest2()
        {
            string a = String.Empty;
            a.Requires().IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNullOrEmpty on string (null) should fail.")]
        public void IsNotNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            a.Requires().IsNotNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotNullOrEmpty with conditionDescription parameter should pass.")]
        public void IsNotNullOrEmptyTest4()
        {
            string a = "test";
            a.Requires().IsNotNullOrEmpty(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNullOrEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullOrEmptyTest5()
        {
            string a = string.Empty;
            try
            {
                a.Requires("a").IsNotNullOrEmpty("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }
    }
}