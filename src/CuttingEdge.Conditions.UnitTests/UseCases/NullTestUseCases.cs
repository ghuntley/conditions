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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.UseCases
{
    [TestClass]
    public class NullTestUseCases
    {
        [TestMethod]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull01()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNotNull();
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNotNull();
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull01()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNull();
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNull();
            });
        }
    }
}
