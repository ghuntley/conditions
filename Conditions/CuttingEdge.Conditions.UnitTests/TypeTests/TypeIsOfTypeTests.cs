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
using System.Collections;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.TypeTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsOfType method.
    /// </summary>
    [TestClass]
    public class TypeIsOfTypeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsOfType on null reference should fail.")]
        public void IsOfTypeTest0()
        {
            object o = null;

            // Null objects are not checked, so check must always succeed.
            o.Requires().IsOfType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsOfType on a down-casted object tested to be the down-casted type should pass.")]
        public void IsOfTypeTest1()
        {
            object o = "String";

            o.Requires().IsOfType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsOfType on a down-casted object tested to be the real type should pass.")]
        public void IsOfTypeTest2()
        {
            object o = "String";

            o.Requires().IsOfType(typeof(string));
        }

        [TestMethod]
        [Description("Calling IsOfType on a object tested to be it's parent type should pass.")]
        public void IsOfTypeTest3()
        {
            string s = "String";

            s.Requires().IsOfType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsOfType on a object tested to be it's own type should pass.")]
        public void IsOfTypeTest4()
        {
            string s = "String";

            s.Requires().IsOfType(typeof(string));
        }

        [TestMethod]
        [Description("Calling IsOfType on a System.Object tested to be System.Object should pass.")]
        public void IsOfTypeTest5()
        {
            object o = new object();

            o.Requires().IsOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsOfType on a down-casted object tested to be a non comparable type should fail.")]
        public void IsOfTypeTest6()
        {
            object o = "String";

            o.Requires().IsOfType(typeof(EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsOfType on a object tested to be a non comparable type should fail.")]
        public void IsOfTypeTest7()
        {
            string s = "String";

            s.Requires().IsOfType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsOfType on an object implementing ICollection tested to implement ICollection should pass.")]
        public void IsOfTypeTest8()
        {
            ICollection o = new Collection<int>();

            o.Requires().IsOfType(typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsOfType on an enum tested to implement ICollection should fail with an ArgumentException.")]
        public void IsOfTypeTest9()
        {
            object day = DayOfWeek.Monday;

            day.Requires().IsOfType(typeof(ICollection));
        }
    }
}