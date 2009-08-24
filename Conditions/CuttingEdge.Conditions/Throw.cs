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
        internal static void ValueShouldNotBeNull<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeNull,
                conditionDescription, validator.ArgumentName);
                
            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeBetween<T>(ConditionValidator<T> validator, T minValue, T maxValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeBetweenXAndY,
                conditionDescription, validator.ArgumentName, minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = 
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeEqualTo<T>(ConditionValidator<T> validator, T value, 
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeEqualToX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeNull<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeNull,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeGreaterThan<T>(ConditionValidator<T> validator, T minValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeGreaterThanX,
                conditionDescription, validator.ArgumentName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeGreaterThan<T>(ConditionValidator<T> validator, T minValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeGreaterThanX,
                conditionDescription, validator.ArgumentName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeGreaterThanOrEqualTo<T>(ConditionValidator<T> validator, T minValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeGreaterThanOrEqualToX,
               conditionDescription, validator.ArgumentName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType type =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, type);
        }

        internal static void ValueShouldNotBeGreaterThanOrEqualTo<T>(ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeGreaterThanOrEqualToX,
               conditionDescription, validator.ArgumentName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType type =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, type);
        }

        internal static void ValueShouldBeSmallerThan<T>(ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeSmallerThanX,
               conditionDescription, validator.ArgumentName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThan<T>(ConditionValidator<T> validator, T minValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeSmallerThanX,
               conditionDescription, validator.ArgumentName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldBeSmallerThanOrEqualTo<T>(ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeSmallerThanOrEqualToX,
               conditionDescription, validator.ArgumentName, maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ValueShouldNotBeSmallerThanOrEqualTo<T>(ConditionValidator<T> validator, T minValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeSmallerThanOrEqualToX,
               conditionDescription, validator.ArgumentName, minValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType =
                GetEnumViolationOrDefault<T>(ConstraintViolationType.OutOfRangeViolation);

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void ExpressionEvaluatedFalse<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeValid,
                conditionDescription, validator.ArgumentName);

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void LambdaXShouldHoldForValue<T>(ConditionValidator<T> validator, LambdaExpression lambda,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.LambdaXShouldHoldForValue,
                conditionDescription, validator.ArgumentName, lambda.Body.ToString());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }
        
        internal static void ValueShouldBeNullOrAnEmptyString(ConditionValidator<string> validator,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldBeNullOrEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeAnEmptyString(ConditionValidator<string> validator, 
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldBeEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeAnEmptyString(ConditionValidator<string> validator,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldNotBeEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeNullOrAnEmptyString(ConditionValidator<string> validator,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldNotBeNullOrEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeUnequalTo<T>(ConditionValidator<T> validator, T value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeUnequalToX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, violationType);
        }

        internal static void ValueShouldNotBeBetween<T>(ConditionValidator<T> validator, T minValue, T maxValue,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeBetweenXAndY,
                conditionDescription, validator.ArgumentName, minValue.Stringify(), maxValue.Stringify());

            string additionalMessage = GetActualValueMessage(validator);
            ConstraintViolationType violationType = GetEnumViolationOrDefault<T>();

            throw validator.BuildException(condition, additionalMessage, violationType);
        }

        internal static void StringShouldHaveLength(ConditionValidator<string> validator, int length,
            string conditionDescription)
        {
            string condition;

            if (length == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBe1CharacterLong,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBeXCharactersLong,
                    conditionDescription, validator.ArgumentName, length);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldNotHaveLength(ConditionValidator<string> validator, int length,
            string conditionDescription)
        {
            string condition;

            if (length == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldNotBe1CharacterLong,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldNotBeXCharactersLong,
                    conditionDescription, validator.ArgumentName, length);
            }

            throw validator.BuildException(condition);
        }

        internal static void StringShouldBeLongerThan(ConditionValidator<string> validator, int minLength,
            string conditionDescription)
        {
            string condition;

            if (minLength == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBeLongerThan1Character,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBeLongerThanXCharacters,
                    conditionDescription, validator.ArgumentName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterThan(ConditionValidator<string> validator, int maxLength,
            string conditionDescription)
        {
            string condition;

            if (maxLength == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBeShorterThan1Character,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.StringShouldBeShorterThanXCharacters,
                    conditionDescription, validator.ArgumentName, maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeShorterOrEqualTo(ConditionValidator<string> validator, int maxLength,
            string conditionDescription)
        {
            string condition;

            if (maxLength == 1)
            {
                condition = 
                    GetFormattedConditionMessage(validator, SR.StringShouldBeShorterOrEqualTo1Character,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = 
                    GetFormattedConditionMessage(validator, SR.StringShouldBeShorterOrEqualToXCharacters,
                    conditionDescription, validator.ArgumentName, maxLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldBeLongerOrEqualTo(ConditionValidator<string> validator, int minLength,
            string conditionDescription)
        {
            string condition;

            if (minLength == 1)
            {
                condition =
                    GetFormattedConditionMessage(validator, SR.StringShouldBeLongerOrEqualTo1Character,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition =
                    GetFormattedConditionMessage(validator, SR.StringShouldBeLongerOrEqualToXCharacters,
                    conditionDescription, validator.ArgumentName, minLength);
            }

            string additionalMessage = GetActualStringLengthMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void StringShouldContain(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldContainX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotContain(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldNotContainX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotEndWith(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldNotEndWithX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldNotStartWith(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldNotStartWithX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldEndWith(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldEndWithX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void StringShouldStartWith(ConditionValidator<string> validator, string value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.StringShouldStartWithX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeOfType<T>(ConditionValidator<T> validator, Type type,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeOfTypeX,
                conditionDescription, validator.ArgumentName, type.Name);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldNotBeOfType<T>(ConditionValidator<T> validator, Type type,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldNotBeOfTypeX,
                conditionDescription, validator.ArgumentName, type.Name);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeTrue<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeTrue,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void ValueShouldBeFalse<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.ValueShouldBeFalse,
                conditionDescription, validator.ArgumentName);
            
            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldBeEmpty<T>(ConditionValidator<T> validator, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldBeEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotBeEmpty<T>(ConditionValidator<T> validator,
            string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotBeEmpty,
                conditionDescription, validator.ArgumentName);

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContain<T>(ConditionValidator<T> validator, object value,
            string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContain<T>(ConditionValidator<T> validator, object value,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainX,
                conditionDescription, validator.ArgumentName, value.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainAtLeastOneOf<T>(ConditionValidator<T> validator,
            IEnumerable values, string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainAtLeastOneOfX,
                conditionDescription, validator.ArgumentName, values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContainAnyOf<T>(ConditionValidator<T> validator, IEnumerable values,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainAnyOfX,
               conditionDescription, validator.ArgumentName, values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainAllOf<T>(ConditionValidator<T> validator, IEnumerable values,
            string conditionDescription) where T : IEnumerable
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainAllOfX,
               conditionDescription, validator.ArgumentName, values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldNotContainAllOf<T>(ConditionValidator<T> validator, IEnumerable values,
            string conditionDescription)
        {
            string condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainAllOfX,
               conditionDescription, validator.ArgumentName, values.Stringify());

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainNumberOfElements<T>(ConditionValidator<T> validator, 
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContain1Element,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainXElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);
            }
            
            throw validator.BuildException(condition, GetCollectionContainsElementsMessage(validator));
        }

        internal static void CollectionShouldNotContainNumberOfElements<T>(ConditionValidator<T> validator, 
            int numberOfElements, string conditionDescription)
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotContain1Element,
                   conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainXElements,
                   conditionDescription, validator.ArgumentName, numberOfElements);
            }

            throw validator.BuildException(condition);
        }

        internal static void CollectionShouldContainLessThan<T>(ConditionValidator<T> validator, int numberOfElements,
            string conditionDescription) where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainLessThan1Element,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainLessThanXElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessThan<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = 
                    GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainLessThan1Element,
                        conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = 
                    GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainLessThanXElements,
                        conditionDescription, validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainLessOrEqual<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition =
                GetFormattedConditionMessage(validator, SR.CollectionShouldContainXOrLessElements, 
                conditionDescription, validator.ArgumentName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainLessOrEqual<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition =
               GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainXOrLessElements,
               conditionDescription, validator.ArgumentName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreThan<T>(ConditionValidator<T> validator, int numberOfElements,
            string conditionDescription) where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainMoreThan1Element,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition = GetFormattedConditionMessage(validator, SR.CollectionShouldContainMoreThanXElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreThan<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition;

            if (numberOfElements == 1)
            {
                condition = 
                    GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainMoreThan1Element,
                    conditionDescription, validator.ArgumentName);
            }
            else
            {
                condition =
                    GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainMoreThanXElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);
            }

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldContainMoreOrEqual<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition = 
                GetFormattedConditionMessage(validator, SR.CollectionShouldContainXOrMoreElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);
            
            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        internal static void CollectionShouldNotContainMoreOrEqual<T>(ConditionValidator<T> validator,
            int numberOfElements, string conditionDescription) where T : IEnumerable
        {
            string condition =
                GetFormattedConditionMessage(validator, SR.CollectionShouldNotContainXOrMoreElements,
                    conditionDescription, validator.ArgumentName, numberOfElements);

            string additionalMessage = GetCollectionContainsElementsMessage(validator);

            throw validator.BuildException(condition, additionalMessage);
        }

        // This method returns extra information about the value of the validator.
        private static string GetActualValueMessage<T>(ConditionValidator<T> validator)
        {
            object value = validator.Value;

            // When the ToString method of the given type isn't overloaded, it returns the Type.FullName.
            // This information isn't very useful to the user, so in that case, we'll simply return null,
            // meaning: no extra information.
            if (value == null || value.GetType().FullName != value.ToString())
            {
                return SR.GetString(SR.TheActualValueIsX, validator.ArgumentName, validator.Value.Stringify());
            }

            return null;
        }

        private static string GetActualStringLengthMessage(ConditionValidator<string> validator)
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

        private static string GetCollectionContainsElementsMessage<T>(ConditionValidator<T> validator)
            where T : IEnumerable
        {
            IEnumerable collection = validator.Value;

            if (collection == null)
            {
                return SR.GetString(SR.CollectionIsCurrentlyANullReference, validator.ArgumentName);
            }
            else
            {
                int numberOfElements = CollectionHelpers.GetLength(collection);

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

        private static string GetFormattedConditionMessage<T>(ConditionValidator<T> validator, string resourceKey,
            string conditionDescription, params object[] resourceFormatArguments)
        {
            if (conditionDescription != null)
            {
                return FormatConditionDescription(validator, conditionDescription);
            }
            else
            {
                return SR.GetString(resourceKey, resourceFormatArguments);
            }
        }

        private static string FormatConditionDescription<T>(ConditionValidator<T> validator, 
            string conditionDescription)
        {
            try
            {
                return String.Format(CultureInfo.CurrentCulture, conditionDescription ?? String.Empty,
                    validator.ArgumentName);
            }
            catch (FormatException)
            {
                // We catch a FormatException. This code should only throw exceptions generated by the
                // validator.BuildException method. Throwing another exception would confuse the user and
                // would make debugging harder. When the user supplied an unformattable description, we simply
                // use the unformatted description as condition.
                return conditionDescription;
            }
        }
    }
}