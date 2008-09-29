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
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    [TestClass]
    public class StringDoesNotHaveLengthTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest1()
        {
            string a = "test";
            a.Requires().DoesNotHaveLength(4);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest2()
        {
            string a = "test";
            a.Requires().DoesNotHaveLength(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest3()
        {
            string a = String.Empty;
            a.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest4()
        {
            string a = String.Empty;
            a.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotHaveLength on string x with 'null = expected length' should fail.")]
        public void DoesNotHaveLengthTest5()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            a.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest6()
        {
            string a = null;
            // A null value will never be found
            a.Requires().DoesNotHaveLength(1);
        }
    }
}