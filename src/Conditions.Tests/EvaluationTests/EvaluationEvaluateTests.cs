﻿using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.EvaluationTests
{
    [TestClass]
    public class EvaluationEvaluateTests
    {
        [TestMethod]
        [Description("Calling Evaluate on integer x with boolean 'true' should pass.")]
        public void EvaluateTest01()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(true);
        }

        [TestMethod]
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'true' should pass.")
        ]
        public void EvaluateTest02()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(true, String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Evaluate on integer x with boolean 'false' should fail.")]
        public void EvaluateTest03()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'false' should fail."
            )]
        public void EvaluateTest04()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(false, String.Empty);
        }

        [TestMethod]
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 3)' should pass.")]
        public void EvaluateTest05()
        {
            int a = 3;
            Expression<Func<int, bool>> expression = x => (x == 3);
            Condition.Requires(a).Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 4)' should fail.")]
        public void EvaluateTest06()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(x => x == 4);
        }

        [TestMethod]
        [Description("Calling Evaluate on string x (hoi) with expression '(x) => (x == hoi)' should pass.")]
        public void EvaluateTest07()
        {
            string a = "hoi";
            Condition.Requires(a).Evaluate(x => x == "hoi");
        }

        [TestMethod]
        [Description("Calling Evaluate on object x with expression 'x => true' should pass.")]
        public void EvaluateTest08()
        {
            object a = new object();
            Condition.Requires(a).Evaluate(x => true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description(
            "Calling Evaluate on null object x with expression '(x) => (x != null)' should fail with ArgumentNullException."
            )]
        public void EvaluateTest09()
        {
            object a = null;
            Condition.Requires(a).Evaluate(x => x != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description(
            "Calling Evaluate on null object x with expression '(x) => (x == 3)' should fail with ArgumentNullException."
            )]
        public void EvaluateTest10()
        {
            int? a = null;
            Condition.Requires(a).Evaluate(x => x == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Evaluate on null object x with boolean 'false' should fail with ArgumentNullException.")]
        public void EvaluateTest11()
        {
            object a = null;
            Condition.Requires(a).Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description("Calling Evaluate on enum x with boolean 'false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest12()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            Condition.Requires(day).Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        [Description(
            "Calling Evaluate on enum x with expression 'x => false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest13()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            Condition.Requires(day).Evaluate(x => false);
        }

        [TestMethod]
        [Description(
            "Calling the Evaluate overload containing the description message, should result in a exception message containing that description."
            )]
        public void EvaluateTest14()
        {
            string expectedMessage = "value should not be null. The actual value is null." +
                                     Environment.NewLine + TestHelper.CultureSensitiveArgumentExceptionParameterText +
                                     ": value";

            object a = null;
            try
            {
                Condition.Requires(a).Evaluate(a != null, "{0} should not be null");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description(
            "Calling the Evaluate overload containing a invalid description message, should pass and result in a exception message containing that description."
            )]
        public void EvaluateTest15()
        {
            string expectedMessage = "{1} should not be null. The actual value is null." +
                                     Environment.NewLine + TestHelper.CultureSensitiveArgumentExceptionParameterText +
                                     ": value";

            object a = null;
            try
            {
                Condition.Requires(a).Evaluate(a != null, "{1} should not be null");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Evaluate with lambda 'null' should fail with an ArgumentException.")]
        public void EvaluateTest16()
        {
            Condition.Requires(3).Evaluate(null);
        }

        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Calling Evaluate with lambda 'null' should fail with an PostconditionException.")]
        public void EvaluateTest17()
        {
            Condition.Ensures(3).Evaluate(null);
        }

        [TestMethod]
        [Description("Calling Evaluate with boolen 'false' should succeed when exceptions are suppressed.")]
        public void EvaluateTest18()
        {
            Condition.Requires(3).SuppressExceptionsForTest().Evaluate(false);
        }

        [TestMethod]
        [Description("Calling Evaluate with lambda 'null' should succeed when exceptions are suppressed.")]
        public void EvaluateTest19()
        {
            Condition.Requires(3).SuppressExceptionsForTest().Evaluate(null);
        }
    }
}