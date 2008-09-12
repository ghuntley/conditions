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

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsTrue

        [TestMethod]
        [Description("Calling IsTrue on Boolean x with 'x == true' should pass.")]
        public void IsTrueTest1()
        {
            bool b = true;
            b.Requires().IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean x with 'x == false' should fail.")]
        public void IsTrueTest2()
        {
            bool b = false;
            b.Requires().IsTrue();
        }

        [TestMethod]
        [Description("Calling IsTrue on Boolean? x with 'x == true' should pass.")]
        public void IsTrueTest3()
        {
            bool? b = true;
            b.Requires().IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsTrue on Boolean? x with 'x == false' should fail.")]
        public void IsTrueTest4()
        {
            bool? b = false;
            b.Requires().IsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsTrue on Boolean? x with 'x == null' should fail.")]
        public void IsTrueTest5()
        {
            bool? b = null;
            b.Requires().IsTrue();
        }

        #endregion // IsTrue

        #region IsFalse

        [TestMethod]
        [Description("Calling IsFalse on Boolean x with 'x == false' should pass.")]
        public void IsFalseTest1()
        {
            bool b = false;
            b.Requires().IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean x with 'x == true' should fail.")]
        public void IsFalseTest2()
        {
            bool b = true;
            b.Requires().IsFalse();
        }

        [TestMethod]
        [Description("Calling IsFalse on Boolean? x with 'x == false' should pass.")]
        public void IsFalseTest3()
        {
            bool? b = false;
            b.Requires().IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsFalse on Boolean? x with 'x == true' should fail.")]
        public void IsFalseTest4()
        {
            bool? b = true;
            b.Requires().IsFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsFalse on Boolean? x with 'x == null' should fail.")]
        public void IsFalseTest5()
        {
            bool? b = null;
            b.Requires().IsFalse();
        }

        #endregion // IsFalse
    }
}
