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
using System.Reflection;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The OtherwiseValidator can be used for postcondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    /// <typeparam name="TUncheckedException">The type of exception to be thrown when the validation fails.
    /// </typeparam>
    internal sealed class OtherwiseValidator<T, TUncheckedException> : ConditionValidator<T>
        where TUncheckedException : Exception
    {
        private static readonly ConstructorInfo uncheckedExceptionConstructor;

        private readonly ConditionValidator<T> baseValidator;

        /// <summary>Initializes static members of the OtherwiseValidator class.</summary>
        static OtherwiseValidator()
        {
            // A TypeInitializationException must be thrown when the given TUncheckedException doesn't have
            // a ctor(string). For this reason this static constructor can not be removed.
            uncheckedExceptionConstructor = GetUncheckedExceptionConstructor();
        }

        // Initializes a new instance of the <see cref="EnsuresValidator{T}"/> class.
        internal OtherwiseValidator(ConditionValidator<T> validator)
            : base(validator.ArgumentName, validator.Value)
        {
            this.baseValidator = validator;
        }

        /// <summary>
        /// Builds an exception and message, that has to be thrown.
        /// </summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be 
        /// null".</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        /// <returns>A newly created <see cref="Exception"/>.</returns>
        public override Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            // We let the baseValidator generate the message. This way the exception message is determined by 
            // the supplied base validator.
            Exception exception = this.baseValidator.BuildException(condition, additionalMessage, type);

            return CreateException(exception.Message);
        }

        private static ConstructorInfo GetUncheckedExceptionConstructor()
        {
            Type uncheckedExceptionType = typeof(TUncheckedException);

            ConstructorInfo constructor =
                uncheckedExceptionType.GetConstructor(new[] { typeof(string) });

            // When the TUncheckedException lacks a ctor(string) or is an abstract type, the 
            // TUncheckedException is invalid and we will throw an exception.
            if (constructor == null || uncheckedExceptionType.IsAbstract)
            {
                string messsage =
                    SR.GetString(SR.OtherwiseSpecifiedTypeXIsNotSupported, uncheckedExceptionType);

                // Because this exception is thrown in the context of an cctor, it will be wrapped in an
                // TypeInitializationException.
                throw new NotSupportedException(messsage);
            }

            return constructor;
        }

        // Creates a new TUncheckedException instance with the supplied message.
        private static Exception CreateException(string message)
        {
            return (Exception)uncheckedExceptionConstructor.Invoke(new object[] { message });
        }
    }
}
