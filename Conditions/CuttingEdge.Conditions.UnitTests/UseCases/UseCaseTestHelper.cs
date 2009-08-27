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
