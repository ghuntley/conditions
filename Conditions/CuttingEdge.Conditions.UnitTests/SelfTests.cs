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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public class SelfTests
    {
        [TestMethod]
        [Description("This test tests the test class itself and searches for methods that lack the [TestMethod] attribute.")]
        public void SelfTest()
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(TestHelper).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0
                select t;

            var untestableMethods =
                from unitTestClass in unitTestClasses
                from publicMethod in unitTestClass.GetMethods()
                where publicMethod.GetParameters().Length == 0
                where publicMethod.GetCustomAttributes(typeof(TestMethodAttribute), true).Length == 0
                where publicMethod.ReturnType == typeof(void)
                select publicMethod;

            if (untestableMethods.Count() == 0)
            {
                return;
            }

            string message = "The following public methods that aren't marked with the " +
                "[TestMethod] attribute:" + Environment.NewLine;

            foreach (var method in untestableMethods)
            {
                message += method.Name + Environment.NewLine;
            }

            Assert.Fail(message);
        }
    }
}