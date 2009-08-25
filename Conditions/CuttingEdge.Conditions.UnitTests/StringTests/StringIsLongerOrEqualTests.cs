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
    /// Tests the ValidatorExtensions.IsLongerOrEqual method.
    /// </summary>
    [TestClass]
    public class StringIsLongerOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerOrEqualTest0()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest1()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest2()
        {
            string a = "test";
            Condition.Requires(a).IsLongerOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with '-1 < x.Length' should pass.")]
        public void IsLongerOrEqualTest3()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest5()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = null' should pass.")]
        public void IsLongerOrEqualTest6()
        {
            string a = null;
            Condition.Requires(a).IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > null' should fail.")]
        public void IsLongerOrEqualTest7()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual with conditionDescription parameter should pass.")]
        public void IsLongerOrEqualTest8()
        {
            string a = string.Empty;
            Condition.Requires(a).IsLongerOrEqual(0, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsLongerOrEqualTest9()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsLongerOrEqual(1, "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }
    }
}