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
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotEmptyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest1()
        {
            ICollection c = null;
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an empty ICollection should fail.")]
        public void IsNotEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest3()
        {
            IsEmptyTestEnumerable c = null;
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should fail.")]
        public void IsNotEmptyTest4()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(true);
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty ICollection should pass.")]
        public void IsNotEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should pass.")]
        public void IsNotEmptyTest6()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(false);
            Condition.Requires(c).IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty with conditional description parameter on an not empty ICollection should pass.")]
        public void IsNotEmptyTest7()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(false);
            Condition.Requires(c).IsNotEmpty("conditionDescription");
        }

        [TestMethod]
        [Description("Calling a failing IsNotEmpty with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotEmptyTest8()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(true);
            try
            {
                Condition.Requires(c, "c").IsNotEmpty("{0} should have no elements what so ever");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should have no elements what so ever"));
            }
        }
    }
}