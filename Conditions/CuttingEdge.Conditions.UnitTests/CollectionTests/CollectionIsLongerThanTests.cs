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
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    [TestClass]
    public class CollectionIsLongerThanTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(1) with a collection containing two element should pass.")]
        public void CollectionIsLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            set.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(2) with a collection containing two elements should fail.")]
        public void CollectionIsLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            set.Requires().IsLongerThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            list.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(0) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            list.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(-1) on a null reference should pass.")]
        public void CollectionIsLongerThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerThan(0) on a null reference should fail.")]
        public void CollectionIsLongerThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan with the condtionDescription parameter should pass.")]
        public void CollectionIsLongerThanTest10()
        {
            IEnumerable list = null;

            list.Requires().IsLongerThan(-1, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsLongerThanTest11()
        {
            IEnumerable list = null;
            try
            {
                list.Requires("list").IsLongerThan(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }
    }
}