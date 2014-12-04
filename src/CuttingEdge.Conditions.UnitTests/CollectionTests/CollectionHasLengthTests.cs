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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.HasLength method.
    /// </summary>
    [TestClass]
    public class CollectionHasLengthTests
    {
        [TestMethod]
        [Description("Calling HasLength(0) with an non-generic collection containing no elements should pass.")]
        public void CollectionHasLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            Condition.Requires(queue).HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an typed collection containing no elements should pass.")]
        public void CollectionHasLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an non-generic collection containing one element should pass.")]
        public void CollectionHasLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            Condition.Requires(queue).HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an typed collection containing one element should pass.")]
        public void CollectionHasLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with a collection containing one element should fail.")]
        public void CollectionHasLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(1) with an ArrayList containing one element should fail.")]
        public void CollectionHasLengthTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an ArrayList containing no elements should pass.")]
        public void CollectionHasLengthTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) on a null reference should pass.")]
        public void CollectionHasLengthTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling HasLength(1) on a null reference should fail.")]
        public void CollectionHasLengthTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionHasLengthTest10()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength with the condtionDescription parameter should pass.")]
        public void CollectionHasLengthTest11()
        {
            IEnumerable list = null;

            Condition.Requires(list).HasLength(0, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing HasLength should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionHasLengthTest12()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").HasLength(1, "the given {0} should have 1 element");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("the given list should have 1 element"));
            }
        }

        [TestMethod]
        [Description("Calling HasLength(0) with a collection containing one element should succeed when exceptions are suppressed.")]
        public void CollectionHasLengthTest13()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).SuppressExceptionsForTest().HasLength(0);
        }
    }
}