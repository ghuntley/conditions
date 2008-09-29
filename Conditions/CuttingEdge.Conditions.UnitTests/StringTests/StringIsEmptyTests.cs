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
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    [TestClass]
    public class StringIsEmptyTests
    {
        [TestMethod]
        [Description("Calling IsEmpty on string x with 'x == String.Empty' should pass.")]
        public void IsStringEmptyTest1()
        {
            string s = String.Empty;
            s.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest2()
        {
            string s = null;
            s.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest3()
        {
            string s = "test";
            s.Requires().IsEmpty();
        }
    }
}