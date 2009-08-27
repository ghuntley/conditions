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
        public void IsEmptyTest01()
        {
            ICollection c = null;
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty collection should pass.")]
        public void IsEmptyTest02()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on a null reference to IEnumerable should pass.")]
        public void IsEmptyTest03()
        {
            IEnumerable c = null;
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty IEnumerable should pass.")]
        public void IsEmptyTest04()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty ICollection should fail.")]
        public void IsEmptyTest05()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty IEnumerable should fail.")]
        public void IsEmptyTest06()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty with the conditionDescription argument should pass.")]
        public void IsEmptyTest07()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsEmpty("condition should hold");
        }

        [TestMethod]
        [Description("Calling a failing IsEmpty with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsEmptyTest08()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            try
            {
                Condition.Requires(c, "c").IsEmpty("{0} should have one, two or at least some elements :-)");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("c should have one, two or at least some elements :-)"));
            }
        }

        [TestMethod]
        [Description("Calling IsEmpty on an non empty IEnumerable should succeed when exceptions are suppressed.")]
        public void IsEmptyTest09()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).SuppressExceptionsForTest().IsEmpty();
        }
    }
}
