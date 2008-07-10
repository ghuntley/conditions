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
using System.Globalization;

namespace CuttingEdge.Conditions
{
    // The EnsuresValidator can be used for postcondition checks.
    internal sealed class EnsuresValidator<T> : Validator<T>
    {
        private readonly string message;

        internal EnsuresValidator(string argumentName, T value)
            : base(argumentName, value)
        {
        }

        internal EnsuresValidator(string argumentName, T value, string message)
            : base(argumentName, value)
        {
            this.message = message;
        }

        internal override Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            string message;

            if (!String.IsNullOrEmpty(additionalMessage))
            {
                message =
                    String.Format(CultureInfo.InvariantCulture, "Postcondition '{0}' failed. {1}", condition,
                    additionalMessage);
            }
            else
            {
                message =
                    String.Format(CultureInfo.InvariantCulture, "Postcondition '{0}' failed.", condition);
            }

            if (!String.IsNullOrEmpty(this.message))
            {
                message += " " + this.message;
            }

            return new PostconditionException(message);
        }
    }
}
