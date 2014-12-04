#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public class SelfTests
    {
        private enum DescriptionStatus
        {
            Correct = 0,
            NoDescriptionAttribute,
            NoDescriptionMessage,
            IncorrectDescriptionMessage,
        }

        [TestMethod]
        [Description("This test tests the tests and searches for methods that lack the [TestMethod] attribute.")]
        public void AllPublicMethodsShouldBeMarkedWithTheTestAttribute()
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(TestHelper).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0
                select t;

            MethodBase[] untestableMethods =
                (from unitTestClass in unitTestClasses
                from publicMethod in unitTestClass.GetMethods()
                where publicMethod.GetParameters().Length == 0
                where publicMethod.GetCustomAttributes(typeof(TestMethodAttribute), true).Length == 0
                where publicMethod.ReturnType == typeof(void)
                select publicMethod).ToArray();

            if (untestableMethods.Length == 0)
            {
                return;
            }

            string message = "The following public methods that aren't marked with the " +
                "[TestMethod] attribute:" + Environment.NewLine;

            foreach (var method in untestableMethods)
            {
                message += method.Name + Environment.NewLine;
            }

            Assert.Fail(message);
        }

        [TestMethod]
        [Description("This test tests the tests and searches for test methods that lack a proper description.")]
        public void AllTestsShouldHaveAValidDescription()
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(TestHelper).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0
                select t;

            MethodBase[] testMethods =
                (from unitTestClass in unitTestClasses
                from testMethod in unitTestClass.GetMethods()
                where testMethod.GetParameters().Length == 0
                where testMethod.GetCustomAttributes(typeof(TestMethodAttribute), true).Length == 1
                where testMethod.ReturnType == typeof(void)
                where GetMethodDescriptionCheck(testMethod) != DescriptionStatus.Correct
                select testMethod).ToArray();

            if (testMethods.Length == 0)
            {
                return;
            }

            string message = "The following test methods have an incorrect [Description(..)] message. " +
                "The description should not be empty and should end with 'should fail.' when an exception " +
                "is expected." + Environment.NewLine;

            foreach (var method in testMethods)
            {
                message += method.DeclaringType.Name + "." + method.Name + " reason: " +
                    GetMethodDescriptionCheck(method).ToString() + Environment.NewLine;
            }

            Assert.Fail(message);
        }

        private static DescriptionStatus GetMethodDescriptionCheck(MethodBase testMethod)
        {
            var descriptions = 
                testMethod.GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>().ToArray();
            
            if (descriptions == null || descriptions.Length == 0)
            {
                return DescriptionStatus.NoDescriptionAttribute;
            }

            string description = descriptions[0].Description;

            if (String.IsNullOrEmpty(description))
            {
                return DescriptionStatus.NoDescriptionMessage;
            }

            var methodShouldThrowException = 
                testMethod.GetCustomAttributes(typeof(ExpectedExceptionAttribute), true).Length > 0;

            if (methodShouldThrowException && !description.Contains("fail") && !description.Contains("throw"))
            {
                return DescriptionStatus.IncorrectDescriptionMessage;
            }

            return DescriptionStatus.Correct;
        }
    }
}