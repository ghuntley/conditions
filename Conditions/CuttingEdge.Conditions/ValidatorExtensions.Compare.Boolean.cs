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
    // Comparable checks for Boolean
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value is <b>true</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool> IsTrue(this Validator<bool> validator)
        {
            if (!validator.Value)
            {
                Throw.ValueShouldBeTrue(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>true</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool> IsTrue(this Validator<bool> validator, string conditionDescription)
        {
            if (!validator.Value)
            {
                Throw.ValueShouldBeTrue(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>true</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool?> IsTrue(this Validator<bool?> validator)
        {
            if (!(validator.Value == true))
            {
                Throw.ValueShouldBeTrue(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>true</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>false</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool?> IsTrue(this Validator<bool?> validator, string conditionDescription)
        {
            if (!(validator.Value == true))
            {
                Throw.ValueShouldBeTrue(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>false</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool> IsFalse(this Validator<bool> validator)
        {
            if (validator.Value)
            {
                Throw.ValueShouldBeFalse(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>false</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool> IsFalse(this Validator<bool> validator, string conditionDescription)
        {
            if (validator.Value)
            {
                Throw.ValueShouldBeFalse(validator, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>false</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool?> IsFalse(this Validator<bool?> validator)
        {
            if (!(validator.Value == false))
            {
                Throw.ValueShouldBeFalse(validator, null);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is <b>false</b>. An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="Validator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is <b>true</b> or null, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<bool?> IsFalse(this Validator<bool?> validator, string conditionDescription)
        {
            if (!(validator.Value == false))
            {
                Throw.ValueShouldBeFalse(validator, conditionDescription);
            }

            return validator;
        }
    }
}