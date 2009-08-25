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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public sealed class ExtendabilityTests
    {
        [TestMethod]
        [Description("Tests whether the framework can be extended.")]
        public void ExtendabilityTest01()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest02()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest03()
        {
            int value = 1;

            Condition.Ensures(value).MyExtension(new[] { 2 });
        }

        [TestMethod]
        [Description("Tests whether the API works without the use of extension methods.")]
        public void ExtendabilityTest04()
        {
            int value = 1;
            ValidatorExtensions.IsGreaterOrEqual(Condition.Requires(value, "value"), 0);
        }
    }
}