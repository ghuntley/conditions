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
using System.Reflection;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Internal helper class to cache a <see cref="AlternativeExceptionCondition"/> and 
    /// <see cref="ConstructorInfo"/> instance per exception type.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    internal static class AlternativeExceptionHelper<TException> where TException : Exception
    {
        internal static readonly ConstructorInfo Constructor = FindConstructor();

        internal static readonly AlternativeExceptionCondition Condition = BuildCondition();

        private static ConstructorInfo FindConstructor()
        {
            if (typeof(TException).IsAbstract)
            {
                return null;
            }

            return typeof(TException).GetConstructor(new[] { typeof(string) });
        }

        private static AlternativeExceptionCondition BuildCondition()
        {
            bool isValidType = FindConstructor() != null;

            return isValidType ? new AlternativeExceptionConditionInternal() : null;
        }

        /// <summary>Allows creating validators for a specific exception type.</summary>
        private sealed class AlternativeExceptionConditionInternal : AlternativeExceptionCondition
        {
            /// <summary>
            /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to
            /// validate the preconditions of the given argument, given it a default ArgumentName of 'value'.
            /// </summary>
            /// <typeparam name="T">The type of the argument to validate.</typeparam>
            /// <param name="value">The value of the argument to validate.</param>
            /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
            /// <paramref name="value"/> and "value" as argument name.</returns>
            public override ConditionValidator<T> Requires<T>(T value)
            {
                return new RequiresWithCustomExceptionValidator<T, TException>("value", value);
            }

            /// <summary>
            /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to
            /// validate the preconditions of the given argument.
            /// </summary>
            /// <typeparam name="T">The type of the argument to validate.</typeparam>
            /// <param name="value">The value of the argument to validate.</param>
            /// <param name="argumentName">The name of the argument to validate</param>
            /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
            /// <paramref name="value"/> and "value" as argument name.</returns>
            public override ConditionValidator<T> Requires<T>(T value, string argumentName)
            {
                return new RequiresWithCustomExceptionValidator<T, TException>(argumentName, value);
            }
        }
    }
}