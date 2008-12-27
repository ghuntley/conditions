using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Entry point methods to start validating pre- and postconditions.
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// preconditions of the given argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and "value" as argument name.</returns>
        /// <example>
        /// The following example shows how to use the <b>Requires</b> extension method.
        /// <code>
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
        ///             value.Requires().IsGreaterOrEqual(0);
        ///             this.age = value;
        ///         }
        ///     }
        /// }
        /// </code>
        /// See the <see cref="Validator{T}"/> class for more code examples.
        /// </example>
        public static Validator<T> Requires<T>(this /*_*/ T value)
        {
            return new RequiresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// preconditions of the given argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and <paramref name="argumentName"/>.</returns>
        /// <example>
        /// The following example shows how to use the <b>Requires</b> extension method.
        /// <code>
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
        ///         x.Requires("x").IsGreaterOrEqual(0);
        ///         
        ///         // Throws an ArgumentOutOfRangeException when y is less than 0
        ///         y.Requires("y").IsGreaterOrEqual(0);
        ///         
        ///         this.x = x;
        ///         this.y = y;
        ///     }
        ///     
        ///     public int X { get { return this.x; } }
        ///     public int Y { get { return this.y; } }
        /// }
        /// </code>
        /// See the <see cref="Validator{T}"/> class for more code examples.
        /// </example>
        public static Validator<T> Requires<T>(this /*_*/ T value, string argumentName)
        {
            return new RequiresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the given 
        /// argument, given it a default ArgumentName of 'value'.
        /// </summary>
        /// <typeparam name="T">The type of the argument to validate.</typeparam>
        /// <param name="value">The value of the argument to validate.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/>
        /// and "value" as argument name.</returns>
        /// <example>
        /// For an example of the usuage of <b>Ensures</b> see the <see cref="Condition.Ensures{T}(T,string)"/> overload.
        /// </example>
        public static Validator<T> Ensures<T>(this /*_*/ T value)
        {
            return new EnsuresValidator<T>("value", value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/> 
        /// and <paramref name="argumentName"/>.</returns>
        /// <example>
        /// The following example shows a way to use the <b>Ensures</b> extension method. Shown is an 
        /// <b>IObjectBuilder</b> interface which contract states that the <b>BuildObject</b> method should 
        /// never return <b>null</b>. That contract, however, is not enforced by the compiler or the runtime.
        /// To allow this contract to be validated, the <b>ObjectBuilderValidator</b> class is a decorator for
        /// objects implementing the <b>IObjectBuilder</b> interface and it <i>ensures</i> that the given
        /// contract is fulfilled, by checking the return value of the called <b>BuildObject</b> of the 
        /// wrapped <b>IObjectBuilder</b>.
        /// <code>
        /// using CuttingEdge.Conditions;
        /// 
        /// public interface IObjectBuilder
        /// {
        ///     /// &lt;summary>Builds an object.&lt;/summary>
        ///     /// &lt;returns>Returns a newly built object. Will not return null.&lt;/returns>
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
        ///         obj.Ensures("the value returned by IObjectBuilder.BuildObject()")
        ///             .IsNotNull();
        /// 
        ///         return obj;
        ///     }
        /// 
        ///     private readonly IObjectBuilder wrappedObjectBuilder;
        ///
        ///     /// &lt;summary>
        ///     /// Initializes a new instance of the &lt;see cref="ObjectBuilderValidator"/> class.
        ///     /// &lt;/summary>
        ///     /// &lt;param name="objectBuilder">The object builder.&lt;/param>
        ///     /// &lt;exception cref="ArgumentNullException">
        ///     /// Thrown when &lt;paramref name="objectBuilder"/> is a null reference.
        ///     /// &lt;/exception>
        ///     public ObjectBuilderWrapper(IObjectBuilder objectBuilder)
        ///     {
        ///         // Throws a ArgumentNullException when objectBuilder == null.
        ///         objectBuilder.Requires("objectBuilder").IsNotNull();
        /// 
        ///         this.wrappedObjectBuilder = objectBuilder;
        ///     }
        /// }
        /// </code>
        /// See the <see cref="Validator{T}"/> class for more code examples.
        /// </example>
        public static Validator<T> Ensures<T>(this /*_*/ T value, string argumentName)
        {
            return new EnsuresValidator<T>(argumentName, value);
        }

        /// <summary>
        /// Returns a new <see cref="Validator{T}">Validator</see> that allows you to validate the 
        /// postconditions of the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object to validate.</typeparam>
        /// <param name="value">The object to validate.</param>
        /// <param name="argumentName">The name of the argument to validate</param>
        /// <param name="additionalMessage">A message that will be appended to generated exception message.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <paramref name="value"/> 
        /// and <paramref name="argumentName"/>.</returns>
        /// <example>
        /// For an example of the usuage of <b>Ensures</b> see the <see cref="Condition.Ensures{T}(T,string)"/> overload.
        /// </example>
        public static Validator<T> Ensures<T>(this /*_*/ T value, string argumentName, string additionalMessage)
        {
            return new EnsuresValidator<T>(argumentName, value, additionalMessage);
        }
    }
}
