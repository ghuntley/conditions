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

namespace CuttingEdge.Conditions.UnitTests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Ensures method.
    /// </summary>
    [TestClass]
    public class EntryPointEnsuresTests
    {
        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Checks whether the validator returned from Ensures() will fail with an PostconditionException.")]
        public void EnsuresTest01()
        {
            int a = 3;
            Condition.Ensures(a).IsEqualTo(4);
        }

        [TestMethod]
        [Description("Checks whether the parameterName on the Ensures() will be used.")]
        public void EnsuresTest02()
        {
            int a = 3;
            try
            {
                Condition.Ensures(a, "foobar").IsGreaterThan(a);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, ex.Message.Contains("foobar"));
            }
        }

        [TestMethod]
        [Description("Checks whether supplying an invalid ConstraintViolationType results in the return of the default exception.")]
        public void EnsuresTest03()
        {
            ConditionValidator<int> ensuresValidator = Condition.Ensures(3);

            const string ValidCondition = "valid condition";
            const string ValidAdditionalMessage = "valid additional message";
            const ConstraintViolationType InvalidConstraintViolationType = (ConstraintViolationType)666;

            const string AssertMessage = "EnsuresValidator.ThrowException should throw an " +
                "ArgumentException when an invalid ConstraintViolationType is supplied.";

            try
            {
                ensuresValidator.ThrowException(ValidCondition, ValidAdditionalMessage,
                    InvalidConstraintViolationType);

                Assert.Fail(AssertMessage);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(PostconditionException), ex.GetType(), AssertMessage);

                Assert.IsTrue(ex.Message.Contains(ValidCondition),
                    "The exception message does not contain the condition.");
            }
        }
    }
}