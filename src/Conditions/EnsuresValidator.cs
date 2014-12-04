using System;

namespace Conditions
{
    /// <summary>
    /// The EnsuresValidator can be used for postcondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    internal sealed class EnsuresValidator<T> : ConditionValidator<T>
    {
        internal EnsuresValidator(string argumentName, T value) : base(argumentName, value)
        {
        }

        /// <summary>Throws an exception.</summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be
        /// null".</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        protected override void ThrowExceptionCore(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            // Build up an exception message: "Postcondition '[condition]' failed.".
            string exceptionMessage = SR.GetString(SR.PostconditionXFailed, condition);

            if (!String.IsNullOrEmpty(additionalMessage))
            {
                // The library can supply some additional information about the value of the validated
                // argument. This message will be appended to the exception message.
                exceptionMessage += " " + additionalMessage;
            }

            throw new PostconditionException(exceptionMessage);
        }
    }
}