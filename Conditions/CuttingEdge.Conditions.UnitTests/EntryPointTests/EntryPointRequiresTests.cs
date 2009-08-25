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
    /// Tests the Condition.Requires method.
    /// </summary>
    [TestClass]
    public class EntryPointRequiresTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Checks whether the validator returned from Requires() will fail with an ArgumentException.")]
        public void RequiresTest01()
        {
            int a = 3;
            Condition.Requires(a).Throw(String.Empty);
        }

        [TestMethod]
        [Description("Checks whether the parameterName on the Requires() will be used.")]
        public void RequiresTest02()
        {
            int a = 3;
            try
            {
                Condition.Requires(a, "foobar").Throw(String.Empty);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, ex.Message.Contains("foobar"));
            }
        }
    }
}