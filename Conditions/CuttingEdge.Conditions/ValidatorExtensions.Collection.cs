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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CuttingEdge.Conditions
{
    // Collection checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value contains no elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considerd empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not empty, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsEmpty<TCollection>(this Validator<TCollection> validator)
            where TCollection : IEnumerable
        {
            // We consider null equal to empty.
            if (!CollectionHelpers.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldBeEmpty(validator);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does contain elements. An exception is thrown otherwise. When the 
        /// value is a null reference it is considerd empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is empty, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotEmpty<TCollection>(this Validator<TCollection> validator)
            where TCollection : IEnumerable
        {
            // We consider null equal to empty.
            if (CollectionHelpers.IsSequenceNullOrEmpty(validator.Value))
            {
                Throw.CollectionShouldNotBeEmpty(validator);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considerd empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection, TElement>(
            this Validator<TCollection> validator, TElement element)
            where TCollection : IEnumerable<TElement>
        {
            if (validator.Value == null || !CollectionHelpers.Contains<TElement>(validator.Value, element))
            {
                Throw.CollectionShouldContain(validator, element);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains the specified <paramref name="element"/>. An exception is 
        /// thrown otherwise. When the value is a null reference it is considerd empty and therefore won't 
        /// contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> Contains<TCollection>(this Validator<TCollection> validator,
            object element)
            where TCollection : IEnumerable
        {
            if (validator.Value == null || !CollectionHelpers.Contains(validator.Value, element))
            {
                Throw.CollectionShouldContain(validator, element);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considerd empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection, TElement>(
            this Validator<TCollection> validator, TElement element)
            where TCollection : IEnumerable<TElement>
        {
            if (validator.Value != null && Enumerable.Contains(validator.Value, element))
            {
                Throw.CollectionShouldNotContain(validator, element);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contain the specified <paramref name="element"/>. An 
        /// exception is thrown otherwise. When the value is a null reference it is considerd empty and 
        /// therefore won't contain <paramref name="element"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain <paramref name="element"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContain<TCollection>(
            this Validator<TCollection> validator, object element)
            where TCollection : IEnumerable
        {
            if (validator.Value != null && CollectionHelpers.Contains(validator.Value, element))
            {
                Throw.CollectionShouldNotContain(validator, element);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection, TElement>(
            this Validator<TCollection> validator, IEnumerable<TElement> elements)
            where TCollection : IEnumerable<TElement>
        {
            if (!CollectionHelpers.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains any of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the value is a null reference or an empty list it won't 
        /// contain any <paramref name="elements"/>. When the <paramref name="elements"/> list is null or 
        /// empty the collection is considered to not contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain any element of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAny<TCollection>(this Validator<TCollection> validator,
            IEnumerable elements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldContainAtLeastOneOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection, TElement>(
            this Validator<TCollection> validator, IEnumerable<TElement> elements)
            where TCollection : IEnumerable<TElement>
        {
            if (CollectionHelpers.ContainsAny<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does nott contains any of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise.
        /// When the value is a null reference or an empty list it won't contain any <paramref name="elements"/>.
        /// When the <paramref name="elements"/> list is null or empty the collection is considered to not 
        /// contain any element.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain one or more elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAny<TCollection>(
            this Validator<TCollection> validator, IEnumerable elements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.ContainsAny(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAnyOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection, TElement>(
            this Validator<TCollection> validator, IEnumerable<TElement> elements)
            where TCollection : IEnumerable<TElement>
        {
            if (!CollectionHelpers.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value contains all of the specified <paramref name="elements"/>. An 
        /// exception is thrown otherwise. When the <paramref name="elements"/> collection is a null reference 
        /// or an empty list, the collection is considered to contain all of the specified (even if the value 
        /// itself is empty). When the given value is empty and the given <paramref name="elements"/> list 
        /// isn't, the collection is considered to not contain all of the specified <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> ContainsAll<TCollection>(this Validator<TCollection> validator,
            IEnumerable elements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldContainAllOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the specified <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection, TElement>(
            this Validator<TCollection> validator, IEnumerable<TElement> elements)
            where TCollection : IEnumerable<TElement>
        {
            if (CollectionHelpers.ContainsAll<TElement>(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value does not contains all of the specified <paramref name="elements"/>.
        /// An exception is thrown otherwise. When the <paramref name="elements"/> collection is a null 
        /// reference or an empty list, the collection is considered to contain all of the specified (even if 
        /// the value itself is empty). When the given value is empty and the given <paramref name="elements"/>
        /// list isn't, the collection is considered to not contain all of the specified 
        /// <paramref name="elements"/>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="elements">The list of elements.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the specified <paramref name="elements"/> list is null or empty, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain all of the elements of the given <paramref name="elements"/> list, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotContainAll<TCollection>(
            this Validator<TCollection> validator, IEnumerable elements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.ContainsAll(validator.Value, elements))
            {
                Throw.CollectionShouldNotContainAllOf(validator, elements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value has the number of elements as specified by 
        /// <paramref name="numberOfElements"/>. An exception is thrown otherwise. When the value is a null 
        /// reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should contain.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference, while <paramref name="numberOfElements"/> is bigger than 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does not contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> HasLength<TCollection>(this Validator<TCollection> validator,
            int numberOfElements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContain(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is different from the specified 
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is 
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The number of elements the collection should not contain.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> equals 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> does contain the number of elements as specified with the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> DoesNotHaveLength<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.SequenceHasLength(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContain(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsShorterThan<TCollection>(this Validator<TCollection> validator, 
            int numberOfElements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessThan(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotShorterThan<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.SequenceIsShorterThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessThan(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is less than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is lass than 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsShorterOrEqual<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainLessOrEqual(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not less than and not equals to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotShorterOrEqual<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.SequenceIsShorterOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainLessOrEqual(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerThan<TCollection>(this Validator<TCollection> validator,
            int numberOfElements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreThan(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller than 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more elements than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerThan<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.SequenceIsLongerThan(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreThan(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is more than or equal to the specified
        /// <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the value is
        /// a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is greater than 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains less than specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsLongerOrEqual<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (!CollectionHelpers.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldContainMoreOrEqual(validator, numberOfElements);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the number of elements in the given value, is not more than and not equal to the 
        /// specified <paramref name="numberOfElements"/> argument. An exception is thrown otherwise. When the
        /// value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the value to check.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="numberOfElements">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is a null reference and the <paramref name="numberOfElements"/> is smaller or equal to 0, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> contains more or the same amount of elements as specified by the <paramref name="numberOfElements"/> argument, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<TCollection> IsNotLongerOrEqual<TCollection>(
            this Validator<TCollection> validator, int numberOfElements)
            where TCollection : IEnumerable
        {
            if (CollectionHelpers.SequenceIsLongerOrEqual(validator.Value, numberOfElements))
            {
                Throw.CollectionShouldNotContainMoreOrEqual(validator, numberOfElements);
            }

            return validator;
        }
    }
}