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
    /// Tests the ValidatorExtensions.IsNotLongerOrEqual method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotLongerOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsNotLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(2) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(1) on a null reference should pass.")]
        public void CollectionIsNotLongerOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotLongerOrEqual(0) on a null reference should fail.")]
        public void CollectionIsNotLongerOrEqualTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsNotLongerOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerOrEqual(1, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsNotLongerOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotLongerOrEqual(0, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }
    }
}