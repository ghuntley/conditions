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
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    [TestClass]
    public class StringIsLongerThanTests
    {
        [TestMethod]
        [Description("Calling IsLongerThan on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerThan1()
        {
            string a = "test";
            a.Requires().IsLongerThan(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerThan2()
        {
            string a = "test";
            a.Requires().IsLongerThan(4);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < x.Length' should pass.")]
        public void IsLongerThan3()
        {
            string a = String.Empty;
            a.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan4()
        {
            string a = String.Empty;
            a.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < null' should pass.")]
        public void IsLongerThan5()
        {
            string a = null;
            a.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = null' should pass.")]
        public void IsLongerThan6()
        {
            string a = null;
            a.Requires().IsLongerThan(0);
        }
    }
}