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
using System.Linq;

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
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of different types of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };

            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing not all elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of different types of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };

            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotContainAllTest16()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            IEnumerable<int> elements = new int[] { 1, 2, 3 };
            c.Requires().DoesNotContainAll(elements, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing DoesNotContainAll with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAllTest17()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                c.Requires("c").DoesNotContainAll(c, "{0} must not contain all of the supplied elements");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c must not contain all of the supplied elements"));
            }
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotContainAllTest18()
        {
            ArrayList c = new ArrayList { 1, 2 };
            ICollection elements = new int[] { 1, 2, 3 };
            c.Requires().DoesNotContainAll(elements, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing DoesNotContainAll with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAllTest19()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                c.Requires("c").DoesNotContainAll(c, "{0} must not contain all of the supplied elements");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c must not contain all of the supplied elements"));
            }
        }

        [TestMethod]
        [Description("Calling the generic DoesNotContainAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainAllTest20()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.IsTrue(set.Count == 1);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(1), "OddEqualityComparer is implemented incorrectly.");
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 1, 3 };

            // Call the generic DoesNotContainAll<C, E>(Validator<C>, IEnumerable<E>) overload.
            // DoesNotContainAll should fail, because the value is not in the initial list,
            // otherwise this behavior would be inconsistent with the non-generic overload of DoesNotContainAll.
            set.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [Description("Calling the non-generic DoesNotContainAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainAllTest21()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.IsTrue(set.Count == 1);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(1), "OddEqualityComparer is implemented incorrectly.");
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 1, 3 };

            // Call the non-generic DoesNotContainAll<T>(Validator<T>, IEnumerable) overload.
            // DoesNotContainAll should fail, because the value is not in the initial list.
            set.Requires().DoesNotContainAll(elements);
        }
    }
}