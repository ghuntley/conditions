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
    /// Tests the ValidatorExtensions.ContainsAll method.
    /// </summary>
    [TestClass]
    public class CollectionContainsAllTests
    {
        // Calling ContainsAll on an array should compile
        internal static void CollectionContainsAllShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> all = c;
            c.Requires().ContainsAll(all);
        }

        // Calling ContainsAll on a Collection should compile
        internal static void CollectionContainsAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAll(c);
        }

        // Calling ContainsAll on an IEnumerable should compile
        internal static void CollectionContainsAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAll(c);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest01()
        {
            Collection<int> c = null;
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest04()
        {
            Collection<int> c = null;
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with a 'all' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAllTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 1, 2, 3, 4 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing one element of the tested collection should fail.")]
        public void CollectionContainsAllTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 4, 5, 6, 7 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAllTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 5, 6, 7, 8 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested typed collection should pass.")]
        public void CollectionContainsAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested untyped collection should pass.")]
        public void CollectionContainsAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of different types of the tested untyped collection should pass.")]
        public void CollectionContainsAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of the tested typed collection should fail.")]
        public void CollectionContainsAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested untyped collection should fail.")]
        public void CollectionContainsAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of different types of the tested untyped collection should fail.")]
        public void CollectionContainsAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll on an empty collection with an non empty 'all' collection should fail.")]
        public void CollectionContainsAllTest16()
        {
            Collection<int> c = new Collection<int>();
            int[] all = { 4, 5, 6, 7 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an empty untyped 'all' collection should pass.")]
        public void CollectionContainsAllTest17()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList();
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' on an empty collection should fail.")]
        public void CollectionContainsAllTest18()
        {
            ArrayList c = new ArrayList();
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }
    }
}