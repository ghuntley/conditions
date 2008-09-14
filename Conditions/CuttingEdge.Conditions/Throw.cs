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
using System.Globalization;
using System.Linq.Expressions;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// All throw logic is factored out of the public extension methods and put in this helper class. This 
    /// allows more methods to be a candidate for inlining by the JIT compiler.
    /// </summary>
    internal static class Throw
    {
        internal static void ValueShouldNotBeNull<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeNull, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeBetween<T>(Validator<T> validator, T minValue, T maxValue)
        {
            string condition = SR.GetString(SR.ValueShouldBeBetweenXAndY, validator.ArgumentName,
                minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = 
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeEqualTo<T>(Validator<T> validator, T value)
        {
            string condition = SR.GetString(SR.ValueShouldBeEqualToX, validator.ArgumentName, 
                value.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeNull<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.ValueShouldBeNull, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeGreaterThan<T>(Validator<T> validator, T minValue)
        {
            string condition = SR.GetString(SR.ValueShouldBeGreaterThanX, validator.ArgumentName, 
                minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeGreaterThan<T>(Validator<T> validator, T minValue)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeGreaterThanX, validator.ArgumentName,
                minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeGreaterThanOrEqualTo<T>(Validator<T> validator, T minValue)
        {
            string condition = SR.GetString(SR.ValueShouldBeGreaterThanOrEqualToX, validator.ArgumentName,
                minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType type =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, type);
        }

        internal static void ValueShouldNotBeGreaterThanOrEqualTo<T>(Validator<T> validator, T maxValue)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeGreaterThanOrEqualToX, validator.ArgumentName,
                maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType type =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, type);
        }

        internal static void ValueShouldBeSmallerThan<T>(Validator<T> validator, T maxValue)
        {
            string condition = SR.GetString(SR.ValueShouldBeSmallerThanX, validator.ArgumentName,
                maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThan<T>(Validator<T> validator, T minValue)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeSmallerThanX, validator.ArgumentName,
                minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeSmallerThanOrEqualTo<T>(Validator<T> validator, T maxValue)
        {
            string condition = SR.GetString(SR.ValueShouldBeSmallerThanOrEqualToX, validator.ArgumentName,
                maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThanOrEqualTo<T>(Validator<T> validator, T minValue)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeSmallerThanOrEqualToX, validator.ArgumentName,
                minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ExpressionEvaluatedFalse<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.ValueShouldBeValid, validator.ArgumentName);
            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();
            
            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ExpressionEvaluatedFalse<T>(Validator<T> validator, string description)
        {
            string condition = null;

            try
            {
                condition = String.Format(CultureInfo.CurrentCulture, description ?? String.Empty, 
                    validator.ArgumentName);
            }
            catch (FormatException)
            {
                // We catch a FormatException. This code should only throw exceptions generated by the
                // validator.BuildException method. Throwing another exception would confuse the user and
                // would make debugging harder. When the user supplied an unformattable description, we simply
                // use the unformatted description as condition.
                condition = description;
            }

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void LambdaXShouldHoldForValue<T>(Validator<T> validator, LambdaExpression lambda)
        {
            string condition = SR.GetString(SR.LambdaXShouldHoldForValue, validator.ArgumentName, 
                lambda.Body.ToString());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeNullOrAnEmptyString(Validator<string> validator)
        {
            string condition = SR.GetString(SR.StringShouldBeNullOrEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeAnEmptyString(Validator<string> validator)
        {
            string condition = SR.GetString(SR.StringShouldBeEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeAnEmptyString(Validator<string> validator)
        {
            string condition = SR.GetString(SR.StringShouldNotBeEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeNullOrAnEmptyString(Validator<string> validator)
        {
            string condition = SR.GetString(SR.StringShouldNotBeNullOrEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeUnequalTo<T>(Validator<T> validator, T value)
        {
            string condition = SR.GetString(SR.ValueShouldBeUnequalToX, validator.ArgumentName,
                value.Stringify());

            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, violationType);
        }

        internal static void ValueShouldNotBeBetween<T>(Validator<T> validator, T minValue, T maxValue)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeBetweenXAndY, validator.ArgumentName,
                minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void StringShouldHaveLength(Validator<string> validator, int length)
        {
            string condition;

            if (length == 1)
            {
                condition = SR.GetString(SR.StringShouldBe1CharacterLong, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.StringShouldBeXCharactersLong, validator.ArgumentName, length);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldNotHaveLength(Validator<string> validator, int length)
        {
            string condition;

            if (length == 1)
            {
                condition = SR.GetString(SR.StringShouldNotBe1CharacterLong, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.StringShouldNotBeXCharactersLong, validator.ArgumentName, length);
            }

            throw validator.BuildException(condition);
        }

        internal static void StringShouldBeLongerThan(Validator<string> validator, int minLength)
        {
            string condition;

            if (minLength == 1)
            {
                condition = SR.GetString(SR.StringShouldBeLongerThan1Character, validator.ArgumentName);
            }
            else
            {
                condition = 
                    SR.GetString(SR.StringShouldBeLongerThanXCharacters, validator.ArgumentName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterThan(Validator<string> validator, int maxLength)
        {
            string condition;

            if (maxLength == 1)
            {
                condition = SR.GetString(SR.StringShouldBeShorterThan1Character, validator.ArgumentName);
            }
            else
            {
                condition = 
                    SR.GetString(SR.StringShouldBeShorterThanXCharacters, validator.ArgumentName, maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterOrEqualTo(Validator<string> validator, int maxLength)
        {
            string condition;

            if (maxLength == 1)
            {
                condition = SR.GetString(SR.StringShouldBeShorterOrEqualTo1Character, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.StringShouldBeShorterOrEqualToXCharacters, validator.ArgumentName, 
                    maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeLongerOrEqualTo(Validator<string> validator, int minLength)
        {
            string condition;

            if (minLength == 1)
            {
                condition = SR.GetString(SR.StringShouldBeLongerOrEqualTo1Character, validator.ArgumentName);             
            }
            else
            {
                condition = SR.GetString(SR.StringShouldBeLongerOrEqualToXCharacters,
                     validator.ArgumentName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldContain(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldContainX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotContain(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldNotContainX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotEndWith(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldNotEndWithX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotStartWith(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldNotStartWithX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldEndWith(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldEndWithX, validator.ArgumentName, 
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldStartWith(Validator<string> validator, string value)
        {
            string condition = SR.GetString(SR.StringShouldStartWithX, validator.ArgumentName, 
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeOfType<T>(Validator<T> validator, Type type)
        {
            string condition = SR.GetString(SR.ValueShouldBeOfTypeX, validator.ArgumentName, type.Name);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeOfType<T>(Validator<T> validator, Type type)
        {
            string condition = SR.GetString(SR.ValueShouldNotBeOfTypeX, validator.ArgumentName, type.Name);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeTrue<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.ValueShouldBeTrue, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeFalse<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.ValueShouldBeFalse, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldBeEmpty<T>(Validator<T> validator)
        {
            string condition = SR.GetString(SR.CollectionShouldBeEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotBeEmpty<T>(Validator<T> validator) where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldNotBeEmpty, validator.ArgumentName);
            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContain<T>(Validator<T> validator, object value) 
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldContainX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContain<T>(Validator<T> validator, object value)
        {
            string condition = SR.GetString(SR.CollectionShouldNotContainX, validator.ArgumentName,
                value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainAtLeastOneOf<T>(Validator<T> validator, 
            IEnumerable values)
        {
            string condition = SR.GetString(SR.CollectionShouldContainAtLeastOneOfX, validator.ArgumentName,
                values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContainAnyOf<T>(Validator<T> validator, IEnumerable values)
        {
            string condition = SR.GetString(SR.CollectionShouldNotContainAnyOfX, validator.ArgumentName,
                values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainAllOf<T>(Validator<T> validator, IEnumerable values)
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldContainAllOfX, validator.ArgumentName,
                values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContainAllOf<T>(Validator<T> validator, IEnumerable values)
        {
            string condition = SR.GetString(SR.CollectionShouldNotContainAllOfX, validator.ArgumentName,
                values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContain<T>(Validator<T> validator, int numberOfElements)
            where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = SR.GetString(SR.CollectionShouldContain1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldContainXElements, validator.ArgumentName,
                     numberOfElements);
            }
            
            throw validator.BuildException(condition, GetCollectionContainsElementsMessage(validator));
        }

        internal static void CollectionShouldNotContain<T>(Validator<T> validator, int numberOfElements)
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = SR.GetString(SR.CollectionShouldNotContain1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldNotContainXElements, validator.ArgumentName,
                     numberOfElements);
            }

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainLessThan<T>(Validator<T> validator, int numberOfElements)
            where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = SR.GetString(SR.CollectionShouldContainLessThan1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldContainLessThanXElements,
                    validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessThan<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = 
                    SR.GetString(SR.CollectionShouldNotContainLessThan1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldNotContainLessThanXElements, 
                    validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainLessOrEqual<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldContainXOrLessElements, validator.ArgumentName, 
                numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessOrEqual<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldNotContainXOrLessElements, 
                validator.ArgumentName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreThan<T>(Validator<T> validator, int numberOfElements)
            where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = SR.GetString(SR.CollectionShouldContainMoreThan1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldContainMoreThanXElements, validator.ArgumentName, 
                    numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreThan<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition =
                    SR.GetString(SR.CollectionShouldNotContainMoreThan1Element, validator.ArgumentName);
            }
            else
            {
                condition = SR.GetString(SR.CollectionShouldNotContainMoreThanXElements,
                     validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreOrEqual<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldContainXOrMoreElements, validator.ArgumentName,
                numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreOrEqual<T>(Validator<T> validator, 
            int numberOfElements)
            where T : IEnumerable
        {
            string condition = SR.GetString(SR.CollectionShouldNotContainXOrMoreElements, 
                validator.ArgumentName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        // This method returns extra information about the value of the validator.
        private static string GetActualValueMessage<T>(Validator<T> validator)
        {
            object value = validator.Value;

            // When the ToString method of the given type isn't overloaded, it returns the Type.FullName.
            // This information isn't very usefull to the user, so in that case, we'll simply return null,
            // meaning: no extra information.
            if (value == null || (value != null && value.GetType().FullName != value.ToString()))
            {
                return SR.GetString(SR.TheActualValueIsX, validator.ArgumentName, validator.Value.Stringify());
            }

            return null;
        }

        private static string GetActualStringLengthMessage(Validator<string> validator)
        {
            int length = validator.Value != null ? validator.Value.Length : 0;

            if (length == 1)
            {
                return SR.GetString(SR.TheActualValueIs1CharacterLong, validator.ArgumentName);
            }
            else
            {
                return SR.GetString(SR.TheActualValueIsXCharactersLong, validator.ArgumentName, length);
            }
        }

        private static string GetCollectionContainsElementsMessage<T>(Validator<T> validator)
            where T : IEnumerable
        {
            if (validator.Value == null)
            {
                return SR.GetString(SR.CollectionIsCurrentlyANullReference, validator.ArgumentName);
            }
            else
            {
                int numberOfElements = GetNumberOfElements(validator.Value);

                if (numberOfElements == 1)
                {
                    return SR.GetString(SR.CollectionContainsCurrently1Element, validator.ArgumentName);
                }
                else
                {
                    return SR.GetString(SR.CollectionContainsCurrentlyXElements, validator.ArgumentName,
                       numberOfElements);
                }
            }
        }

        // Returns the number of elements in the sequence.
        private static int GetNumberOfElements(IEnumerable sequence)
        {
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count;
            }

            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int count = 0;
                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        // Returns the 'InvalidEnumViolation' when the T is an Enum and otherwise 'Default'.
        private static ConstraintViolationType GetEnumViolationOrDefault<T>()
        {
            return GetEnumViolationOrDefault<T>(ConstraintViolationType.Default);
        }

        // Returns the 'InvalidEnumViolation' when the T is an Enum and otherwise the specified defaultValue.
        private static ConstraintViolationType GetEnumViolationOrDefault<T>(
            ConstraintViolationType defaultValue)
        {
            if (typeof(T).IsEnum)
            {
                return ConstraintViolationType.InvalidEnumViolation;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}