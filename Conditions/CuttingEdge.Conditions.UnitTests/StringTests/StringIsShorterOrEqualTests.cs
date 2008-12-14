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
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    [TestClass]
    public class StringIsShorterOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual0()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual1()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual2()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual3()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual4()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual5()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqual6()
        {
            string a = null;
            a.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterOrEqual on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqual7()
        {
            string a = null;
            // A null value is considered to have a length of 0 characters.
            a.Requires().IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual with conditionDescription parameter should pass.")]
        public void IsShorterOrEqual8()
        {
            string a = string.Empty;
            a.Requires().IsShorterOrEqual(0, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsShorterOrEqual9()
        {
            string a = null;
            try
            {
                a.Requires("a").IsShorterOrEqual(-1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }
    }
}