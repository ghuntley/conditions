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

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    /// <typeparam name="TException">The exception type to throw in case of a failure.</typeparam>
    internal sealed class RequiresWithCustomExceptionValidator<T, TException> : RequiresValidator<T>
        where TException : Exception
    {
        internal RequiresWithCustomExceptionValidator(string argumentName, T value)
            : base(argumentName, value)
        {
        }

        internal override Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type,
            string message)
        {
            var constructor = AlternativeExceptionHelper<TException>.Constructor;

            return (Exception)constructor.Invoke(new object[] { message });
        }
    }
}