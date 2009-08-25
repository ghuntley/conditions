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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotLongerThan method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotLongerThanTests
    {
        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(1) with a collection containing two element should fail.")]
        public void CollectionIsNotLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Condition.Requires(set).IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(2) with a collection containing two elements should pass.")]
        public void CollectionIsNotLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Condition.Requires(set).IsNotLongerThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(0) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) on a null reference should pass.")]
        public void CollectionIsNotLongerThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotLongerThan(-1) on a null reference should fail.")]
        public void CollectionIsNotLongerThanTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(-1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan with the condtionDescription parameter should pass.")]
        public void CollectionIsNotLongerThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(1, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsNotLongerThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotLongerThan(-1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }
    }
}