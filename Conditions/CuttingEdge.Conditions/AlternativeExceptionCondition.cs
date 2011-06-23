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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// An instance of this type is returned from the 
    /// <see cref="Condition.WithExceptionOnFailure{TException}"/> method overloads and allow you to specify
    /// the exception type that should be thrown on failure.
    /// </summary>
    public abstract class AlternativeExceptionCondition
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
        /// The following example shows how to use the <b>Requires</b> extension method.
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
        ///             // Throws an InvalidOperationException when value is less than 0
        ///             Condition.WithExceptionOnFailure<InvalidOperationException>()
        ///                 .Requires(value).IsGreaterOrEqual(0);
        ///                 
        ///             this.age = value;
        ///         }
        ///     }
        /// }
        /// ]]></code>
        /// See the <see cref="ConditionValidator{T}"/> class for more code examples.
        /// </example>
        public abstract ConditionValidator<T> Requires<T>(T value);

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
        /// The following example shows how to use the <b>Requires</b> extension method.
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
        ///         Condition.WithExceptionOnFailure<InvalidOperationException>()
        ///             .Requires(x, "x").IsGreaterOrEqual(0);
        ///         
        ///         // Throws an InvalidOperationException when y is less than 0
        ///         Condition.WithExceptionOnFailure<InvalidOperationException>()
        ///             .Requires(y, "y").IsGreaterOrEqual(0);
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
        public abstract ConditionValidator<T> Requires<T>(T value, string argumentName);
        
        /// <summary>Determines whether the specified System.Object is equal to the current System.Object.</summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>true if the specified System.Object is equal to the current System.Object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        [Obsolete("This method is not part of the Conditions framework. Please use the Requires().IsEqualTo method.", true)]
#pragma warning disable 809
        public override bool Equals(object obj)
#pragma warning restore 809
        {
            return base.Equals(obj);
        }

        /// <summary>Returns the hash code of the current instance.</summary>
        /// <returns>The hash code of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the <see cref="AlternativeExceptionCondition"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents the <see cref="AlternativeExceptionCondition"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>Gets the <see cref="System.Type"/> of the current instance.</summary>
        /// <returns>The <see cref="System.Type"/> instance that represents the exact runtime 
        /// type of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification =
            "This FxCop warning is valid, but this method is used to be able to attach an " +
            "EditorBrowsableAttrubute to the GetType method, which will hide the method when the user " +
            "browses the methods of the ConditionValidator class with IntelliSense. The GetType method has " +
            "no value for the user who will only use this class for validation.")]
        public new Type GetType()
        {
            return base.GetType();
        }
    }
}