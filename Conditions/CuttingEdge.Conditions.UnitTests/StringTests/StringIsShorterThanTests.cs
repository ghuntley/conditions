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
    /// Tests the ValidatorExtensions.IsShorterThan method.
    /// </summary>
    [TestClass]
    public class StringIsShorterThanTests
    {
        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterThan1()
        {
            string a = "test";
            a.Requires().IsShorterThan(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length = upped bound' should fail.")]
        public void IsShorterThan2()
        {
            string a = "test";
            a.Requires().IsShorterThan(4);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan3()
        {
            string a = String.Empty;
            a.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan4()
        {
            string a = String.Empty;
            a.Requires().IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'null < upped bound' should pass.")]
        public void IsShorterThan5()
        {
            string a = null;
            a.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterThan on string x with 'null = upped bound' should fail.")]
        public void IsShorterThan6()
        {
            string a = null;
            // A null string is considered to have a length of 0.
            a.Requires().IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan with conditionDescription parameter should pass.")]
        public void IsShorterThan7()
        {
            string a = string.Empty;
            a.Requires().IsShorterThan(1, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsShorterThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsShorterThan8()
        {
            string a = "x";
            try
            {
                a.Requires("a").IsShorterThan(1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }
    }
}