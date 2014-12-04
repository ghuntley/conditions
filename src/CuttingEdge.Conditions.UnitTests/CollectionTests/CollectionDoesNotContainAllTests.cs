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
            Condition.Requires(c).DoesNotContainAll(all);
        }

        // Calling DoesNotContainAll on a Collection should compile
        internal static void CollectionDoesNotContainAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Collection<int> all = new Collection<int> { 2 };
            Condition.Requires(c).DoesNotContainAll(all);
        }

        // Calling DoesNotContainAll on an IEnumerable should compile
        internal static void CollectionDoesNotContainAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Collection<int> all = new Collection<int> { 2 };
            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with a 'any' collection containing all elements of the tested collection should fail.")]
        public void CollectionDoesNotContainAllTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            Condition.Requires(c).DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };
            Condition.Requires(c).DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing no element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };
            Condition.Requires(c).DoesNotContainAll(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of different types of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };

            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing not all elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });
            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of different types of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };

            Condition.Requires(c).DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotContainAllTest16()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            IEnumerable<int> elements = new int[] { 1, 2, 3 };
            Condition.Requires(c).DoesNotContainAll(elements, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing DoesNotContainAll with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAllTest17()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                Condition.Requires(c, "c").DoesNotContainAll(c, "{0} must not contain all of the supplied elements");
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
            Condition.Requires(c).DoesNotContainAll(elements, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing DoesNotContainAll with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAllTest19()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                Condition.Requires(c, "c").DoesNotContainAll(c, "{0} must not contain all of the supplied elements");
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
            Condition.Requires(set).DoesNotContainAll(elements);
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
            Condition.Requires(set).DoesNotContainAll(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll on a null collection with a null reference as 'any' collection should succeed when exceptions are suppressed.")]
        public void CollectionDoesNotContainAllTest22()
        {
            Collection<int> c = null;
            int[] elements = null;
            Condition.Requires(c).SuppressExceptionsForTest().DoesNotContainAll(elements);
        }
    }
}