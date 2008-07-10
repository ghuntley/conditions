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
using System.Collections;
using System.Collections.Generic;

namespace CuttingEdge.Conditions
{
    // An internal helper class with extension methods for converting an object to a string representation.
    internal static class StringificationExtensions
    {
        // Transforms an object into it's string representation. When the value is a null reference, the 
        // string "null" will be returned, when the specified value is a string or a char, it will be 
        // surrounded with single quotes.
        internal static string Stringify(this object value)
        {
            if (value == null)
            {
                return "null";
            }

            if (value is string || value is char)
            {
                return "'" + value.ToString() + "'";
            }

            return value.ToString();
        }

        // Transforms an collection into string showing the elements of the collection.
        internal static string Stringify(this IEnumerable collection)
        {
            if (collection == null)
            {
                return "null";
            }

            List<string> elements = new List<string>();

            foreach (object o in collection)
            {
                elements.Add(Stringify(o));
            }

            return "{" + String.Join(",", elements.ToArray()) + "}";
        }
    }
}