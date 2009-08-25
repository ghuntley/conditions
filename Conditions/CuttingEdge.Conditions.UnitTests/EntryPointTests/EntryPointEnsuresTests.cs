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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Ensures method.
    /// </summary>
    [TestClass]
    public class EntryPointEnsuresTests
    {
        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Checks whether the validator returned from Ensures() will fail with an PostconditionException.")]
        public void EnsuresTest01()
        {
            int a = 3;
            Condition.Ensures(a).Throw(String.Empty);
        }

        [TestMethod]
        [Description("Checks whether the parameterName on the Ensures() will be used.")]
        public void EnsuresTest02()
        {
            int a = 3;
            try
            {
                Condition.Ensures(a, "foobar").IsGreaterThan(a);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, ex.Message.Contains("foobar"));
            }
        }
    }
}