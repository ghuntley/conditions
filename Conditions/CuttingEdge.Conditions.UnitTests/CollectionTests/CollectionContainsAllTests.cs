#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            Condition.Requires(c).ContainsAll(all);
        }

        // Calling ContainsAll on a Collection should compile
        internal static void CollectionContainsAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAll(c);
        }

        // Calling ContainsAll on an IEnumerable should compile
        internal static void CollectionContainsAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAll(c);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest01()
        {
            Collection<int> c = null;
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest04()
        {
            Collection<int> c = null;
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with a 'all' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAllTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 1, 2, 3, 4 };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing one element of the tested collection should fail.")]
        public void CollectionContainsAllTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 4, 5, 6, 7 };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAllTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 5, 6, 7, 8 };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested typed collection should pass.")]
        public void CollectionContainsAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should pass.")]
        public void CollectionContainsAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of different types of the tested non-generic collection should pass.")]
        public void CollectionContainsAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of the tested typed collection should fail.")]
        public void CollectionContainsAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should fail.")]
        public void CollectionContainsAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of different types of the tested non-generic collection should fail.")]
        public void CollectionContainsAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll on an empty collection with an non empty 'all' collection should fail.")]
        public void CollectionContainsAllTest16()
        {
            Collection<int> c = new Collection<int>();
            int[] all = { 4, 5, 6, 7 };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an empty non-generic 'all' collection should pass.")]
        public void CollectionContainsAllTest17()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList();
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an non-generic 'all' on an empty collection should fail.")]
        public void CollectionContainsAllTest18()
        {
            ArrayList c = new ArrayList();
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAllTest19()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            Condition.Requires(c).ContainsAll(c, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing ContainsAll with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAllTest20()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                Condition.Requires(c, "c").ContainsAll(Enumerable.Range(3, 2), "{0} must contain all");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c must contain all"));
            }
        }

        [TestMethod]
        [Description("Calling ContainsAll on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAllTest21()
        {
            ArrayList c = new ArrayList { 1, 2 };
            Condition.Requires(c).ContainsAll(c, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing ContainsAll with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAllTest22()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                Condition.Requires(c, "c").ContainsAll(new ArrayList { 3, 4 }, "{0} must contain all");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c must contain all"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll on non-empty collection that doesn't contain a null value with a 'all' collection that does contain the value null should fail.")]
        public void CollectionContainsAllTest023()
        {
            int?[] c = new int?[] { 1 };
            int?[] all = new int?[] { null };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll on non-empty non-generic collection that doesn't contain a null value with a 'all' collection that does contain the value null should fail.")]
        public void CollectionContainsAllTest024()
        {
            ArrayList c = new ArrayList { 1 };
            ArrayList all = new ArrayList { null };
            Condition.Requires(c).ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling the generic ContainsAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAllTest25()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 3 };

            // ContainsAll should fail, because the value is not in the initial list,
            // otherwise this behavior would be inconsistent with the non-generic overload of ContainsAll.
            try
            {
                // Call the generic ContainsAll<C, E>(Validator<C>, IEnumerable<E>) overload.
                Condition.Requires(set).ContainsAll(elements);
                Assert.Fail("ContainsAll did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling the non-generic ContainsAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAllTest26()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            Assert.IsTrue(set.Count == 2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.IsTrue(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 3 };

            // ContainsAll should fail, because the value is not in the initial list.
            try
            {
                // Call the non-generic ContainsAll<T>(Validator<T>, IEnumerable) overload.
                Condition.Requires(set).ContainsAll(elements);
                Assert.Fail("ContainsAll did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should succeed when exceptions are suppressed.")]
        public void CollectionContainsAllTest27()
        {
            int[] c = { 1 };
            int[] all = { 2 };
            Condition.Requires(c).SuppressExceptionsForTest().ContainsAll(all);
        }
    }
}
