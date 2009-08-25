using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    /// <summary>
    /// Validates the SR class and the existence of string resources.
    /// </summary>
    [TestClass]
    public class StringResourcesTests
    {
        private static readonly Type SrType = (
            from conditionType in typeof(Condition).Assembly.GetTypes()
            where conditionType.Name == "SR"
            select conditionType).SingleOrDefault();

        [TestMethod]
        [Description("This test validates whether the defined string consts in the SR class have a value that equals it's name.")]
        public void TestMethod01()
        {
            Assert.IsNotNull(SrType, "The type SR could not be found in the CuttingEdge.Conditions assembly.");

            foreach (var field in GetSrStringFields())
            {
                string resourceKey = (string)field.GetValue(null);

                // The value should be equal to it's name. The C# compiler ensures names are unique, and this
                // way we know for sure that the values are also defined once. This prevents the fields
                // pointing at the wrong resource.
                string assertExplanation = String.Format(CultureInfo.InvariantCulture,
                    "Name of SR.{0} should match it's value", field.Name);

                Assert.AreEqual(field.Name, resourceKey, assertExplanation);
            }
        }

        [TestMethod]
        [Description("This test validates whether the const string fields of the SR class reference an existing string resource.")]
        public void TestMethod02()
        {
            foreach (var field in GetSrStringFields())
            {
                string resourceKey = (string)field.GetValue(null);
                string resourceValue = GetResourceValue(resourceKey);

                string assertExplanation = String.Format(CultureInfo.InvariantCulture,
                    "The resource with key '{0}' could not be found.", resourceKey);

                Assert.IsTrue(!String.IsNullOrEmpty(resourceValue), assertExplanation);
            }
        }

        private static FieldInfo[] GetSrStringFields()
        {
            Assert.IsNotNull(SrType, "The type SR could not be found in the CuttingEdge.Conditions assembly.");

            BindingFlags fieldFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var resourceFields =
                from field in SrType.GetFields(fieldFlags)
                where field.FieldType == typeof(string)
                select field;

            Assert.AreNotEqual(0, resourceFields.Count(), "The fields of SR could not be retrieved.");

            return resourceFields.ToArray();
        }

        private static string GetResourceValue(string resourceKey)
        {
            BindingFlags methodFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            var getStringMethod =
                SrType.GetMethod("GetString", methodFlags, null, new Type[] { typeof(string) }, null);

            Assert.IsNotNull(getStringMethod, "The GetString(string) method could not be found in type SR.");

            return (string)getStringMethod.Invoke(null, new object[] { resourceKey });
        }
    }
}
