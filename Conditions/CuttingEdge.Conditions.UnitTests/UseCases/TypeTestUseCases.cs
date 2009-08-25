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
    public class TypeTestUseCases
    {
        [TestMethod]
        [Description("Use Case code should match with use of IsOfType.")]
        public void CheckIsOfType01()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (!(param is string))
                {
                    throw new ArgumentException("param is not of type string.", "param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsOfType(typeof(string));
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNotOfType.")]
        public void CheckIsNotOfType01()
        {
            object param = string.Empty;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (param is string)
                {
                    throw new ArgumentException("param should not be of type string.", "param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNotOfType(typeof(string));
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsNotOfType.")]
        public void CheckIsNotOfType02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (param is string)
                {
                    throw new ArgumentException("param should not be of type string.", "param");
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsNotOfType(typeof(string));
            });
        }

        [TestMethod]
        [Description("Use Case code should match with use of IsOfType.")]
        public void CheckIsOfType02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the use would write without conditions.
                if (!(param is string))
                {
                    if (param == null)
                    {
                        throw new ArgumentNullException("param", "param should not be of type string.");
                    }
                    else
                    {
                        throw new ArgumentException("param should not be of type string.", "param");
                    }
                }
            },
            () =>
            {
                // This is what the user should write with conditions.
                Condition.Requires(param, "param").IsOfType(typeof(string));
            });
        }
    }
}
