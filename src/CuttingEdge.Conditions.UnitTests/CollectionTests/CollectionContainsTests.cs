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
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    [TestClass]
    public class CollectionContainsTests
    {
        // Calling Contains on an array should compile.
        internal static void CollectionContainsShouldCompileTest01()
        {
            int[] c = { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on a Collection should compile.
        internal static void CollectionContainsShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on an IEnumerable should compile.
        internal static void CollectionContainsShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on null reference should fail.")]
        public void CollectionContainsTest01()
        {
            Collection<int> c = null;
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an empty collection should fail.")]
        public void CollectionContainsTest02()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an Collection that contains the tested value should pass.")]
        public void CollectionContainsTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an non-generic Collection that contains the tested value should pass.")]
        public void CollectionContainsTest04()
        {
            ArrayList c = new ArrayList { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [TestMethod]
        [Description("Calling Contains on an typed Collection that contains the tested non-generic value should pass.")]
        public void CollectionContainsTest05()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an typed Collection that doesn't contain the tested non-generic value should fail.")]
        public void CollectionContainsTest06()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(new object());
        }

        [TestMethod]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest07()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            Condition.Requires(c).Contains((object)1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T> and doesn't contain the tested value should fail.")]
        public void CollectionContainsTest08()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            Condition.Requires(c).Contains((object)1001);
        }

        [TestMethod]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest09()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but doesn't contain the tested value should fail.")]
        public void CollectionContainsTest10()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(11);
        }

        [TestMethod]
        [Description("Calling Contains while supplying the optional conditionsDescription should pass.")]
        public void CollectionContainsTest11()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(10, "{0} should contain the value 10");           
        }

        [TestMethod]
        [Description("Calling a failing Contains with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest12()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            try
            {
                Condition.Requires(c, "c").Contains(11, "{0} should contain the integer 11");
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
            Condition.Requires(c).Contains(value, "{0} should contain the value 10");
        }

        [TestMethod]
        [Description("Calling a failing Contains with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest14()
        {
            ArrayList c = new ArrayList(Enumerable.Range(1, 10).ToArray());
            try
            {
                object value = 11;
                Condition.Requires(c, "c").Contains(value, "{0} should contain the integer 11");
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
                Condition.Requires(set).Contains(3);
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
                Condition.Requires(set).Contains((object)3);
                Assert.Fail("Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [TestMethod]
        [Description("Calling Contains on an a null reference should succeed when exceptions are suppressed.")]
        public void CollectionContainsTest17()
        {
            Collection<int> c = null;
            Condition.Requires(c).SuppressExceptionsForTest().Contains(1);
        }
    }
}