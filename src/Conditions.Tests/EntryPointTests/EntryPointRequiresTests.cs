using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Requires method.
    /// </summary>
    [TestClass]
    public class EntryPointRequiresTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Checks whether the validator returned from Requires() will fail with an ArgumentException.")]
        public void RequiresTest01()
        {
            int a = 3;
            Condition.Requires(a).IsEqualTo(4);
        }

        [TestMethod]
        [Description("Checks whether the parameterName on the Requires() will be used.")]
        public void RequiresTest02()
        {
            int a = 3;
            try
            {
                Condition.Requires(a, "foobar").IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, ex.Message.Contains("foobar"));
            }
        }

        [TestMethod]
        [Description(
            "Checks whether supplying an invalid ConstraintViolationType results in the return of the default exception."
            )]
        public void RequiresTest03()
        {
            ConditionValidator<int> requiresValidator = Condition.Requires(3);

            const string ValidCondition = "valid condition";
            const string ValidAdditionalMessage = "valid additional message";
            const ConstraintViolationType InvalidConstraintViolationType = (ConstraintViolationType) 666;

            const string AssertMessage = "RequiresValidator.ThrowException should throw an " +
                                         "ArgumentException when an invalid ConstraintViolationType is supplied.";

            try
            {
                requiresValidator.ThrowException(ValidCondition, ValidAdditionalMessage,
                    InvalidConstraintViolationType);

                Assert.Fail(AssertMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof (ArgumentException), ex.GetType(), AssertMessage);

                Assert.IsTrue(ex.Message.Contains(ValidCondition),
                    "The exception message does not contain the condition.");
            }
        }
    }
}