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
    /// Tests the ValidatorExtensions.IsShorterThan method.
    /// </summary>
    [TestClass]
    public class CollectionIsShorterThanTests
    {
        [TestMethod]
        [Description("Calling IsShorterThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(2) with a collection containing one element should pass.")]
        public void CollectionIsShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().IsShorterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(1) with a collection containing one element should fail.")]
        public void CollectionIsShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(1) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(1) on a null reference should pass.")]
        public void CollectionIsShorterThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterThan(0) on a null reference should fail.")]
        public void CollectionIsShorterThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsShorterThan(0);
        }
    }
}