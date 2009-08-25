using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.UseCases
{
    internal static class UseCaseTestHelper
    {
        public static void Test(Action useCase, Action conditions)
        {
            Condition.Requires(useCase, "useCase").IsNotNull();
            Condition.Requires(conditions, "conditions").IsNotNull();

            Exception useCaseException = ReturnExceptionOrNull(useCase);
            Exception conditionsException = ReturnExceptionOrNull(conditions);

            AssertWhenTypesDiffer(useCaseException, conditionsException);
        }

        private static void AssertWhenTypesDiffer(Exception useCaseException, Exception conditionsException)
        {
            if (useCaseException == null && conditionsException == null)
            {
                return;
            }

            if (useCaseException != null && conditionsException != null)
            {
                if (useCaseException.GetType() == conditionsException.GetType())
                {
                    return;
                }
                
                Assert.Fail(string.Format("Both cases throw a different type of exception. " +
                    "The use case threw a {0} and conditions threw a {1}.", useCaseException.GetType().Name,
                    conditionsException.GetType().Name));
            }

            if (useCaseException == null)
            {
                Assert.Fail("The use case action didn't throw an exception, while the conditions action did.");
            }
            else
            {
                Assert.Fail("The use case action threw an exception, while the conditions action didn't.");
            }
        }

        private static Exception ReturnExceptionOrNull(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                return ex;
            }

            return null;
        }
    }
}
