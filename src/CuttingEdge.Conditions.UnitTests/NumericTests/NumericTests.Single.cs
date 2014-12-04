using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.NumericTests
{
    [TestClass]
    public partial class NumericSingleTests
    {
        [TestMethod]
        [Description("Calling IsNaN on Single x with x is not a number should succeed.")]
        public void IsSingleNaNTest01()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Single x with x is a number should fail.")]
        public void IsSingleNaNTest02()
        {
            Single a = 4;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [Description("Calling IsNaN on Single x with x not a number and conditionDescription should pass.")]
        public void IsSingleNaNTest03()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Single x with x a number and conditionDescription should fail.")]
        public void IsSingleNaNTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Single x with x is a number should succeed.")]
        public void IsSingleNonNaNTest01()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Single x with x is not a number should fail.")]
        public void IsSingleNonNaNTest02()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNonNaNTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Single x with x not a number and conditionDescription should fail.")]
        public void IsSingleNonNaNTest04()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Single x with x is possitive infinity should succeed.")]
        public void IsSingleInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Single x with x is a number should fail.")]
        public void IsSingleInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Single x with x positive infinity and conditionDescription should pass.")]
        public void IsSingleInfinityTest04()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Single x with x a number and conditionDescription should fail.")]
        public void IsSingleInfinityTest05()
        {
            Single a = 4;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Single x with x is possitive infinity should fail.")]
        public void IsSingleNotInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Single x with x positive infinity and conditionDescription should fail.")]
        public void IsSingleNotInfinityTest05()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Single x with x is negative infinity should fail.")]
        public void IsSinglePositiveInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Single x with x is possitive infinity should succeed.")]
        public void IsSinglePositiveInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Single x with x is a number should fail.")]
        public void IsSinglePositiveInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Single x with x positive infinity and conditionDescription should pass.")]
        public void IsSinglePositiveInfinityTest04()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Single x with x negative infinity and conditionDescription should fail.")]
        public void IsSinglePositiveInfinityTest05()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNotPositiveInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Single x with x is possitive infinity should fail.")]
        public void IsSingleNotPositiveInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotPositiveInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotPositiveInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Single x with positive infinity and conditionDescription should fail.")]
        public void IsSingleNotPositiveInfinityTest05()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Single x with x is positive infinity should fail.")]
        public void IsSingleNegativeInfinityTest01()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNegativeInfinityTest02()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Single x with x is a number should fail.")]
        public void IsSingleNegativeInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Single x with x negative infinitiy and conditionDescription should pass.")]
        public void IsSingleNegativeInfinityTest04()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Single x with x positive infinity and conditionDescription should fail.")]
        public void IsSingleNegativeInfinityTest05()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Single x with x is positive infinity should succeed.")]
        public void IsSingleNotNegativeInfinityTest01()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotNegativeInfinityTest02()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotNegativeInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotNegativeInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Single x with x negative infinity and conditionDescription should fail.")]
        public void IsSingleNotNegativeInfinityTest05()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }
    }
}
