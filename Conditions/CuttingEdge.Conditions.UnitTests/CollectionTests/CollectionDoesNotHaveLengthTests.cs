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
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    [TestClass]
    public class CollectionDoesNotHaveLengthTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an untyped collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            queue.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an untyped collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            queue.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an typed collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength(0) with a collection containing one element should pass.")]
        public void CollectionDoesNotHaveLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().DoesNotHaveLength(0);
        }
    }
}