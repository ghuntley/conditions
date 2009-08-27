#region Copyright (c) 2008 S. van Deursen
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
#endregion

using System;
using System.ComponentModel;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    internal sealed class RequiresValidator<T> : ConditionValidator<T>
    {
        internal RequiresValidator(string argumentName, T value) : base(argumentName, value)
        {
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

        private Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type, string message)
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

        private string BuildInvalidEnumArgumentExceptionMessage(string message)
        {
            ArgumentException argumentException = new ArgumentException(message, this.ArgumentName);

            // Returns the message formatted according to the current culture.
            // Note that the 'Parameter name' part of the message is culture sensitive.
            return argumentException.Message;
        }
    }
}
