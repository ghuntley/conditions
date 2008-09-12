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
using System.Collections;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        // Cache the language dependent 'Parameter name' string.
        private static readonly string argumentExceptionParameterName =
            (new ArgumentException(String.Empty, "x")).Message.Replace(": x", String.Empty).Trim();

        #region IsShorterThan

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterThan1()
        {
            string a = "test";
            a.Requires().IsShorterThan(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length = upped bound' should fail.")]
        public void IsShorterThan2()
        {
            string a = "test";
            a.Requires().IsShorterThan(4);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan3()
        {
            string a = String.Empty;
            a.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterThan4()
        {
            string a = String.Empty;
            a.Requires().IsShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsShorterThan on string x with 'null < upped bound' should pass.")]
        public void IsShorterThan5()
        {
            string a = null;
            a.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterThan on string x with 'null = upped bound' should fail.")]
        public void IsShorterThan6()
        {
            string a = null;
            // A null string is considered to have a length of 0.
            a.Requires().IsShorterThan(0);
        }

        #endregion // IsShorterThan

        #region IsShorterOrEqual

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual0()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual1()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual2()
        {
            string a = "test";
            a.Requires().IsShorterOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual3()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual4()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual5()
        {
            string a = String.Empty;
            a.Requires().IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqual6()
        {
            string a = null;
            a.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterOrEqual on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqual7()
        {
            string a = null;
            // A null value will never be found
            a.Requires().IsShorterOrEqual(-1);
        }

        #endregion // IsShorterOrEqual

        #region IsLongerThan

        [TestMethod]
        [Description("Calling IsLongerThan on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerThan1()
        {
            string a = "test";
            a.Requires().IsLongerThan(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerThan2()
        {
            string a = "test";
            a.Requires().IsLongerThan(4);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < x.Length' should pass.")]
        public void IsLongerThan3()
        {
            string a = String.Empty;
            a.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan4()
        {
            string a = String.Empty;
            a.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan on string x with '-1 < null' should pass.")]
        public void IsLongerThan5()
        {
            string a = null;
            a.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerThan on string x with 'lower bound = null' should pass.")]
        public void IsLongerThan6()
        {
            string a = null;
            a.Requires().IsLongerThan(0);
        }

        #endregion // IsLongerThan

        #region IsLongerOrEqual

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerOrEqualTest0()
        {
            string a = "test";
            a.Requires().IsLongerOrEqual(3);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest1()
        {
            string a = "test";
            a.Requires().IsLongerOrEqual(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest2()
        {
            string a = "test";
            a.Requires().IsLongerOrEqual(5);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with '-1 < x.Length' should pass.")]
        public void IsLongerOrEqualTest3()
        {
            string a = String.Empty;
            a.Requires().IsLongerOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = x.Length' should pass.")]
        public void IsLongerOrEqualTest4()
        {
            string a = String.Empty;
            a.Requires().IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > x.Length' should fail.")]
        public void IsLongerOrEqualTest5()
        {
            string a = String.Empty;
            a.Requires().IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound = null' should pass.")]
        public void IsLongerOrEqualTest6()
        {
            string a = null;
            a.Requires().IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerOrEqual on string x with 'lower bound > null' should fail.")]
        public void IsLongerOrEqualTest7()
        {
            string a = null;
            // A null value will never be found
            a.Requires().IsLongerOrEqual(1);
        }

        #endregion // IsLongerOrEqual

        #region HasLength

        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest1()
        {
            string a = "test";
            a.Requires().HasLength(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest2()
        {
            string a = "test";
            a.Requires().HasLength(3);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest3()
        {
            string a = String.Empty;
            a.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest4()
        {
            string a = String.Empty;
            a.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength on string x with 'null = expected length' should pass.")]
        public void HasLengthTest5()
        {
            string a = null;
            // A null value will never be found
            a.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling HasLength on string x with 'null != expected length' should fail.")]
        public void HasLengthTest6()
        {
            string a = null;
            // A null value will never be found
            a.Requires().HasLength(1);
        }

        #endregion // HasLength

        #region DoesNotHaveLength

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest1()
        {
            string a = "test";
            a.Requires().DoesNotHaveLength(4);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest2()
        {
            string a = "test";
            a.Requires().DoesNotHaveLength(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest3()
        {
            string a = String.Empty;
            a.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest4()
        {
            string a = String.Empty;
            a.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotHaveLength on string x with 'null = expected length' should fail.")]
        public void DoesNotHaveLengthTest5()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            a.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest6()
        {
            string a = null;
            // A null value will never be found
            a.Requires().DoesNotHaveLength(1);
        }

        #endregion // DoesNotHaveLength

        #region IsNullOrEmpty

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should fail.")]
        public void IsNullOrEmptyTest1()
        {
            string a = "test";
            a.Requires().IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (\"\") should pass.")]
        public void IsNullOrEmptyTest2()
        {
            string a = String.Empty;
            a.Requires().IsNullOrEmpty();
        }

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string (null) should pass.")]
        public void IsNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            a.Requires().IsNullOrEmpty();
        }

        #endregion // IsNullOrEmpty

        #region IsNotNullOrEmpty

        [TestMethod]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should pass.")]
        public void IsNotNullOrEmptyTest1()
        {
            string a = "test";
            a.Requires().IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNullOrEmpty on string (\"\") should fail.")]
        public void IsNotNullOrEmptyTest2()
        {
            string a = String.Empty;
            a.Requires().IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNullOrEmpty on string (null) should fail.")]
        public void IsNotNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            a.Requires().IsNotNullOrEmpty();
        }

        #endregion // IsNotNullOrEmpty

        #region IsEmpty

        [TestMethod]
        [Description("Calling IsEmpty on string x with 'x == String.Empty' should pass.")]
        public void IsStringEmptyTest1()
        {
            string s = String.Empty;
            s.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest2()
        {
            string s = null;
            s.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest3()
        {
            string s = "test";
            s.Requires().IsEmpty();
        }

        #endregion // IsEmpty

        #region IsNotEmpty

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should fail.")]
        public void IsStringNotEmptyTest1()
        {
            string s = String.Empty;
            s.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest2()
        {
            string s = null;
            s.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest3()
        {
            string s = "test";
            s.Requires().IsNotEmpty();
        }

        #endregion // IsNotEmpty

        #region StartsWith

        [TestMethod]
        [Description("Calling StartsWith on string x with 'x StartsWith x' should pass.")]
        public void StartsWithTest1()
        {
            string a = "test";
            a.Requires().StartsWith(a);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"tes\"' should pass.")]
        public void StartsWithTest2()
        {
            string a = "test";
            a.Requires().StartsWith("tes");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should fail.")]
        public void StartsWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().StartsWith(null);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"\"' should pass.")]
        public void StartsWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().StartsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling StartsWith on string x (null) with 'x StartsWith \"\"' should fail.")]
        public void StartsWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().StartsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should pass.")]
        public void StartsWithTest6()
        {
            string a = null;
            a.Requires().StartsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail.")]
        public void StartsWithTest7()
        {
            string a = "test";
            a.Requires().StartsWith("test me");
        }

        [TestMethod]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail with a correct exception message.")]
        public void StartsWithTest8()
        {
            string expectedMessage =
                "a should start with 'test me'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").StartsWith("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // StartsWith

        #region DoesNotStartWith

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should fail.")]
        public void DoesNotStartWithTest1()
        {
            string a = "test";
            a.Requires().DoesNotStartWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"tes\"' should fail.")]
        public void DoesNotStartWithTest2()
        {
            string a = "test";
            a.Requires().DoesNotStartWith("tes");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith null' should pass.")]
        public void DoesNotStartWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotStartWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"\"' should fail.")]
        public void DoesNotStartWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith \"\"' should pass.")]
        public void DoesNotStartWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotStartWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith null' should fail.")]
        public void DoesNotStartWithTest6()
        {
            string a = null;
            a.Requires().DoesNotStartWith(null);
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test me\"' should pass.")]
        public void DoesNotStartWithTest7()
        {
            string a = "test";
            a.Requires().DoesNotStartWith("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotStartWithTest8()
        {
            string expectedMessage =
                "a should not start with 'test'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotStartWith("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // DoesNotStartWith

        #region Contains

        [TestMethod]
        [Description("Calling Contains on string x with 'x Contains x' should pass.")]
        public void ContainsTest1()
        {
            string a = "test";
            a.Requires().Contains(a);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"es\"' should pass.")]
        public void ContainsTest2()
        {
            string a = "test";
            a.Requires().Contains("es");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should fail.")]
        public void ContainsTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().Contains(null);
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"\"' should pass.")]
        public void ContainsTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().Contains(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on string x (null) with 'x Contains \"\"' should fail.")]
        public void ContainsTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().Contains(String.Empty);
        }

        [TestMethod]
        [Description("Calling Contains on string x (null) with 'x Contains null' should pass.")]
        public void ContainsTest6()
        {
            string a = null;
            a.Requires().Contains(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail.")]
        public void ContainsTest7()
        {
            string a = "test";
            a.Requires().Contains("test me");
        }

        [TestMethod]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail with a correct exception message.")]
        public void ContainsTest8()
        {
            string expectedMessage =
                "a should contain 'test me'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").Contains("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // Contains

        #region DoesNotContain

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should fail.")]
        public void DoesNotContainTest1()
        {
            string a = "test";
            a.Requires().DoesNotContain(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"es\"' should fail.")]
        public void DoesNotContainTest2()
        {
            string a = "test";
            a.Requires().DoesNotContain("es");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain null' should pass.")]
        public void DoesNotContainTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotContain(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"\"' should fail.")]
        public void DoesNotContainTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotContain(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain \"\"' should pass.")]
        public void DoesNotContainTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotContain(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain null' should fail.")]
        public void DoesNotContainTest6()
        {
            string a = null;
            a.Requires().DoesNotContain(null);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test me\"' should pass.")]
        public void DoesNotContainTest7()
        {
            string a = "test";
            a.Requires().DoesNotContain("test me");
        }

        [TestMethod]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test\"' should fail with a correct exception message.")]
        public void DoesNotContainTest8()
        {
            string expectedMessage =
                "a should not contain 'test'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotContain("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // DoesNotContain

        #region EndsWith

        [TestMethod]
        [Description("Calling EndsWith on string x with 'x EndsWith x' should pass.")]
        public void EndsWithTest1()
        {
            string a = "test";
            a.Requires().EndsWith(a);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"est\"' should pass.")]
        public void EndsWithTest2()
        {
            string a = "test";
            a.Requires().EndsWith("est");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith null' should fail.")]
        public void EndsWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().EndsWith(null);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"\"' should pass.")]
        public void EndsWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().EndsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith \"\"' should fail.")]
        public void EndsWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().EndsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith null' should pass.")]
        public void EndsWithTest6()
        {
            string a = null;
            a.Requires().EndsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"me test\"' should fail.")]
        public void EndsWithTest7()
        {
            string a = "test";
            a.Requires().EndsWith("me test");
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"test me\"' should fail with a correct exception message.")]
        public void EndsWithTest8()
        {
            string expectedMessage =
                "a should end with 'test me'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").EndsWith("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // EndsWith

        #region DoesNotEndWith

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should fail.")]
        public void DoesNotEndWithTest1()
        {
            string a = "test";
            a.Requires().DoesNotEndWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"est\"' should fail.")]
        public void DoesNotEndWithTest2()
        {
            string a = "test";
            a.Requires().DoesNotEndWith("est");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith null' should pass.")]
        public void DoesNotEndWithTest3()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotEndWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"\"' should fail.")]
        public void DoesNotEndWithTest4()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith \"\"' should pass.")]
        public void DoesNotEndWithTest5()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith null' should fail.")]
        public void DoesNotEndWithTest6()
        {
            string a = null;
            a.Requires().DoesNotEndWith(null);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"me test\"' should pass.")]
        public void DoesNotEndWithTest7()
        {
            string a = "test";
            a.Requires().DoesNotEndWith("me test");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotEndWithTest8()
        {
            string expectedMessage = 
                "a should not end with 'test'." + Environment.NewLine + argumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotEndWith("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>(expectedMessage, ex.Message);
            }
        }

        #endregion // DoesNotEndWith
    }
}