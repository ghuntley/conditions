using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests
{
    [TestClass]
    public class FluentUsageTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullFluently()
        {
            object o = null;
            o.Requires().IsNotNull();
        }
    }
}
