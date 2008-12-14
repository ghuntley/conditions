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

namespace CuttingEdge.Conditions.UnitTests.NullTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotNull method.
    /// </summary>
    [TestClass]
    public class NullIsNotNullTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullTest1()
        {
            object o = null;
            o.Requires().IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a reference should pass.")]
        public void IsNotNullTest2()
        {
            object o = new object();
            o.Requires().IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on a null Nullable<T> should fail.")]
        public void IsNotNullTest3()
        {
            int? i = null;
            i.Requires().IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull on a set Nullable<T> should pass.")]
        public void IsNotNullTest4()
        {
            int? i = 3;
            i.Requires().IsNotNull();
        }

        [TestMethod]
        [Description("Calling IsNotNull with conditionDescription parameter should pass.")]
        public void IsNotNullTest5()
        {
            object o = new object();
            o.Requires().IsNotNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest6()
        {
            object o = null;
            try
            {
                o.Requires("o").IsNotNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe o xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNotNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNotNullTest7()
        {
            int? i = 4;
            i.Requires().IsNotNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest8()
        {
            int? i = null;
            try
            {
                i.Requires("i").IsNotNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe i xyz"));
            }
        }
    }
}