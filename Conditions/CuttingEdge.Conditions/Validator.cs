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

// NOTE: Some methods and properties are decorated with the EditorBrowsableAttribute to prevent those methods
// and properties from showing up in IntelliSense. These members will not be used by users that try to 
// validate arguments and are therefore misleading.
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Enables validation of pre- and postconditions. This class isn't used directly by developers. Instead 
    /// the class should be created by the <see cref="Condition.Requires{T}(T)">Requires</see> and
    /// <see cref="Condition.Ensures{T}(T)">Ensures</see> extension methods.
    /// </summary>
    /// <remarks>
    /// This class is abstract and has an internal constructor. It can't be created or inherited from.
    /// </remarks>
    /// <example>
    /// The following example shows how to use <b>CuttingEdge.Conditions</b>.
    /// <code>
    /// using CuttingEdge.Conditions;
    /// 
    /// public class ExampleClass
    /// {
    ///     public ICollection GetData(Nullable&lt;int&gt; id, string xml, ICollection col)
    ///     {
    ///         // Check all preconditions:
    ///         id.Requires("id")
    ///             .IsNotNull()          // throws ArgumentNullException on failure
    ///             .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
    ///             .IsNotEqualTo(128);   // throws ArgumentException on failure
    /// 
    ///         xml.Requires("xml")
    ///             .StartsWith("&lt;data&gt;") // throws ArgumentException on failure
    ///             .EndsWith("&lt;/data&gt;"); // throws ArgumentException on failure
    /// 
    ///         col.Requires("col")
    ///             .IsNotNull()          // throws ArgumentNullException on failure
    ///             .IsEmpty();           // throws ArgumentException on failure
    /// 
    ///         this._disposed.Requires().Otherwise&lt;ObjectDisposedException>(this.GetType().Name)
    ///             .IsEqualsTo(false);
    ///             
    ///         this.currentState.Requires()
    ///             .Otherwise&lt;InvalidOperationException>("Current state is invalid")
    ///             .IsGreaterThan(StateType.Uninitialized);
    /// 
    ///         // Do some work
    /// 
    ///         // Example: Call a method that should return a not null ICollection
    ///         object result = BuildResults(xml, collection);
    /// 
    ///         // Check all postconditions:
    ///         // A PostconditionException will be thrown at failure.
    ///         result.Ensures("result")
    ///             .IsNotNull()
    ///             .IsOfType(typeof(ICollection));
    /// 
    ///         return result as ICollection;
    ///     }
    /// }
    /// </code>
    /// The following code examples shows how to extend the library with your own 'Invariant' entry point
    /// method. The first example shows a class with an Add method that validates the class state (the
    /// class invariants) before adding the <b>Person</b> object to the internal array and that code should
    /// throw an <see cref="InvalidOperationException"/>.
    /// <code>
    /// using CuttingEdge.Conditions;
    /// 
    /// public class Person { }
    /// 
    /// public class PersonCollection 
    /// {
    ///     public PersonCollection(int capicity)
    ///     {
    ///         this.Capacity = capicity;
    ///     }
    /// 
    ///     public void Add(Person person)
    ///     {
    ///         // Throws a ArgumentNullException when person == null
    ///         person.Requires("person").IsNotNull();
    ///         
    ///         // Throws an InvalidOperationException on failure
    ///         this.Count.Invariant("Count").IsLessOrEqual(this.Capacity);
    ///         
    ///         this.AddInternal(person);
    ///     }
    ///
    ///     public int Count { get; private set; }
    ///     public int Capacity { get; private set; }
    ///     
    ///     private void AddInternal(Person person)
    ///     {
    ///         // some logic here
    ///     }
    ///     
    ///     public bool Contains(Person person)
    ///     {
    ///         // some logic here
    ///         return false;
    ///     }
    /// }
    /// </code>
    /// The following code example will show the implementation of the <b>Invariant</b> extension method.
    /// <code>
    /// using System;
    /// using CuttingEdge.Conditions;
    /// 
    /// namespace MyCompanyRootNamespace
    /// {
    ///     public static class InvariantExtensions
    ///     {
    ///         public static Validator&lt;T> Invariant&lt;T>(this T value)
    ///         {
    ///             return new InvariantValidator&lt;T>("value", value);
    ///         }
    /// 
    ///         public static Validator&lt;T> Invariant&lt;T>(this T value, string argumentName)
    ///         {
    ///             return new InvariantValidator&lt;T>(argumentName, value);
    ///         }
    /// 
    ///         // Internal class that inherits from Validator&lt;T>
    ///         class InvariantValidator&lt;T> : Validator&lt;T>
    ///         {
    ///             public InvariantValidator(string argumentName, T value) : base(argumentName, value) { }
    ///             public override Exception BuildException(string condition, string additionalMessage,
    ///                 ConstraintViolationType type)
    ///             {
    ///                 string message = condition + ".";
    ///                 if (!String.IsNullOrEmpty(additionalMessage))
    ///                     message = condition + ". " + additionalMessage;
    ///                 return new InvalidOperationException(message);
    ///             }
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    [DebuggerDisplay("{GetType().Name} (ArgumentName: {ArgumentName}, Value: {Value} )")]
    public abstract class Validator<T>
    {
        /// <summary>Gets the value of the argument.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        // NOTE: We chose to make the Value a public field, so the Extension methods can use it, 
        // without we have to worry about extra method calls.
        public readonly T Value;

        private readonly string argumentName;

        /// <summary>Initializes a new instance of the <see cref="Validator{T}"/> class.</summary>
        /// <param name="argumentName">The name of the argument to be validated</param>
        /// <param name="value">The value of the argument to be validated</param>
        protected Validator(string argumentName, T value)
        {
            // This constructor is internal. It is not useful for a user to inherit from this class.
            // When this ctor is made protected, so should be the BuildException method.
            this.Value = value;
            this.argumentName = argumentName;
        }

        /// <summary>Gets the name of the argument.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public string ArgumentName
        {
            get { return this.argumentName; }
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> which explains that the given condition does not hold.
        /// The exact type of <see cref="Exception"/> that will be thrown is determined by the
        /// <see cref="Validator{T}"/> implementation. The <see cref="Validator{T}"/> that is created by
        /// calling the <see cref="Condition.Requires{T}(T, string)">Requires</see> will always call
        /// a <see cref="ArgumentException"/>, while the <see cref="Validator{T}"/> that is created by the 
        /// <see cref="Condition.Ensures{T}(T, string)">Ensures</see> method will always throw a 
        /// <see cref="PostconditionException"/>.
        /// </summary>
        /// <param name="condition">
        /// A string describing the condition that does not hold. The condition should be written in the 
        /// following format: "{ArgumentName} should (not) be {check}". i.e. "value should be equal to 10".
        /// This way the generated exception message will be valid for both the Requires as Ensures 
        /// validations.
        /// </param>
        /// <exception cref="Exception">Will always be thrown.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public void Throw(string condition)
        {
            throw this.BuildException(condition, null, ConstraintViolationType.Default);
        }

        /// <summary>
        /// Allows a user to specify the type of exception that has to be thrown. The current 
        /// <see cref="Validator{T}">Validator</see> is used to generate an exception message.
        /// </summary>
        /// <remarks>
        /// This otherwise method is meant to throw unchecked exceptions. Unchecked exceptions are exceptions
        /// that aren't meant to be caught by a program. For instance, An <see cref="ArgumentException"/> and
        /// <see cref="ObjectDisposedException"/> shouldn't be caught. They should bring the program to a
        /// hold. But because the .NET framework doesn't differentiate between checked and unchecked 
        /// exceptions, we can't enforce this.
        /// </remarks>
        /// <typeparam name="TUncheckedException">The exception type that will be thrown by the returned
        /// <see cref="Validator{T}"/> on failure.</typeparam>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <see cref="Value"/> 
        /// and <see cref="ArgumentName"/> of this validator instance.</returns>
        /// <exception cref="TypeInitializationException">Thrown when the specified 
        /// <typeparamref name="TUncheckedException"/> type doesn't contain a public constructor with a single
        /// string argument.</exception>
        public Validator<T> Otherwise<TUncheckedException>() where TUncheckedException : Exception
        {
            return new OtherwiseValidator<T, TUncheckedException>(this);
        }

        /// <summary>
        /// Allows a user to specify the type of exception that has to be thrown and the 
        /// <paramref name="exceptionMessage"/> that comes with it.
        /// </summary>
        /// <remarks>
        /// This otherwise method is meant to throw unchecked exceptions. Unchecked exceptions are exceptions
        /// that aren't meant to be caught by a program. For instance, An <see cref="ArgumentException"/> and
        /// <see cref="ObjectDisposedException"/> shouldn't be caught. They should bring the program to a
        /// hold. But because the .NET framework doesn't differentiate between checked and unchecked 
        /// exceptions, we can't enforce this.
        /// </remarks>
        /// <typeparam name="TUncheckedException">The exception type that will be thrown by the returned
        /// <see cref="Validator{T}"/> on failure.</typeparam>
        /// <param name="exceptionMessage">The message of the exception to be thrown.</param>
        /// <returns>A new <see cref="Validator{T}">Validator</see> containing the <see cref="Value"/> 
        /// and <see cref="ArgumentName"/> of this validator instance.</returns>
        /// <exception cref="TypeInitializationException">Thrown when the specified 
        /// <typeparamref name="TUncheckedException"/> type doesn't contain a public constructor with a single
        /// string argument.</exception>
        public Validator<T> Otherwise<TUncheckedException>(string exceptionMessage)
            where TUncheckedException : Exception
        {
            return new OtherwiseValidator<T, TUncheckedException>(this, exceptionMessage);
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>
        /// true if the specified System.Object is equal to the current System.Object; otherwise, false.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        [Obsolete("This method is not part of the validation framework. Please use the IsEqualTo method.", true)]
#pragma warning disable 809 // Remove the Obsolete attribute from the overriding member, or add it to the ...
        public override bool Equals(object obj)
#pragma warning restore 809
        {
            return base.Equals(obj);
        }

        /// <summary>Returns the hash code of the current instance.</summary>
        /// <returns>The hash code of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the <see cref="Validator{T}"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents the <see cref="Validator{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>Gets the <see cref="System.Type"/> of the current instance.</summary>
        /// <returns>The <see cref="System.Type"/> instance that represents the exact runtime 
        /// type of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public new Type GetType()
        {
            return base.GetType();
        }

        /// <summary>Builds an exception, that has to be thrown.</summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be 
        /// null".</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        /// <returns>A newly created <see cref="Exception"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public abstract Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type);

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, string additionalMessage)
        {
            return this.BuildException(condition, additionalMessage, ConstraintViolationType.Default);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, ConstraintViolationType type)
        {
            return this.BuildException(condition, null, type);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition)
        {
            return this.BuildException(condition, null, ConstraintViolationType.Default);
        }
    }
}