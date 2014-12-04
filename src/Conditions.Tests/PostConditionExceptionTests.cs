using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests
{
    [TestClass]
    public sealed class PostConditionExceptionTests
    {
        [TestMethod]
        [Description(
            "Checks whether the default constructor of the PostconditionException constructs the expected exception message."
            )]
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
        [ExpectedException(typeof (PostconditionException))]
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