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
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class CollectionContainsTests
    {
        // Calling Contains on an array should compile.
        internal static void CollectionContainsShouldCompileTest01()
        {
            int[] c = { 1 };
            c.Requires().Contains(1);
        }

        // Calling Contains on a Collection should compile.
        internal static void CollectionContainsShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        // Calling Contains on an IEnumerable should compile.
        internal static void CollectionContainsShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on null reference should fail.")]
        public void CollectionContainsTest01()
        {
            Collection<int> c = null;
            c.Requires().Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an empty collection should fail.")]
        public void CollectionContainsTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an Collection that contains the tested value should pass.")]
        public void CollectionContainsTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an non-generic Collection that contains the tested value should pass.")]
        public void CollectionContainsTest04()
        {
            ArrayList c = new ArrayList { 1 };
            c.Requires().Contains((object)1);
        }

        [TestMethod]
        [Description("Calling Contains on an typed Collection that contains the tested non-generic value should pass.")]
        public void CollectionContainsTest05()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains((object)1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an typed Collection that doesn't contain the tested non-generic value should fail.")]
        public void CollectionContainsTest06()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(new object());
        }

        [TestMethod]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest07()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            c.Requires().Contains((object)1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T> and doesn't contain the tested value should fail.")]
        public void CollectionContainsTest08()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            c.Requires().Contains((object)1001);
        }

        [TestMethod]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest09()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            c.Requires().Contains(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but doesn't contain the tested value should fail.")]
        public void CollectionContainsTest10()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            c.Requires().Contains(11);
        }

        [TestMethod]
        [Description("Calling Contains while supplying the optional conditionsDescription should pass.")]
        public void CollectionContainsTest11()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            c.Requires().Contains(10, "{0} should contain the value 10");           
        }

        [TestMethod]
        [Description("Calling a failing Contains with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest12()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            try
            {
                c.Requires("c").Contains(11, "{0} should contain the integer 11");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should contain the integer 11"));
            }
        }

        [TestMethod]
        [Description("Calling Contains while supplying the optional conditionsDescription should pass.")]
        public void CollectionContainsTest13()
        {
            ArrayList c = new ArrayList(Enumerable.Range(1, 10).ToArray());
            object value = 10;
            c.Requires().Contains(value, "{0} should contain the value 10");
        }

        [TestMethod]
        [Description("Calling a failing Contains with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest14()
        {
            ArrayList c = new ArrayList(Enumerable.Range(1, 10).ToArray());
            try
            {
                object value = 11;
                c.Requires("c").Contains(value, "{0} should contain the integer 11");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should contain the integer 11"));
            }
        }

        [TestMethod]
        [Description("Calling the generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest15()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            // Otherwise this behavior would be inconsistent with the non-generic overload of Contains.
            try
            {
                // Call the generic Contains<C, E>(Validator<C>, E) overload.
                set.Requires().Contains(3);
                Assert.Fail("Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling the non-generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest16()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            try
            {
                // Call the non-generic Contains<T>(Validator<T>, object) overload.
                set.Requires().Contains((object)3);
                Assert.Fail("Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }
    }
}