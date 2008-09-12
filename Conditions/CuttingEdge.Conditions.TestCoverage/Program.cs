using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using CuttingEdge.Conditions.UnitTests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.TestCoverage
{
    // This simple program calls in to the CuttingEdge.Conditions.UnitTests.
    // We use this simple program to determine the test coverage percentage, with a coverage tool
    // (like http://www.ncover.com/)
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(ValidatorExtensionTests).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(TestClassAttribute), true).Length > 0
                select t;

            // Loop through all types in the assembly that are decorated with the [TestClass] attribute.
            foreach (Type unitTestClass in unitTestClasses)
            {
                ProcessUnitTestClass(unitTestClass);
            }

            Console.WriteLine("Done");
        }

        private static void ProcessUnitTestClass(Type testClass)
        {
            Console.WriteLine();
            Console.WriteLine("Invoking all [TestMethod] methods on {0}:", testClass.Name);

            IEnumerable<MethodInfo> testClassMethods =
                from m in testClass.GetMethods()
                where m.IsPublic && !m.IsStatic && m.GetParameters().Length == 0
                where m.GetCustomAttributes(typeof(TestMethodAttribute), true).Length > 0
                select m;

            object testClassInstance = Activator.CreateInstance(testClass);

            // Loop through all methods in the type that are decorated with the [TestMethod] attribute.
            foreach (MethodInfo method in testClassMethods)
            {
                ProcessUnitTestMethod(testClassInstance, method);
            }
        }

        private static void ProcessUnitTestMethod(object testClassInstance, MethodInfo method)
        {
            try
            {
                Console.WriteLine("Invoking {0}", method.Name);
                method.Invoke(testClassInstance, null);
            }
            catch
            {
            }
        }
    }
}
