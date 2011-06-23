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
using System.ComponentModel;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    internal class RequiresValidator<T> : ConditionValidator<T>
    {
        internal RequiresValidator(string argumentName, T value) : base(argumentName, value)
        {
        }

        internal virtual Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type, 
            string message)
        {
            switch (type)
            {
                case ConstraintViolationType.OutOfRangeViolation:
                    return new ArgumentOutOfRangeException(this.ArgumentName, message);

                case ConstraintViolationType.InvalidEnumViolation:
                    string enumMessage = this.BuildInvalidEnumArgumentExceptionMessage(message);
                    return new InvalidEnumArgumentException(enumMessage);

                default:
                    if (this.Value != null)
                    {
                        return new ArgumentException(message, this.ArgumentName);
                    }
                    else
                    {
                        return new ArgumentNullException(this.ArgumentName, message);
                    }
            }
        }

        /// <summary>Throws an exception.</summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be
        /// null".</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        protected override void ThrowExceptionCore(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            string message = BuildExceptionMessage(condition, additionalMessage);

            Exception exceptionToThrow = this.BuildExceptionBasedOnViolationType(type, message);

            throw exceptionToThrow;
        }

        private static string BuildExceptionMessage(string condition, string additionalMessage)
        {
            if (!String.IsNullOrEmpty(additionalMessage))
            {
                return condition + ". " + additionalMessage;
            }
            else
            {
                return condition + ".";
            }
        }

        private string BuildInvalidEnumArgumentExceptionMessage(string message)
        {
            ArgumentException argumentException = new ArgumentException(message, this.ArgumentName);

            // Returns the message formatted according to the current culture.
            // Note that the 'Parameter name' part of the message is culture sensitive.
            return argumentException.Message;
        }
    }
}
