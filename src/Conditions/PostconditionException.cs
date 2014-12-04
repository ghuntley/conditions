using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Conditions
{
    /// <summary>
    /// The exception that is thrown when a method's postcondition is not valid.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
        MessageId = "Postcondition", Justification = "Postcondition is actually a word. " +
                                                     "See: http://en.wikipedia.org/wiki/Postcondition.")]
    public sealed class PostconditionException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class.</summary>
        public PostconditionException() : this(SR.GetString(SR.PostconditionFailed))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class with a
        /// specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public PostconditionException(string message) : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PostconditionException"/> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public PostconditionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}