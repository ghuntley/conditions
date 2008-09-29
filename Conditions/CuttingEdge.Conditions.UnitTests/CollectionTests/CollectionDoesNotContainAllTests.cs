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
    /// Tests the ValidatorExtensions.DoesNotContainAll method.
    /// </summary>
    [TestClass]
    public class CollectionDoesNotContainAllTests
    {
        // Calling DoesNotContainAll on an array should compile
        internal static void CollectionDoesNotContainAllShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> all = new[] { 2 };
            c.Requires().DoesNotContainAll(all);
        }

        // Calling DoesNotContainAll on a Collection should compile
        internal static void CollectionDoesNotContainAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Collection<int> all = new Collection<int> { 2 };
            c.Requires().DoesNotContainAll(all);
        }

        // Calling DoesNotContainAll on an IEnumerable should compile
        internal static void CollectionDoesNotContainAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Collection<int> all = new Collection<int> { 2 };
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with a 'any' collection containing all elements of the tested collection should fail.")]
        public void CollectionDoesNotContainAllTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing no element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of different types of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };

            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing not all elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of different types of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };

            c.Requires().DoesNotContainAll(all);
        }
    }
}