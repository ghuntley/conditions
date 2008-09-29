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
using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.EvaluationTests
{
    [TestClass]
    public class EvaluationEvaluateTests
    {
        [TestMethod]
        [Description("Calling Evaluate on integer x with boolean 'true' should pass.")]
        public void EvaluateTest01()
        {
            int a = 3;
            a.Requires().Evaluate(true);
        }

        [TestMethod]
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'true' should pass.")]
        public void EvaluateTest02()
        {
            int a = 3;
            a.Requires().Evaluate(true, String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Evaluate on integer x with boolean 'false' should fail.")]
        public void EvaluateTest03()
        {
            int a = 3;
            a.Requires().Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'false' should fail.")]
        public void EvaluateTest04()
        {
            int a = 3;
            a.Requires().Evaluate(false, String.Empty);
        }

        [TestMethod]
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 3)' should pass.")]
        public void EvaluateTest05()
        {
            int a = 3;
            Expression<Func<int, bool>> expression = x => (x == 3);
            a.Requires().Evaluate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 4)' should fail.")]
        public void EvaluateTest06()
        {
            int a = 3;
            a.Requires().Evaluate(x => x == 4);
        }

        [TestMethod]
        [Description("Calling Evaluate on sring x (hoi) with expression '(x) => (x == hoi)' should pass.")]
        public void EvaluateTest07()
        {
            string a = "hoi";
            a.Requires().Evaluate(x => x == "hoi");
        }

        [TestMethod]
        [Description("Calling Evaluate on object x with expression 'x => true' should pass.")]
        public void EvaluateTest08()
        {
            object a = new object();
            a.Requires().Evaluate(x => true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Evaluate on null object x with expression '(x) => (x != null)' should fail with ArgumentNullException.")]
        public void EvaluateTest09()
        {
            object a = null;
            a.Requires().Evaluate(x => x != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Evaluate on null object x with expression '(x) => (x == 3)' should fail with ArgumentNullException.")]
        public void EvaluateTest10()
        {
            int? a = null;
            a.Requires().Evaluate(x => x == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Evaluate on null object x with boolean 'false' should fail with ArgumentNullException.")]
        public void EvaluateTest11()
        {
            object a = null;
            a.Requires().Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling Evaluate on enum x with boolean 'false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest12()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            day.Requires().Evaluate(false);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.InvalidEnumArgumentException))]
        [Description("Calling Evaluate on enum x with expression 'x => false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest13()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            day.Requires().Evaluate(x => false);
        }

        [TestMethod]
        [Description("Calling the Evaluate overload containing the description message, should result in a exception message containing that description.")]
        public void EvaluateTest14()
        {
            string expectedMessage = "value should not be null. The actual value is null." +
                Environment.NewLine + TestHelper.ArgumentExceptionParameterName + ": value";

            object a = null;
            try
            {
                a.Requires().Evaluate(a != null, "{0} should not be null");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling the Evaluate overload containing a invalid description message, should pass and result in a exception message containing that description.")]
        public void EvaluateTest15()
        {
            string expectedMessage = "{1} should not be null. The actual value is null." +
                Environment.NewLine + TestHelper.ArgumentExceptionParameterName + ": value";

            object a = null;
            try
            {
                a.Requires().Evaluate(a != null, "{1} should not be null");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }
    }
}