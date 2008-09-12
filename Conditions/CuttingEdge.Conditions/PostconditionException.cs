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
using System;
using System.Runtime.Serialization;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// The exception that is thrown when a method's postcondition is not valid.
    /// </summary>
    /// <remarks>
    /// Do not catch this exception, ever! (And I will come for you, if I will see you do!! ;-)
    /// </remarks>
    [Serializable]
    public sealed class PostconditionException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class.</summary>
        public PostconditionException()
            : this(SR.GetString(SR.PostconditionFailed))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class with a
        /// specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public PostconditionException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public PostconditionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PostconditionException class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about
        /// the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information 
        /// about the source or destination.</param>
        private PostconditionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}