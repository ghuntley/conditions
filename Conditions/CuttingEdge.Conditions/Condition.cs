#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Entry point methods to start validating pre- and postconditions.
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to
        /// validate the preconditions of the given argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
        /// <paramref name="value"/> and "value" as argument name.</returns>
        /// <example>
        /// The following example shows how to use the <b>Requires</b> method.
        /// <code><![CDATA[
        /// using CuttingEdge.Conditions;
        /// 
        /// public class Person
        /// {
        ///     private int age;
        ///     
        ///     public int Age
        ///     {
        ///         get { return this.age; }
        ///         set
        ///         {
        ///             // Throws an ArgumentOutOfRangeException when value is less than 0
        ///             Condition.Requires(value).IsGreaterOrEqual(0);
        ///             this.age = value;
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// See the <see cref="ConditionValidator{T}"/> class for more code examples.
        /// </example>
        public static ConditionValidator<T> Requires<T>(T value)
        {
            return new RequiresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to
        /// validate the preconditions of the given argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
        /// <paramref name="value"/> and <paramref name="argumentName"/>.</returns>
        /// <example>
        /// The following example shows how to use the <b>Requires</b> method.
        /// <code><![CDATA[
        /// using CuttingEdge.Conditions;
        /// 
        /// public class Point
        /// {
        ///     private readonly int x;
        ///     private readonly int y;
        ///     
        ///     public Point(int x, int y)
        ///     {
        ///         // Throws an ArgumentOutOfRangeException when x is less than 0
        ///         Condition.Requires(x, "x").IsGreaterOrEqual(0);
        ///         
        ///         // Throws an ArgumentOutOfRangeException when y is less than 0
        ///         Condition.Requires(y, "y").IsGreaterOrEqual(0);
        ///         
        ///         this.x = x;
        ///         this.y = y;
        ///     }
        ///     
        ///     public int X { get { return this.x; } }
        ///     public int Y { get { return this.y; } }
        /// }
        /// ]]></code>
        /// See the <see cref="ConditionValidator{T}"/> class for more code examples.
        /// </example>
        public static ConditionValidator<T> Requires<T>(T value, string argumentName)
        {
            return new RequiresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to 
        /// validate the given argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
        /// <paramref name="value"/> and "value" as argument name.</returns>
        /// <example>
        /// For an example of the usage of <b>Ensures</b> see the <see cref="Condition.Ensures{T}(T,string)"/> 
        /// overload.
        /// </example>
        public static ConditionValidator<T> Ensures<T>(T value)
        {
            return new EnsuresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="ConditionValidator{T}">ConditionValidator</see> that allows you to 
        /// validate the postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="ConditionValidator{T}">ConditionValidator</see> containing the 
        /// <paramref name="value"/> and <paramref name="argumentName"/>.</returns>
        /// <example>
        /// The following example shows a way to use the <b>Ensures</b> method. Shown is an 
        /// <b>IObjectBuilder</b> interface which contract states that the <b>BuildObject</b> method should 
        /// never return <b>null</b>. That contract, however, is not enforced by the compiler or the runtime.
        /// To allow this contract to be validated, the <b>ObjectBuilderValidator</b> class is a decorator for
        /// objects implementing the <b>IObjectBuilder</b> interface and it <i>ensures</i> that the given
        /// contract is fulfilled, by checking the return value of the called <b>BuildObject</b> of the 
        /// wrapped <b>IObjectBuilder</b>.
        /// <code><![CDATA[
        /// using CuttingEdge.Conditions;
        /// 
        /// public interface IObjectBuilder
        /// {
        ///     /// <summary>Builds an object.</summary>
        ///     /// <returns>Returns a newly built object. Will not return null.</returns>
        ///     object BuildObject();
        /// }
        /// 
        /// public class ObjectBuilderValidator : IObjectBuilder
        /// {
        ///     public object BuildObject()
        ///     {
        ///         object obj = wrappedObjectBuilder.BuildObject();
        /// 
        ///         // When obj == null, a PostconditionException is thrown, with the following message:
        ///         // "Postcondition 'the value returned by IObjectBuilder.BuildObject() should not be null'
        ///         // failed."
        ///         Conditions.Ensures(obj, "the value returned by IObjectBuilder.BuildObject()")
        ///             .IsNotNull();
        /// 
        ///         return obj;
        ///     }
        /// 
        ///     private readonly IObjectBuilder wrappedObjectBuilder;
        ///
        ///     /// <summary>
        ///     /// Initializes a new instance of the <see cref="ObjectBuilderValidator"/> class.
        ///     /// </summary>
        ///     /// <param name="objectBuilder">The object builder.</param>
        ///     /// <exception cref="ArgumentNullException">
        ///     /// Thrown when <paramref name="objectBuilder"/> is a null reference.
        ///     /// </exception>
        ///     public ObjectBuilderWrapper(IObjectBuilder objectBuilder)
        ///     {
        ///         // Throws a ArgumentNullException when objectBuilder == null.
        ///         Condition.Requires(objectBuilder, "objectBuilder").IsNotNull();
        /// 
        ///         this.wrappedObjectBuilder = objectBuilder;
        ///     }
        /// }
        /// ]]></code>
        /// See the <see cref="ConditionValidator{T}"/> class for more code examples.
        /// </example>
        public static ConditionValidator<T> Ensures<T>(T value, string argumentName)
        {
            return new EnsuresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="AlternativeExceptionCondition" /> that allows you to specify the exception
        /// type that has to be thrown in case a a validation fails.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <returns>A new <see cref="AlternativeExceptionCondition" />.</returns>
        /// <example>
        /// The following example shows how to use the <b>WithExceptionOnFailure</b> method.
        /// <code><![CDATA[
        /// using CuttingEdge.Conditions;
        /// 
        /// public class Point
        /// {
        ///     private readonly int x;
        ///     private readonly int y;
        ///     
        ///     public Point(int x, int y)
        ///     {
        ///         // Throws an InvalidOperationException when x is less than 0
        ///         Condition.WithExceptionOnFailure<InvalidOperationException>().Requires(x, "x")
        ///             .IsGreaterOrEqual(0)
        ///             .IsLessThan(100);
        ///         
        ///         this.x = x;
        ///         this.y = y;
        ///     }
        ///     
        ///     public int X { get { return this.x; } }
        ///     public int Y { get { return this.y; } }
        /// }
        /// ]]></code>
        /// See the <see cref="ConditionValidator{T}"/> class for more code examples.
        /// </example>
        /// <exception cref="ArgumentException">
        /// Thrown when the supplied <typeparamref name="TException"/> is abstract or does not contain a
        /// public constructor with a single parameter of type <see cref="string"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification =
            "By using a generic type we can limit the used types to Exceptions by applying a type constraint.")]
        public static AlternativeExceptionCondition WithExceptionOnFailure<TException>()
            where TException : Exception
        {
            var condition = AlternativeExceptionHelper<TException>.Condition;

            if (condition == null)
            {
                ThrowInvalidExceptionType(typeof(TException));
            }

            return condition;
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification =
            "The ParamName equals the name of the generic type of the WithExceptionOnFailure method.")]
        private static void ThrowInvalidExceptionType(Type exceptionType)
        {
            throw new ArgumentException(SR.GetString(SR.ExceptionTypeIsInvalid, exceptionType), 
                "TException");
        }
    }
}