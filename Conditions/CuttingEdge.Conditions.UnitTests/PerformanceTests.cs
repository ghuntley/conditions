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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        [Description("This test tests the test class itself and searches for methods that lack the [TestMethod] attribute.")]
        public void SelfTest()
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(TestHelper).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0
                select t;

            var untestableMethods =
                from unitTestClass in unitTestClasses
                from publicMethod in unitTestClass.GetMethods()
                where publicMethod.GetParameters().Length == 0
                where publicMethod.GetCustomAttributes(typeof(TestMethodAttribute), true).Length == 0
                where publicMethod.ReturnType == typeof(void)
                select publicMethod;

            if (untestableMethods.Count() == 0)
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

        // This test checks whether methods are candidates to be inlined by the JIT compiler.
        // For this they must consist at most of 32 bytes of IL.
        // This test can only be performed in release mode, because methods will have less IL in release mode.
#if !DEBUG
        [TestMethod]
        [Description("Validates if the methods that are designed for inlining can indeed be inlined by the JIT compiler.")]
        public void CanMethodsBeInlinedTest()
        {
            Type extensions = typeof(ValidatorExtensions);

            var methods =
                from method in extensions.GetMethods()
                let size = GetMethodSize(method)
                where !method.IsVirtual
                where !MethodShouldBeSkippedFromTest(method)
                where size > 32
                orderby size descending, method.Name
                select new
                {
                    Name = String.Format("{0}.{1}", method.DeclaringType.Name, method.Name),
                    Size = size,
                    Definition = BuildMethodDefinition(method)
                };

            if (methods.Count() > 0)
            {
                string message = "Following methods were expected to have a size less than 33 bytes of IL:" +
                    Environment.NewLine;

                foreach (var method in methods)
                {
                    message += String.Format("{0}, size: {1} bytes of IL.    Definition: {2}{3}",
                        method.Name, method.Size, method.Definition, Environment.NewLine);
                }

                Assert.Fail(message);
            }
        }
#endif

        [TestMethod]
        [Description("Checks whether the methods that are overridden from System.Object work as expected.")]
        public void OverriddenMethodsTest()
        {
            Validator<int> validator = 3.Requires();

            validator.ToString();

            validator.GetHashCode();

            validator.GetType();

            validator.Equals(null);
        }

        #region Private Helper Methods

#if !DEBUG
        private static int GetMethodSize(MethodBase method)
        {
            var body = method.GetMethodBody();

            if (body == null)
            {
                return 0;
            }

            return body.GetILAsByteArray().Length;
        }

        private static bool MethodShouldBeSkippedFromTest(ICustomAttributeProvider method)
        {
            var attributes =
                from attribute in method.GetCustomAttributes(true)
                 where attribute.GetType().Name == "MethodTooBigToBeInlinedAttribute"
                 select attribute;

            return attributes.Count() != 0;
        }

        private static string BuildMethodDefinition(MethodInfo method)
        {
            return method.ToString()
                .Replace(method.DeclaringType.Namespace + ".", String.Empty)
                .Replace('[', '<')
                .Replace(']', '>')
                .Replace("`1", String.Empty)
                .Replace("`2", String.Empty);
        }
#endif
        #endregion // Private Helper Methods
    }
}