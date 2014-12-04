using System;

namespace Conditions
{
    // Null checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value is null. An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsNull<T>(this ConditionValidator<T> validator)
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsNull<T>(this ConditionValidator<T> validator, string conditionDescription)
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<Nullable<T>> IsNull<T>(this ConditionValidator<Nullable<T>> validator)
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<Nullable<T>> IsNull<T>(this ConditionValidator<Nullable<T>> validator,
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsNotNull<T>(this ConditionValidator<T> validator) where T : class
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<T> IsNotNull<T>(this ConditionValidator<T> validator,
            string conditionDescription)
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<Nullable<T>> IsNotNull<T>(this ConditionValidator<Nullable<T>> validator)
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
        /// <typeparam name="T">The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="conditionDescription">
        /// The description of the condition that should hold. The string may hold the placeholder '{0}' for 
        /// the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the specified <paramref name="validator"/> is null, while the specified <paramref name="validator"/> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static ConditionValidator<Nullable<T>> IsNotNull<T>(this ConditionValidator<Nullable<T>> validator,
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