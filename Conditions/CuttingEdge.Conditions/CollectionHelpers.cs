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
using System.Collections;
using System.Collections.Generic;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Helper methods for the Collection validation methods of the <see cref="ValidatorExtensions"/> methods.
    /// </summary>
    internal static class CollectionHelpers
    {
        // This method mimics the behavior of the System.Linq.Enumerable.Contains method.
        // By not using Enumerable.Contains, we are more independant of System.Core.dll and we increase the
        // possibility for users to use this library on machines that don't have .NET 3.5 installed.
        internal static bool Contains<TSource>(IEnumerable<TSource> source, TSource value)
        {
            ICollection<TSource> is2 = source as ICollection<TSource>;
            
            if (is2 != null)
            {
                return is2.Contains(value);
            }

            IEqualityComparer<TSource> comparer = EqualityComparer<TSource>.Default;

            foreach (TSource local in source)
            {
                if (comparer.Equals(local, value))
                {
                    return true;
                }
            }

            return false;
        }

        // NOTE: HashSet<T> is a strange class that only implements generic interfaces. It doesn't implement
        // IList and therefore the cost of calling this method on HashSet<T> is O(n), and not O(1).
        internal static bool Contains(IEnumerable sequence, object value)
        {
            // We will first check if the collection is an IList. If this is the case, we could use the
            // IList.Contains method, which has in the worst case a performance of O(n) and possibly a
            // performance of O(1).
            IList list = sequence as IList;

            if (list != null)
            {
                return list.Contains(value);
            }

            // The collection is no IList and we'll have to iterate over it. Cost: O(n).
            Comparer<object> comparer = Comparer<object>.Default;

            foreach (object element in sequence)
            {
                if (comparer.Compare(element, value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        // TODO: Optimize this method for performance.
        // Creating a HashSet costs more than calling IEnumerable.Contains when the 'values' collection is 
        // very small.
        internal static bool ContainsAny<T>(IEnumerable<T> sequence, IEnumerable<T> values)
        {
            // When the values list is empty we can say that there is none of them in the collection.
            // When the collection is empty there can not be a single value in that collection. 
            if (IsSequenceNullOrEmpty(values) || IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            // A HashSet is used to improve performance. Using Contains on a collection would give
            // a performance characteristic of O(n*m) and with a HashSet it's of O(m).
            HashSet<T> set = sequence as HashSet<T>;

            if (set == null)
            {
                set = new HashSet<T>(sequence);
            }

            foreach (T element in values)
            {
                if (set.Contains(element))
                {
                    return true;
                }
            }

            return false;
        }

        // TODO: Optimize this method for performance.
        // Creating a HashSet costs more than calling IEnumerable.Contains when the values collection is 
        // very small.
        internal static bool ContainsAny(IEnumerable sequence, IEnumerable values)
        {
            // When the values list is empty we can say that there is none of them in the collection.
            // When the collection is empty there can not be a single value in that collection. 
            if (IsSequenceNullOrEmpty(values) || IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            // A HashSet is used to improve performance. Using Contains on a collection would give
            // a performance characteristic of O(n*m) and with a HashSet it's of O(m).
            HashSet<object> set = new HashSet<object>();

            foreach (object element in sequence)
            {
                set.Add(element);
            }

            foreach (object element in values)
            {
                if (set.Contains(element))
                {
                    return true;
                }
            }

            return false;
        }

        // TODO: Optimize this method for performance.
        // Creating a HashSet costs more than calling IEnumerable.Contains when the values collection is 
        // very small.
        internal static bool ContainsAll<T>(IEnumerable<T> sequence, IEnumerable<T> values)
        {
            // When the values list is empty we consider all of them to be in the collection (even if the
            // collection itself is also empty).
            if (IsSequenceNullOrEmpty(values))
            {
                return true;
            }

            // When the values list isn't empty, but the collection is, then there must be at least one value
            // that is not in the collection.
            if (IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            // A HashSet is used to improve performance. Using Contains on a collection would give a 
            // performance characteristic of O(n*m) and with a HashSet it's of O(m).
            HashSet<T> set = sequence as HashSet<T>;

            if (set == null)
            {
                set = new HashSet<T>(sequence);
            }

            foreach (T element in values)
            {
                if (!set.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        // TODO: Optimize this method for performance.
        // Creating a HashSet costs more than calling IEnumerable.Contains when the values collection is 
        // very small.
        internal static bool ContainsAll(IEnumerable collection, IEnumerable values)
        {
            // When the values list is empty we consider all of them to be in the collection (even if the
            // collection itself is also empty).
            if (IsSequenceNullOrEmpty(values))
            {
                return true;
            }

            // When the values list isn't empty, but the collection is, then there must be atleast one value
            // that is not in the collection.
            if (IsSequenceNullOrEmpty(collection))
            {
                return false;
            }

            // A HashSet is used to improve performance. Using Contains on a collection would give a 
            // performance characteristic of O(n*m) and with a HashSet it's of O(m).
            HashSet<object> set = new HashSet<object>();

            foreach (object element in collection)
            {
                set.Add(element);
            }

            foreach (object element in values)
            {
                if (!set.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool SequenceHasLength(IEnumerable sequence, int numberOfElements)
        {
            // When the given enumerable is a null reference, we can do a fast check for numberOfElements == 0,
            // because we consider a null reference to have zero elements.
            if (sequence == null)
            {
                return 0 == numberOfElements;
            }

            // When the given enumerable is an ICollection, we can do a simple interface call.
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count == numberOfElements;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                // Optimization: We use while instead of foreach. Because we don't need a value, we don't have
                // to call enumerator.Current. Foreach calls Current always and this could lead to boxing of
                // elements when the enumerator is a IEnumerator<T> and T is a struct.
                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    // Optimization: We can return immediately when we notice that the sequence is bigger.
                    if (lengthOfSequence > numberOfElements)
                    {
                        return false;
                    }
                }

                return lengthOfSequence == numberOfElements;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        // This method a candidate for inlining because it's 32 bytes of IL.
        internal static bool IsSequenceNullOrEmpty<TSource>(IEnumerable<TSource> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection<TSource> collection = sequence as ICollection<TSource>;

            if (collection != null)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }
            else
            {
                // We expect this to be the exceptional flow, because most collections implement 
                // ICollection<T>.
                return IsSequenceNullOrEmpty((IEnumerable)sequence);
            }
        }

        // This method a candidate for inlining because it's 32 bytes of IL.
        internal static bool IsSequenceNullOrEmpty(IEnumerable sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }
            else
            {
                // We expect this to be the exceptional flow, because most collections implement ICollection.
                return IsEnumerableEmpty(sequence);
            }
        }

        internal static bool SequenceIsShorterThan(IEnumerable sequence, int numberOfElements)
        {
            // When the given enumerable is a null reference, we can do a fast check for numberOfElements > 0,
            // because we consider a null reference to have zero elements.
            if (sequence == null)
            {
                return 0 < numberOfElements;
            }

            // When the given enumerable is an ICollection, we can do a simple interface call.
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count < numberOfElements;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                // Optimization: We use while instead of foreach. Because we don't need a value, we don't have
                // to call enumerator.Current. Foreach calls Current always and this could lead to boxing of
                // elements when the enumerator is a IEnumerator<T> and T is a struct.
                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    // Optimization: We can return immediately when we see that the sequence is not smaller.
                    if (lengthOfSequence >= numberOfElements)
                    {
                        return false;
                    }
                }

                return lengthOfSequence < numberOfElements;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal static bool SequenceIsShorterOrEqual(IEnumerable sequence, int numberOfElements)
        {
            // When the given enumerable is a null reference, we can do a fast check for 0 <= numberOfElements,
            // because we consider a null reference to have zero elements.
            if (sequence == null)
            {
                return 0 <= numberOfElements;
            }

            // When the given enumerable is an ICollection, we can do a simple interface call.
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count <= numberOfElements;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                // Optimization: We use while instead of foreach. Because we don't need a value, we don't have
                // to call enumerator.Current. Foreach calls Current always and this could lead to boxing of
                // elements when the enumerator is a IEnumerator<T> and T is a struct.
                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    // Optimization: We can return immediately when we see that the sequence is bigger.
                    if (lengthOfSequence > numberOfElements)
                    {
                        return false;
                    }
                }

                return lengthOfSequence <= numberOfElements;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal static bool SequenceIsLongerThan(IEnumerable sequence, int numberOfElements)
        {
            // When the given enumerable is a null reference, we can do a fast check for numberOfElements < 0,
            // because we consider a null reference to have zero elements.
            if (sequence == null)
            {
                return 0 > numberOfElements;
            }

            // When the given enumerable is an ICollection, we can do a simple interface call.
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count > numberOfElements;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                // Optimization: We use while instead of foreach. Because we don't need a value, we don't have
                // to call enumerator.Current. Foreach calls Current always and this could lead to boxing of
                // elements when the enumerator is a IEnumerator<T> and T is a struct.
                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    // Optimization: We can return immediately when we see that the sequence is bigger.
                    if (lengthOfSequence > numberOfElements)
                    {
                        return true;
                    }
                }

                return lengthOfSequence > numberOfElements;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        internal static bool SequenceIsLongerOrEqual(IEnumerable sequence, int numberOfElements)
        {
            // When the given enumerable is a null reference, we can do a fast check for 0 <= numberOfElements,
            // because we consider a null reference to have zero elements.
            if (sequence == null)
            {
                return 0 >= numberOfElements;
            }

            // When the given enumerable is an ICollection, we can do a simple interface call.
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count >= numberOfElements;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                // Optimization: We use while instead of foreach. Because we don't need a value, we don't have
                // to call enumerator.Current. Foreach calls Current always and this could lead to boxing of
                // elements when the enumerator is a IEnumerator<T> and T is a struct.
                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    // Optimization: We can return immediately when we see that the sequence is bigger.
                    if (lengthOfSequence >= numberOfElements)
                    {
                        return true;
                    }
                }

                return lengthOfSequence >= numberOfElements;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        // This method is NOT a candidate for inlining because try-catch logic is not inlined.
        private static bool IsEnumerableEmpty(IEnumerable sequence)
        {
            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                return !enumerator.MoveNext();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}