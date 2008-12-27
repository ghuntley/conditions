using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuttingEdge.Conditions.UnitTests
{
    /// <summary>
    /// This class defines the same extension methods as CuttingEdge.Conditions.Condition and the methods
    /// in this class are routed to the CuttingEdge.Conditions.Condition class. Because this class is in the
    /// same namespace as the unit tests, the unit tests use these methods instead of the real entry point
    /// methods. This allows some one to remove the 'this' property from the methods in the Condition class
    /// and thereby remove Requires and Ensures as extension methods. This is useful especially in VB.NET 
    /// projects where extension methods don't work on parameters of type System.Object. This forces all users
    /// to use 'Condition.Requires() instead.
    /// </summary>
    internal static class EntryPointExtensionMethodsReplacer
    {
        internal static Validator<T> Requires<T>(this T value)
        {
            return CuttingEdge.Conditions.Condition.Requires<T>(value);
        }

        internal static Validator<T> Requires<T>(this T value, string argumentName)
        {
            return CuttingEdge.Conditions.Condition.Requires<T>(value, argumentName);
        }

        internal static Validator<T> Ensures<T>(this T value)
        {
            return CuttingEdge.Conditions.Condition.Ensures<T>(value);
        }

        internal static Validator<T> Ensures<T>(this T value, string argumentName)
        {
            return CuttingEdge.Conditions.Condition.Ensures<T>(value, argumentName);
        }

        internal static Validator<T> Ensures<T>(this T value, string argumentName, string additionalMessage)
        {
            return CuttingEdge.Conditions.Condition.Ensures<T>(value, argumentName, additionalMessage);
        }
    }
}
