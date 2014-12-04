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
