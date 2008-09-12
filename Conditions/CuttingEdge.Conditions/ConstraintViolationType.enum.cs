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

using System.ComponentModel;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// This enumeration is used to determine the type of exception the validator should throw.
    /// </summary>
    public enum ConstraintViolationType
    {
        /// <summary>Lets the Validator to throw the default exception for that instance.</summary>
        Default = 0,

        /// <summary>
        /// Lets the Validator optionaly throw an exception type appropriate for values that are out of range.
        /// </summary>
        OutOfRangeViolation,

        /// <summary>
        /// Lets the Validator optionaly throw an <see cref="InvalidEnumArgumentException"/>.
        /// </summary>
        InvalidEnumViolation,
    }
}
