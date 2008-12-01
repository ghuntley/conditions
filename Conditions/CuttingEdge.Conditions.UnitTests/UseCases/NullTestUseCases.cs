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
                param.Requires("param").IsNotNull();
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
                param.Requires("param").IsNotNull();
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
                param.Requires("param").IsNull();
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
                param.Requires("param").IsNull();
            });
        }
    }
}
