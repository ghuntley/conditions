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
    /// Tests the ValidatorExtensions.ContainsAny method.
    /// </summary>
    [TestClass]
    public class CollectionContainsAnyTests
    {
        // Calling ContainsAny on an array should compile.
        internal static void CollectionContainsAnyShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> any = c;
            c.Requires().ContainsAny(any);
        }

        // Calling ContainsAny on a Collection should compile.
        internal static void CollectionContainsAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        // Calling ContainsAny on an IEnumerable should compile.
        internal static void CollectionContainsAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with an empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAnyTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionContainsAnyTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with a 'any' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAnyTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of the tested typed collection should pass.")]
        public void CollectionContainsAnyTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 4, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of the tested non-generic collection should pass.")]
        public void CollectionContainsAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of different types of the tested non-generic collection should pass.")]
        public void CollectionContainsAnyTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Friday, 2 };

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of the tested typed collection should fail.")]
        public void CollectionContainsAnyTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of the tested non-generic collection should fail.")]
        public void CollectionContainsAnyTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of different types of the tested non-generic collection should fail.")]
        public void CollectionContainsAnyTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Saturday, 2, new object() };

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empty non-generic collection should fail.")]
        public void CollectionContainsAnyTest16()
        {
            ArrayList c = new ArrayList();
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest17()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList();
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an two collections that implement IEnumerable<T> but not IColletion<T> should pass.")]
        public void CollectionContainsAnyTest18()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            c.Requires().ContainsAny(c);
        }

        [TestMethod]
        [Description("Calling ContainsAny on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAnyTest19()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            c.Requires().ContainsAny(c, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing ContainsAny with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAnyTest20()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                c.Requires("c").ContainsAny(Enumerable.Range(3, 2), "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should contain some"));
            }
        }

        [TestMethod]
        [Description("Calling ContainsAny on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAnyTest21()
        {
            ArrayList c = new ArrayList { 1, 2 };
            c.Requires().ContainsAny(c, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing ContainsAny with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAnyTest22()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                c.Requires("c").ContainsAny(new ArrayList { 3, 4 }, "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should contain some"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with an non-empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest23()
        {
            Collection<int> c = null;
            int[] elements = new int[] { 1 };
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [Description("Calling ContainsAny on a collection containing a null value with an 'any' collection also containing a null value should succeed.")]
        public void CollectionContainsAnyTest24()
        {
            var collection = new int?[] { null };
            var elements = new int?[] { null };
            collection.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [Description("Calling the generic ContainsAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAnyTest25()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 3 };

            // Because the value is not in the initial list, ContainsAny should fail.
            // Otherwise this behavior would be inconsistent with the non-generic overload of ContainsAny.
            try
            {
                // Call the generic ContainsAny<C, E>(Validator<C>, IEnumerable<E>) overload.
                set.Requires().ContainsAny(elements);
                Assert.Fail("ContainsAny did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling the non-generic ContainsAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAnyTest26()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 3 };

            // Because the value is not in the initial list, ContainsAny should fail.
            try
            {
                // Call the non-generic ContainsAny<T>(Validator<T>, IEnumerable) overload.
                set.Requires().ContainsAny(elements);
                Assert.Fail("ContainsAny did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling ContainsAny with an self-referencing collection should not lead to an StackOverflowException.")]
        public void CollectionContainsAnyTest27()
        {
            // Define an array that contains itself.
            object[] evilArray = new object[1];
            evilArray[0] = evilArray;

            object[] collection = { 1, 2, 3 };

            try
            {
                collection.Requires().ContainsAny(evilArray);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }
    }
}