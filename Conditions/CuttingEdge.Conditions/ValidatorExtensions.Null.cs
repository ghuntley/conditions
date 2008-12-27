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

namespace CuttingEdge.Conditions
{
    // Null checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value is null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNull<T>(this Validator<T> validator)
            where T : class
        {
            if (validator.Value != null)
            {
                Throw.ValueShouldBeNull(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNull<T>(this Validator<T> validator, string conditionDescription)
            where T : class
        {
            if (validator.Value != null)
            {
                Throw.ValueShouldBeNull(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNull<T>(this Validator<Nullable<T>> validator)
            where T : struct
        {
            if (validator.Value.HasValue)
            {
                Throw.ValueShouldBeNull(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNull<T>(this Validator<Nullable<T>> validator, 
            string conditionDescription)
            where T : struct
        {
            if (validator.Value.HasValue)
            {
                Throw.ValueShouldBeNull(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotNull<T>(this Validator<T> validator) where T : class
        {
            if (validator.Value == null)
            {
                Throw.ValueShouldNotBeNull(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> IsNotNull<T>(this Validator<T> validator, string conditionDescription) 
            where T : class
        {
            if (validator.Value == null)
            {
                Throw.ValueShouldNotBeNull(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotNull<T>(this Validator<Nullable<T>> validator)
            where T : struct
        {
            if (!validator.Value.HasValue)
            {
                Throw.ValueShouldNotBeNull(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<Nullable<T>> IsNotNull<T>(this Validator<Nullable<T>> validator, 
            string conditionDescription)
            where T : struct
        {
            if (!validator.Value.HasValue)
            {
                Throw.ValueShouldNotBeNull(validator, conditionDescription);
            }

            return validator;
        }
    }
}