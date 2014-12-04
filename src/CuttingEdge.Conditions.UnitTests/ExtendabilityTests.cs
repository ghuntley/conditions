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
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public sealed class ExtendabilityTests
    {
        [TestMethod]
        [Description("Tests whether the framework can be extended.")]
        public void ExtendabilityTest01()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest02()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest03()
        {
            int value = 1;

            Condition.Ensures(value).MyExtension(new[] { 2 });
        }

        [TestMethod]
        [Description("Tests whether the API works without the use of extension methods.")]
        public void ExtendabilityTest04()
        {
            int value = 1;
            ValidatorExtensions.IsGreaterOrEqual(Condition.Requires(value, "value"), 0);
        }
    }
}