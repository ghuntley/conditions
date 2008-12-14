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
    /// Tests the ValidatorExtensions.IsNull method.
    /// </summary>
    [TestClass]
    public class NullIsNullTests
    {
        [TestMethod]
        [Description("Calling IsNull on null should pass.")]
        public void IsNullTest1()
        {
            object o = null;
            o.Requires().IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a reference should fail.")]
        public void IsNullTest2()
        {
            object o = new object();
            o.Requires().IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull on a null Nullable<T> should pass.")]
        public void IsNullTest3()
        {
            int? i = null;
            i.Requires().IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on a set Nullable<T> should fail.")]
        public void IsNullTest4()
        {
            int? i = 3;
            i.Requires().IsNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNull on an object containing an enum should fail with ArgumentException.")]
        public void IsNullTest5()
        {
            object i = DayOfWeek.Sunday;
            i.Requires().IsNull();
        }

        [TestMethod]
        [Description("Calling IsNull with conditionDescription parameter should pass.")]
        public void IsNullTest6()
        {
            object o = null;
            o.Requires().IsNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest7()
        {
            object o = new object();
            try
            {
                o.Requires("o").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe o xyz"));
            }
        }

        [TestMethod]
        [Description("Calling IsNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNullTest8()
        {
            int? i = null;
            i.Requires().IsNull(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest9()
        {
            int? i = 4;
            try
            {
                i.Requires("i").IsNull("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe i xyz"));
            }
        }
    }
}