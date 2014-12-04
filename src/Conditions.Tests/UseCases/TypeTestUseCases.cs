using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.UseCases
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
                    Condition.Requires(param, "param").IsOfType(typeof (string));
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
                    Condition.Requires(param, "param").IsNotOfType(typeof (string));
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
                    Condition.Requires(param, "param").IsNotOfType(typeof (string));
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
                    Condition.Requires(param, "param").IsOfType(typeof (string));
                });
        }
    }
}