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
    /// Tests the ValidatorExtensions.HasLength method.
    /// </summary>
    [TestClass]
    public class StringHasLengthTests
    {
        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest1()
        {
            string a = "test";
            a.Requires().HasLength(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest2()
        {
            string a = "test";
            a.Requires().HasLength(3);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest3()
        {
            string a = String.Empty;
            a.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest4()
        {
            string a = String.Empty;
            a.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'null = expected length' should pass.")]
        public void HasLengthTest5()
        {
            string a = null;
            // A null value will never be found
            a.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling HasLength on string x with 'null != expected length' should fail.")]
        public void HasLengthTest6()
        {
            string a = null;
            // A null value will never be found
            a.Requires().HasLength(1);
        }
    }
}