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
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    [TestClass]
    public class CollectionDoesNotContainTests
    {
        // Calling DoesNotContain on an array should compile.
        internal static void CollectionDoesNotContainShouldCompileTest01()
        {
            int[] c = new int[0];
            c.Requires().DoesNotContain(1);
        }

        // Calling DoesNotContain on a Collection should compile.
        internal static void CollectionDoesNotContainShouldCompileTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        // Calling DoesNotContain on an IEnumerable should compile.
        internal static void CollectionDoesNotContainShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on null reference should pass.")]
        public void CollectionDoesNotContainTest01()
        {
            Collection<int> c = null;
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an empty collection should pass.")]
        public void CollectionDoesNotContainTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an ArrayList that does not contain the tested value should pass.")]
        public void CollectionDoesNotContainTest04()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            c.Requires().DoesNotContain((object)5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an ArrayList that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest05()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            c.Requires().DoesNotContain((object)4);
        }
    }
}