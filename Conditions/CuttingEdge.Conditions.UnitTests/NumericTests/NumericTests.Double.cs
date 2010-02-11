using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.NumericTests
{
    [TestClass]
    public partial class NumericDoubleTests
    {
        [TestMethod]
        [Description("Calling IsNaN on Double x with x is not a number should succeed.")]
        public void IsDoubleNaNTest01()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Double x with x is a number should fail.")]
        public void IsDoubleNaNTest02()
        {
            Double a = 4;
            Condition.Requires(a).IsNaN();
        }

        [TestMethod]
        [Description("Calling IsNaN on Double x with x not a number and conditionDescription should pass.")]
        public void IsDoubleNaNTest03()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNaN on Double x with x a number and conditionDescription should fail.")]
        public void IsDoubleNaNTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNaNTest05()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsNaN();
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Double x with x is a number should succeed.")]
        public void IsDoubleNonNaNTest01()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Double x with x is not a number should fail.")]
        public void IsDoubleNonNaNTest02()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNotNaN();
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNonNaNTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNaN on Double x with x not a number and conditionDescription should fail.")]
        public void IsDoubleNonNaNTest04()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNaNTest05()
        {
            Double a = Double.NaN;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNaN();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x with x is possitive infinity should succeed.")]
        public void IsDoubleInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Double x with x is a number should fail.")]
        public void IsDoubleInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsInfinity();
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x with x positive infinity and conditionDescription should pass.")]
        public void IsDoubleInfinityTest04()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsInfinity on Double x with x a number and conditionDescription should fail.")]
        public void IsDoubleInfinityTest05()
        {
            Double a = 4;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleInfinityTest06()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Double x with x is possitive infinity should fail.")]
        public void IsDoubleNotInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotInfinityTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInfinity on Double x with x positive infinity and conditionDescription should fail.")]
        public void IsDoubleNotInfinityTest05()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoublePositiveInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Double x with x is possitive infinity should succeed.")]
        public void IsDoublePositiveInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Double x with x is a number should fail.")]
        public void IsDoublePositiveInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Double x with x positive infinity and conditionDescription should pass.")]
        public void IsDoublePositiveInfinityTest04()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsPositiveInfinity on Double x with x negative infinity and conditionDescription should fail.")]
        public void IsDoublePositiveInfinityTest05()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoublePositiveInfinityTest06()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNotPositiveInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Double x with x is possitive infinity should fail.")]
        public void IsDoubleNotPositiveInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotPositiveInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotPositiveInfinityTest04()
        {
            Double a = 4; 
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotPositiveInfinity on Double x with positive infinity and conditionDescription should fail.")]
        public void IsDoubleNotPositiveInfinityTest05()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotPositiveInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotPositiveInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Double x with x is positive infinity should fail.")]
        public void IsDoubleNegativeInfinityTest01()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNegativeInfinityTest02()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Double x with x is a number should fail.")]
        public void IsDoubleNegativeInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Double x with x negative infinitiy and conditionDescription should pass.")]
        public void IsDoubleNegativeInfinityTest04()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNegativeInfinity on Double x with x positive infinity and conditionDescription should fail.")]
        public void IsDoubleNegativeInfinityTest05()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNegativeInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x with x is positive infinity should succeed.")]
        public void IsDoubleNotNegativeInfinityTest01()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotNegativeInfinityTest02()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotNegativeInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotNegativeInfinityTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotNegativeInfinity on Double x with x negative infinity and conditionDescription should fail.")]
        public void IsDoubleNotNegativeInfinityTest05()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsNotNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNegativeInfinityTest06()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNegativeInfinity();
        }
    }
}
