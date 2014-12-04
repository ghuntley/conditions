using System.Collections.Generic;
using System.Linq;

namespace Conditions.Tests
{
    internal static class ExtendabilityExtensions
    {
        /// <summary>Returns a stub ConditionValidator that will never throw an exception.</summary>
        /// <typeparam name="T">The supplied type.</typeparam>
        /// <param name="validator">The validator.</param>
        /// <returns>A new <see cref="ConditionValidator{T}"/></returns>
        public static ConditionValidator<T> SuppressExceptionsForTest<T>(this ConditionValidator<T> validator)
        {
            return new StubConditionValidator<T>(validator);
        }

        public static ConditionValidator<T> MyExtension<T>(
            this ConditionValidator<T> validator, IEnumerable<T> collection)
        {
            if (collection == null || !collection.Contains(validator.Value))
            {
                validator.ThrowException(validator.ArgumentName + " should be in the supplied collection");
            }

            return validator;
        }

        // This stub validator allows testing code branches that could not be reached with the normal
        // RequiresValidator and EnsuresValidator.
        private sealed class StubConditionValidator<T> : ConditionValidator<T>
        {
            public StubConditionValidator(ConditionValidator<T> baseValidator)
                : base(baseValidator.ArgumentName, baseValidator.Value)
            {
            }

            protected override void ThrowExceptionCore(string condition, string additionalMessage,
                ConstraintViolationType type)
            {
                // Don't throw.
            }
        }
    }
}