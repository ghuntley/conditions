using System;
using System.Collections.Generic;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Represents a <see cref="Int32"/> comparison operation that uses specific an odd-even comparison rule.
    /// Two values are considered equal when they are both even or both odd.
    /// </summary>
    /// <remarks>
    /// This equality comparer is used within the collection tests to determine whether the Contains, 
    /// ContainsAny, and ContainsAll methods operate correctly with collections that implement equality
    /// differently.
    /// </remarks>
    internal sealed class OddEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return IsEven(x) == IsEven(y);
        }

        public int GetHashCode(int obj)
        {
            return IsEven(obj).GetHashCode();
        }

        private static bool IsEven(int value)
        {
            return (value % 2) == 0;
        }
    }
}
