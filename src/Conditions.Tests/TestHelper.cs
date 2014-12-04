using System;

namespace Conditions.Tests
{
    /// <summary>
    /// Helper class for testing.
    /// </summary>
    public static class TestHelper
    {
        // Cache the language dependent 'Parameter name' string.
        // This enables all unit tests to succeed, even when run on different languages of the .NET FX.
        public static readonly string CultureSensitiveArgumentExceptionParameterText =
            GetCultureSensitiveArgumentExceptionParameterText();

        private static string GetCultureSensitiveArgumentExceptionParameterText()
        {
            ArgumentException exception = new ArgumentException(string.Empty, "p");

            string exceptionPart = exception.Message.Replace(": p", string.Empty);

            string cultureSensitiveParameterText = exceptionPart.Trim();

            return cultureSensitiveParameterText;
        }
    }
}