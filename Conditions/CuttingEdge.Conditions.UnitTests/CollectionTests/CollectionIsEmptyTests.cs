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
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    [TestClass]
    public class CollectionIsEmptyTests
    {
        [TestMethod]
        [Description("Calling IsEmpty on a null reference to ICollection should pass.")]
        public void IsEmptyTest1()
        {
            ICollection c = null;
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty collection should pass.")]
        public void IsEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on a null reference to IEnumerable should pass.")]
        public void IsEmptyTest3()
        {
            IsEmptyTestEnumerable c = null;
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty IEnumerable should pass.")]
        public void IsEmptyTest4()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(true);
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty ICollection should fail.")]
        public void IsEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty IEnumerable should fail.")]
        public void IsEmptyTest6()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(false);
            c.Requires().IsEmpty();
        }
    }
}
