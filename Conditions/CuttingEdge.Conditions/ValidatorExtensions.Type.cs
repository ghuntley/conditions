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
    // Type checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsOfType<T>(this ConditionValidator<T> validator, Type type)
            where T : class
        {
            return IsOfType(validator, type, null);
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsOfType<T>(this ConditionValidator<T> validator, Type type,
            string conditionDescription) where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no
            // significant effect.
            T value = validator.Value;

            bool valueIsValid = value != null && type.IsAssignableFrom(value.GetType());

            if (!valueIsValid)
            {
                Throw.ValueShouldBeOfType(validator, type, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is not of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsNotOfType<T>(this ConditionValidator<T> validator, Type type)
            where T : class
        {
            return IsNotOfType(validator, type, null);
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is not of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// When the given value is a null reference, the check will always pass, regardless of the specified
        /// <paramref name="type"/>. Please use the <b>IsNotNull</b> method to check for null references).
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>      
        public static ConditionValidator<T> IsNotOfType<T>(this ConditionValidator<T> validator, Type type,
            string conditionDescription) where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no 
            // significant effect.
            T value = validator.Value;

            if (value != null)
            {
                bool valueIsInvalid = type.IsAssignableFrom(value.GetType());

                if (valueIsInvalid)
                {
                    Throw.ValueShouldNotBeOfType(validator, type, conditionDescription);
                }
            }

            return validator;
        }
    }
}