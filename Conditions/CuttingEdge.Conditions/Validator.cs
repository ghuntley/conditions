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

// NOTE: Some methods and properties are decorated with the EditorBrowsableAttribute to prevent those methods
// and properties from showing up in IntelliSense. These members will not be used by users that try to 
// validate arguments and are therefore misleading.
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Enables validation of pre- and postconditions. This class isn't used directly by developers. Instead 
    /// the class should be created by the <see cref="ValidatorExtensions.Requires{T}(T)">Requires</see> and
    /// <see cref="ValidatorExtensions.Ensures{T}(T)">Ensures</see> extension methods.
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
    ///             .EndsWith("&lt;data&gt;");  // throws ArgumentException on failure
    /// 
    ///         col.Requires("col")
    ///             .IsNotNull()          // throws ArgumentNullException on failure
    ///             .IsEmpty();           // throws ArgumentException on failure
    /// 
    ///         // Dom some work
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
    ///         return (ICollection)result;
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    [DebuggerDisplay("Validator (Type: {GetType().Name.Substring(0, GetType().Name.IndexOf(\"Validator\"))}, ArgumentName: {ArgumentName}, Value: {Value} )")]
    public abstract class Validator<T>
    {
        // NOTE: We choice to make these two fields public, so the Extension methods can use it, without we
        // have to worry about extra method calls.

        /// <summary>Gets the name of the argument</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public readonly string ArgumentName;

        /// <summary>Gets the value of the argument</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public readonly T Value;

        /// <summary>Initializes a new instance of the <see cref="Validator{T}"/> class.</summary>
        /// <param name="argumentName">The name of the argument to be validated</param>
        /// <param name="value">The value of the argument to be validated</param>
        internal Validator(string argumentName, T value)
        {
            // This constructor is internal. It is not usefull for a user to inherit from this class.
            // When this ctor is made protected, so should be the BuildException method.
            this.Value = value;
            this.ArgumentName = argumentName;
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> which explains that the given condition does not hold.
        /// The exact type of <see cref="Exception"/> that will be thrown is determined by the
        /// <see cref="Validator{T}"/> implementation. The <see cref="Validator{T}"/> that is created by
        /// calling the <see cref="ValidatorExtensions.Requires{T}(T, string)">Requires</see> will always call
        /// a <see cref="ArgumentException"/>, while the <see cref="Validator{T}"/> that is created by the 
        /// <see cref="ValidatorExtensions.Ensures{T}(T, string)">Ensures</see> method will always throw a 
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
            throw this.BuildException(condition);
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>
        /// true if the specified System.Object is equal to the current System.Object; otherwise, false.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>Returns the hashcode of the current instance.</summary>
        /// <returns>The hashcode of the current instance.</returns>
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

        // This method will get overridden by the RequiresValidator and EnsuresValidator descendants.
        // This allows us to throw a different Exception type when using .Ensures() instead of .Requires().
        internal abstract Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type);

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, string additionalMessage)
        {
            return this.BuildException(condition, additionalMessage, ConstraintViolationType.Default);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition)
        {
            return this.BuildException(condition, null, ConstraintViolationType.Default);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, ConstraintViolationType type)
        {
            return this.BuildException(condition, null, type);
        }
    }
}