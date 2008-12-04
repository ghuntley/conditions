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
using System.ComponentModel;
using System.Linq.Expressions;

namespace CuttingEdge.Conditions
{
    // Checks on evaluations
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the specified <paramref name="expression"/> evaluates <b>true</b> on the given value.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>
        /// This method will display a string representation of the specified <paramref name="expression"/>.
        /// Although it can threrefore give a lot of useful information in the exception message, it the
        /// <paramref name="expression"/> has to be <see cref="Expression{T}.Compile">compiled</see> on each
        /// call. Try using the other <see cref="ValidatorExtensions.Evaluate{T}(Validator{T}, Boolean)"/>
        /// overload in performance sensitive parts of your program.
        /// </remarks>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">
        /// The <see cref="Validator{T}"/> that holds the value that has to be checked.
        /// </param>
        /// <param name="expression">
        /// The <see cref="Expression{T}"/> that will be compiled to an <see cref="Func{T, TResult}"/> and 
        /// executed. When the expression is a null reference (Nothing in VB) it is considered to evaluate
        /// <b>false</b>.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="expression"/> evaluated false or is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="expression"/> evaluated false or is a null reference and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="expression"/> evaluated false or is a null reference and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum"/> type, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <paramref name="expression"/> evaluated false or is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> Evaluate<T>(this Validator<T> validator,
            Expression<Func<T, bool>> expression)
        {
            bool valueIsValid = false;

            // We don't want to throw an ArgumentException when the expression is null, we'll just considered
            // it to be invalid.
            if (expression != null)
            {
                Func<T, bool> func = expression.Compile();

                valueIsValid = func(validator.Value);
            }

            if (!valueIsValid)
            {
                Throw.LambdaXShouldHoldForValue(validator, expression);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the specified <paramref name="condition"/> equals <b>true</b>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="condition"><b>true</b> to prevent an <see cref="Exception"/> from being thrown; otherwise, false.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="condition"/> equals false, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="condition"/> equals false and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="condition"/> equals false and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum"/> type, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <paramref name="condition"/> equals false, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> Evaluate<T>(this Validator<T> validator, bool condition)
        {
            if (!condition)
            {
                Throw.ExpressionEvaluatedFalse(validator);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the specified <paramref name="condition"/> equals <b>true</b>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="condition"><b>true</b> to prevent an <see cref="Exception"/> from being thrown; otherwise, false.</param>
        /// <param name="conditionDescription">Describes the condition that should hold. i.e.: 'value should 
        /// be valid'. When the description contains a {0} marker, that marker will be replaced with the actual
        /// name of the parameter.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="condition"/> equals false, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="condition"/> equals false and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="InvalidEnumArgumentException">Thrown when the <paramref name="condition"/> equals false and the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is an <see cref="System.Enum"/> type, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <paramref name="condition"/> equals false, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<T> Evaluate<T>(this Validator<T> validator, bool condition, 
            string conditionDescription)
        {
            if (!condition)
            {
                Throw.ExpressionEvaluatedFalse(validator, conditionDescription);
            }

            return validator;
        }
    }
}