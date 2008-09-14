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
using System.Globalization;
using System.Resources;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// String Resource helper class
    /// </summary>
    internal static class SR
    {
        internal const string OtherwiseSpecifiedTypeXIsNotSupported = "OtherwiseSpecifiedTypeXIsNotSupported";

        internal const string CollectionContainsCurrently1Element = "CollectionContainsCurrently1Element";
        internal const string CollectionContainsCurrentlyXElements = "CollectionContainsCurrentlyXElements";
        internal const string CollectionIsCurrentlyANullReference = "CollectionIsCurrentlyANullReference";
        
        internal const string CollectionShouldBeEmpty = "CollectionShouldBeEmpty";
        internal const string CollectionShouldContainAllOfX = "CollectionShouldContainAllOfX";
        internal const string CollectionShouldContainAtLeastOneOfX = "CollectionShouldContainAtLeastOneOfX";
        internal const string CollectionShouldContainLessThan1Element = "CollectionShouldContainLessThan1Element";
        internal const string CollectionShouldContainLessThanXElements = "CollectionShouldContainLessThanXElements";

        internal const string CollectionShouldContainMoreThan1Element = "CollectionShouldContainMoreThan1Element";
        internal const string CollectionShouldContainMoreThanXElements = "CollectionShouldContainMoreThanXElements";
        internal const string CollectionShouldContainX = "CollectionShouldContainX";
        internal const string CollectionShouldContain1Element = "CollectionShouldContain1Element";
        internal const string CollectionShouldContainXElements = "CollectionShouldContainXElements";
        internal const string CollectionShouldContainXOrLessElements = "CollectionShouldContainXOrLessElements";
        internal const string CollectionShouldContainXOrMoreElements = "CollectionShouldContainXOrMoreElements";
        internal const string CollectionShouldNotBeEmpty = "CollectionShouldNotBeEmpty";
        internal const string CollectionShouldNotContainAllOfX = "CollectionShouldNotContainAllOfX";
        internal const string CollectionShouldNotContainAnyOfX = "CollectionShouldNotContainAnyOfX";
        internal const string CollectionShouldNotContainLessThan1Element = "CollectionShouldNotContainLessThan1Element";
        internal const string CollectionShouldNotContainLessThanXElements = "CollectionShouldNotContainLessThanXElements";
        internal const string CollectionShouldNotContainMoreThan1Element = "CollectionShouldNotContainMoreThan1Element";
        internal const string CollectionShouldNotContainMoreThanXElements = "CollectionShouldNotContainMoreThanXElements";
        internal const string CollectionShouldNotContainX = "CollectionShouldNotContainX";
        internal const string CollectionShouldNotContain1Element = "CollectionShouldNotContain1Element";
        internal const string CollectionShouldNotContainXElements = "CollectionShouldNotContainXElements";
        internal const string CollectionShouldNotContainXOrLessElements = "CollectionShouldNotContainXOrLessElements";
        internal const string CollectionShouldNotContainXOrMoreElements = "CollectionShouldNotContainXOrMoreElements";
        
        internal const string LambdaXShouldHoldForValue = "LambdaXShouldHoldForValue";

        internal const string PostconditionFailed = "PostconditionFailed";
        internal const string PostconditionXFailed = "PostconditionXFailed";

        internal const string StringShouldBeEmpty = "StringShouldBeEmpty";
        internal const string StringShouldBeLongerOrEqualTo1Character = "StringShouldBeLongerOrEqualTo1Character";
        internal const string StringShouldBeLongerOrEqualToXCharacters = "StringShouldBeLongerOrEqualToXCharacters";
        internal const string StringShouldBeLongerThan1Character = "StringShouldBeLongerThan1Character";
        internal const string StringShouldBeLongerThanXCharacters = "StringShouldBeLongerThanXCharacters";
        internal const string StringShouldBeNullOrEmpty = "StringShouldBeNullOrEmpty";
        internal const string StringShouldBeShorterOrEqualTo1Character = "StringShouldBeShorterOrEqualTo1Character";
        internal const string StringShouldBeShorterOrEqualToXCharacters = "StringShouldBeShorterOrEqualToXCharacters";
        internal const string StringShouldBeShorterThan1Character = "StringShouldBeShorterThan1Character";
        internal const string StringShouldBeShorterThanXCharacters = "StringShouldBeShorterThanXCharacters";
        internal const string StringShouldBe1CharacterLong = "StringShouldBe1CharacterLong";
        internal const string StringShouldBeXCharactersLong = "StringShouldBeXCharactersLong";
        internal const string StringShouldContainX = "StringShouldContainX";
        internal const string StringShouldEndWithX = "StringShouldEndWithX";
        internal const string StringShouldNotBeEmpty = "StringShouldNotBeEmpty";
        internal const string StringShouldNotBeNullOrEmpty = "StringShouldNotBeNullOrEmpty";
        internal const string StringShouldNotBe1CharacterLong = "StringShouldNotBe1CharacterLong";
        internal const string StringShouldNotBeXCharactersLong = "StringShouldNotBeXCharactersLong";
        internal const string StringShouldNotContainX = "StringShouldNotContainX";
        internal const string StringShouldNotEndWithX = "StringShouldNotEndWithX";
        internal const string StringShouldNotStartWithX = "StringShouldNotStartWithX";
        internal const string StringShouldStartWithX = "StringShouldStartWithX";

        internal const string TheActualValueIsX = "TheActualValueIsX";
        internal const string TheActualValueIs1CharacterLong = "TheActualValueIs1CharacterLong";
        internal const string TheActualValueIsXCharactersLong = "TheActualValueIsXCharactersLong";

        internal const string ValueShouldBeBetweenXAndY = "ValueShouldBeBetweenXAndY";
        internal const string ValueShouldBeEqualToX = "ValueShouldBeEqualToX";
        internal const string ValueShouldBeFalse = "ValueShouldBeFalse";
        internal const string ValueShouldBeGreaterThanOrEqualToX = "ValueShouldBeGreaterThanOrEqualToX";
        internal const string ValueShouldBeGreaterThanX = "ValueShouldBeGreaterThanX";
        internal const string ValueShouldBeNull = "ValueShouldBeNull";
        internal const string ValueShouldBeOfTypeX = "ValueShouldBeOfTypeX";
        internal const string ValueShouldBeSmallerThanOrEqualToX = "ValueShouldBeSmallerThanOrEqualToX";
        internal const string ValueShouldBeSmallerThanX = "ValueShouldBeSmallerThanX";
        internal const string ValueShouldBeTrue = "ValueShouldBeTrue";
        internal const string ValueShouldBeUnequalToX = "ValueShouldBeUnequalToX";
        internal const string ValueShouldBeValid = "ValueShouldBeValid";
        internal const string ValueShouldNotBeBetweenXAndY = "ValueShouldNotBeBetweenXAndY";
        internal const string ValueShouldNotBeGreaterThanOrEqualToX = "ValueShouldNotBeGreaterThanOrEqualToX";
        internal const string ValueShouldNotBeGreaterThanX = "ValueShouldNotBeGreaterThanX";
        internal const string ValueShouldNotBeSmallerThanOrEqualToX = "ValueShouldNotBeSmallerThanOrEqualToX";
        internal const string ValueShouldNotBeSmallerThanX = "ValueShouldNotBeSmallerThanX";
        internal const string ValueShouldNotBeNull = "ValueShouldNotBeNull";
        internal const string ValueShouldNotBeOfTypeX = "ValueShouldNotBeOfTypeX";

        private static readonly ResourceManager resource =
            new ResourceManager(typeof(SR).Namespace + ".ExceptionMessages", typeof(SR).Assembly);

        // Returns a string from the resource.
        internal static string GetString(string name)
        {
            return GetString(name, null);
        }

        // Returns a string from the resource and formats it with the given args in a culture-specific way.
        internal static string GetString(string name, params object[] args)
        {
            string format = resource.GetString(name, CultureInfo.CurrentUICulture);

            if (args == null)
            {
                return format;
            }

            return string.Format(CultureInfo.CurrentCulture, format, args);
        }
    }
}
