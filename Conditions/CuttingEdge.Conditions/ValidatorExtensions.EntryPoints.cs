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

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Extension methods for <see cref="Validator{T}"/>.
    /// </summary>
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// preconditions of the given argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and <paramref name="argumentName"/>.</returns>
        public static Validator<T> Requires<T>(this T value)
        {
            return new RequiresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// preconditions of the given argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and <paramref name="argumentName"/>.</returns>
        public static Validator<T> Requires<T>(this T value, string argumentName)
        {
            return new RequiresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the given 
        /// argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and <paramref name="argumentName"/>.</returns>
        public static Validator<T> Ensures<T>(this T value)
        {
            return new EnsuresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/> 
        /// and <paramref name="argumentName"/>.</returns>
        public static Validator<T> Ensures<T>(this T value, string argumentName)
        {
            return new EnsuresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <param name="message">A message that will be appended to generated exception message.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/> 
        /// and <paramref name="argumentName"/>.</returns>
        public static Validator<T> Ensures<T>(this T value, string argumentName, string message)
        {
            return new EnsuresValidator<T>(argumentName, value, message);
        }
    }
}