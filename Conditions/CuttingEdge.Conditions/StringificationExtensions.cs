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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// An internal helper class with extension methods for converting an object to a string representation.
    /// </summary>
    internal static class StringificationExtensions
    {
        private const int MaximumNumberOfRecursiveCalls = 10;

        /// <summary>
        /// Transforms an object into a string representation that can be used to represent it's value in an
        /// exception message. When the value is a null reference, the string "null" will be returned, when 
        /// the specified value is a string or a char, it will be surrounded with single quotes.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <returns>A string representation of the supplied <paramref name="value"/>.</returns>
        internal static string Stringify(this object value)
        {
            try
            {
                return StringifyInternal(value, MaximumNumberOfRecursiveCalls);
            }
            catch (InvalidOperationException)
            {
                // Stack overflow prevented. We can not build a string representation of the supplied object.
                // We return the default representation of the object.
                Debug.Assert(value != null, "value should not be null when InvalidOperation is thrown.");
                return value.ToString();
            }
        }

        private static string StringifyInternal(object value, int maximumNumberOfRecursiveCalls)
        {
            if (value == null)
            {
                return "null";
            }

            if (maximumNumberOfRecursiveCalls < 0)
            {
                // Prevent stack overflow exceptions.
                throw new InvalidOperationException();
            }

            if (value is string || value is char)
            {
                return "'" + value + "'";
            }

            IEnumerable collection = value as IEnumerable;

            if (collection != null)
            {
                return StringifyCollection(collection, maximumNumberOfRecursiveCalls);
            }
            else
            {
                return value.ToString();
            }
        }

        private static string StringifyCollection(IEnumerable collection, int maximumNumberOfRecursiveCalls)
        {
            Debug.Assert(collection != null, "collection should not be null");

            List<string> stringifiedElements = new List<string>();

            foreach (object o in collection)
            {
                // Recursive call to StringifyInternal.
                string stringifiedElement = StringifyInternal(o, maximumNumberOfRecursiveCalls - 1);

                stringifiedElements.Add(stringifiedElement);
            }

            return "{" + String.Join(",", stringifiedElements.ToArray()) + "}";
        }
    }
}