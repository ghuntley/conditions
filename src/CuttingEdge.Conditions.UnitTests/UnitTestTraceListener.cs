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

using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    /// <summary>
    /// This trace listener ensures that all failing Debug.Assert and Trace.Assert calls and calls to
    /// Debug.Fail and Trace.Fail are routed to the Assert.Fail call of the Microsoft UnitTesting framework.
    /// </summary>
    public class UnitTestTraceListener : DefaultTraceListener
    {
        /// <summary>
        /// Emits or displays detailed messages and a stack trace for an assertion that always fails.
        /// </summary>
        /// <param name="message">The message to emit or display.</param>
        /// <param name="detailMessage">The detailed message to emit or display.</param>
        public override void Fail(string message, string detailMessage)
        {
            string failMessage = message;

            if (detailMessage != null)
            {
                failMessage += " " + detailMessage;
            }

            Assert.Fail(failMessage);
        }
    }
}
