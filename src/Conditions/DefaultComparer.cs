using System.Collections.Generic;

namespace Conditions
{
    /// <summary>
    /// By letting the methods of the ValidatorExtensions class call this static field, it saves us a call to 
    /// the Comparer{T}.get_Default() method.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    internal static class DefaultComparer<T>
    {
        internal static readonly Comparer<T> Default = Comparer<T>.Default;
    }
}