using System;

namespace Conditions
{
    /// <summary>
    /// The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    /// <typeparam name="TException">The exception type to throw in case of a failure.</typeparam>
    internal sealed class RequiresWithCustomExceptionValidator<T, TException> : RequiresValidator<T>
        where TException : Exception
    {
        internal RequiresWithCustomExceptionValidator(string argumentName, T value)
            : base(argumentName, value)
        {
        }

        internal override Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type,
            string message)
        {
            var constructor = AlternativeExceptionHelper<TException>.Constructor;

            return (Exception) constructor.Invoke(new object[] {message});
        }
    }
}