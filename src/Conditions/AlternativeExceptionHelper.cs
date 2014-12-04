using System;
using System.Linq;
using System.Reflection;

namespace Conditions
{
    /// <summary>
    /// Internal helper class to cache a <see cref="AlternativeExceptionCondition"/> and 
    /// <see cref="ConstructorInfo"/> instance per exception type.
    /// </summary>
    /// <typeparam name="TException">The type of the exception.</typeparam>
    internal static class AlternativeExceptionHelper<TException> where TException : Exception
    {
        internal static readonly AlternativeExceptionCondition Condition = BuildCondition();
        internal static readonly ConstructorInfo Constructor = FindConstructor();
        private static AlternativeExceptionCondition BuildCondition()
        {
            bool isValidType = FindConstructor() != null;

            return isValidType ? new AlternativeExceptionConditionInternal() : null;
        }

        private static ConstructorInfo FindConstructor()
        {
            if (typeof (TException).GetTypeInfo().IsAbstract)
            {
                return null;
            }

            //return typeof(TException).GetConstructor(new[] { typeof(string) });
            return typeof (TException).GetTypeInfo().DeclaredConstructors.First();
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