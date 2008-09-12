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
using System.Globalization;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The EnsuresValidator can be used for postcondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    internal sealed class EnsuresValidator<T> : Validator<T>
    {
        private readonly string additionalMessage;

        internal EnsuresValidator(string argumentName, T value)
            : base(argumentName, value)
        {
        }

        internal EnsuresValidator(string argumentName, T value, string additionalMessage)
            : base(argumentName, value)
        {
            this.additionalMessage = additionalMessage;
        }

        /// <summary>
        /// Builds an exception and message, that has to be thrown.
        /// </summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be 
        /// null".</param>
        /// <param name="additionalMessage">An aditional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        /// <returns>A newly created <see cref="Exception"/>.</returns>
        public override Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            // Build up an exception message: "Postcondition '[condition]' failed.".
            string exceptionMessage = SR.GetString(SR.PostconditionXFailed, condition);

            if (!String.IsNullOrEmpty(additionalMessage))
            {
                // The library can supply some additional information about the value of the validated
                // argument. This message will be appended to the exception message.
                exceptionMessage += " " + additionalMessage;
            }

            if (!String.IsNullOrEmpty(this.additionalMessage))
            {
                // The user can also add an additional message using one of the Ensures() method overloads.
                // If the user supplied such a message, it will be appended to the exception message.
                exceptionMessage += " " + this.additionalMessage;
            }

            return new PostconditionException(exceptionMessage);
        }
    }
}
