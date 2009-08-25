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

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareBooleanTests
    {
        #region IsTrue

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' should pass.")]
        public void IsTrueTest1()
        {
            bool b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean x with 'x == false' should fail.")]
        public void IsTrueTest2()
        {
            bool b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' should pass.")]
        public void IsTrueTest3()
        {
            bool? b = true;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean? x with 'x == false' should fail.")]
        public void IsTrueTest4()
        {
            bool? b = false;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsTrue on Boolean? x with 'x == null' should fail.")]
        public void IsTrueTest5()
        {
            bool? b = null;
            Condition.Requires(b).IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' and conditionDescription should pass.")]
        public void IsTrueTest6()
        {
            bool b = true;
            Condition.Requires(b).IsTrue(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' and conditionDescription should pass.")]
        public void IsTrueTest7()
        {
            bool? b = true;
            Condition.Requires(b).IsTrue(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsTrue on Boolean should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsTrueTest8()
        {
            bool b = false;
            try
            {
                Condition.Requires(b, "b").IsTrue("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling a failing IsTrue on Boolean? should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsTrueTest9()
        {
            bool? b = false;
            try
            {
                Condition.Requires(b, "b").IsTrue("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        #endregion // IsTrue

        #region IsFalse

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' should pass.")]
        public void IsFalseTest1()
        {
            bool b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean x with 'x == true' should fail.")]
        public void IsFalseTest2()
        {
            bool b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' should pass.")]
        public void IsFalseTest3()
        {
            bool? b = false;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean? x with 'x == true' should fail.")]
        public void IsFalseTest4()
        {
            bool? b = true;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsFalse on Boolean? x with 'x == null' should fail.")]
        public void IsFalseTest5()
        {
            bool? b = null;
            Condition.Requires(b).IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' and conditionDescription should pass.")]
        public void IsFalseTest6()
        {
            bool b = false;
            Condition.Requires(b).IsFalse(string.Empty);
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' and conditionDescription should pass.")]
        public void IsFalseTest7()
        {
            bool? b = false;
            Condition.Requires(b).IsFalse(string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsFalse on Boolean should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsFalseTest8()
        {
            bool b = true;
            try
            {
                Condition.Requires(b, "b").IsFalse("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        [TestMethod]
        [Description("Calling a failing IsFalse on Boolean? should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsFalseTest9()
        {
            bool? b = true;
            try
            {
                Condition.Requires(b, "b").IsFalse("qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe b xyz"));
            }
        }

        #endregion // IsFalse
    }
}
