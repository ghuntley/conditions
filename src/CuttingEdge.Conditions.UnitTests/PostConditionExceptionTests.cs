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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    [TestClass]
    public sealed class PostConditionExceptionTests
    {
        [TestMethod]
        [Description("Checks whether the postcondition exception is serializable")]
        public void PostConditionExceptionTest01()
        {
            try
            {
                throw new PostconditionException(String.Empty);
            }
            catch (PostconditionException pex)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    // Serialize the array elements.
                    formatter.Serialize(stream, pex);

                    byte[] bytes = stream.ToArray();

                    using (MemoryStream stream2 = new MemoryStream(bytes))
                    {
                        PostconditionException pex2 = (PostconditionException)formatter.Deserialize(stream2);

                        Assert.IsNotNull(pex2);
                    }
                } 
            }
        }

        [TestMethod]
        [Description("Checks whether the default constructor of the PostconditionException constructs the expected exception message.")]
        public void PostConditionExceptionTest02()
        {
            try
            {
                throw new PostconditionException();
            }
            catch (PostconditionException pex)
            {
                Assert.AreEqual("Postcondition failed.", pex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(PostconditionException))]
        [Description("Okay, I admit: This test is simply to get 100% code coverage :-). This method should fail.")]
        public void PostConditionExceptionTest03()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new PostconditionException(String.Empty, ex);
            }
        }
    }
}
