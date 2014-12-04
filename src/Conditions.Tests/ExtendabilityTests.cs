using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests
{
    [TestClass]
    public sealed class ExtendabilityTests
    {
        [TestMethod]
        [Description("Tests whether the framework can be extended.")]
        public void ExtendabilityTest01()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] {1});
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest02()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] {2});
        }

        [TestMethod]
        [ExpectedException(typeof (PostconditionException))]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest03()
        {
            int value = 1;

            Condition.Ensures(value).MyExtension(new[] {2});
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