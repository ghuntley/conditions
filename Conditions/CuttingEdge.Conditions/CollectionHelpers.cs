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
        internal static bool Contains<T>(IEnumerable<T> sequence, T value)
        {
            // NOTE that we don't try to cast sequence to an ICollection<T> and call it's Contains method,
            // because it is possible that source uses a non-default implementation of equality. Consequence
            // of this is that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;

            foreach (T local in sequence)
            {
                if (comparer.Equals(local, value))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool Contains(IEnumerable sequence, object value)
        {
            // NOTE that we don't try to cast sequence to an IList and call it's Contains method, because it
            // is possible that sequence uses a non-default implementation of equality. Consequence of this is
            // that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
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
        // While creating a O(1) set of the sequence, might reduce the cost of this call to O(m) (where m:
        // the number of elements in 'values'), copying the sequence might cost a lot, and a different
        // implementation might improve overall performance.
        internal static bool ContainsAny<T>(IEnumerable<T> sequence, IEnumerable<T> values)
        {
            // When the values list is empty we can say that there is none of them in the collection.
            if (IsSequenceNullOrEmpty(values))
            {
                return false;
            }

            // When the collection is empty there can not be a single value in that collection. 
            if (IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            // NOTE that we don't try to cast sequence to an ICollection<T> and call it's Contains method,
            // because it is possible that source uses a non-default implementation of equality. Consequence
            // of this is that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
            // To prevent a cost of O(n*m) we copy the sequence into a set (copy cost: O(n), using set: O(1)).
            // Which gives a total cost of: O(n) + O(2m). Note that copying sequence is equal to iterating it.
            bool sequenceContainsNull;
            var set = ConvertToSet<T>(sequence, out sequenceContainsNull);

            // Determine whether sequence contains one of the values.
            foreach (T element in values)
            {
                if (element == null)
                {
                    if (sequenceContainsNull)
                    {
                        return true;
                    }
                }
                else
                {
                    if (set.ContainsKey(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // TODO: Optimize this method for performance.
        // While creating a O(1) set of the sequence, might reduce the cost of this call to O(m) (where m:
        // the number of elements in 'values'), copying the sequence might cost a lot, and a different
        // implementation might improve overall performance.
        internal static bool ContainsAny(IEnumerable sequence, IEnumerable values)
        {
            // When the values list is empty we can say that there is none of them in the collection.
            if (IsSequenceNullOrEmpty(values))
            {
                return false;
            }

            // When the sequence is empty there can not be a single value in that collection. 
            if (IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            // NOTE that we don't try to cast sequence to an IList and call it's Contains method, because it
            // is possible that source uses a non-default implementation of equality. Consequence of this is
            // that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
            // To prevent a cost of O(n*m) we copy the sequence into a set (copy cost: O(n), using set: O(1)).
            // Which gives a total cost of: O(n) + O(2m). Note that copying sequence is equal to iterating it.
            bool sequenceContainsNull;
            var set = ConvertToSet(sequence, out sequenceContainsNull);

            // Determine whether sequence contains one of the values.
            foreach (object element in values)
            {
                if (element == null)
                {
                    if (sequenceContainsNull)
                    {
                        return true;
                    }
                }
                else
                {
                    if (set.ContainsKey(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // TODO: Optimize this method for performance.
        // While creating a O(1) set of the sequence, might reduce the cost of this call to O(m) (where m:
        // the number of elements in 'values'), copying the sequence might cost a lot, and a different
        // implementation might improve overall performance.
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

            // NOTE that we don't try to cast sequence to an ICollection<T> and call it's Contains method,
            // because it is possible that source uses a non-default implementation of equality. Consequence
            // of this is that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
            // To prevent a cost of O(n*m) we copy the sequence into a set (copy cost: O(n), using set: O(1)).
            // Which gives a total cost of: O(n) + O(2m). Note that copying sequence is equal to iterating it.
            bool sequenceContainsNull;
            var set = ConvertToSet<T>(sequence, out sequenceContainsNull);

            // Determine whether sequence contains one of the values.                
            foreach (T element in values)
            {
                if (element == null)
                {
                    if (!sequenceContainsNull)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!set.ContainsKey(element))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // TODO: Optimize this method for performance.
        // While creating a O(1) set of the sequence, might reduce the cost of this call to O(m) (where m:
        // the number of elements in 'values'), copying the sequence might cost a lot, and a different
        // implementation might improve overall performance.
        internal static bool ContainsAll(IEnumerable sequence, IEnumerable values)
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

            // NOTE that we don't try to cast sequence to an IList and call it's Contains method, because it
            // is possible that source uses a non-default implementation of equality. Consequence of this is
            // that we always have to iterate the sequence, with a cost of O(n).
            // See work item 10480 on CodePlex for more info: 
            // http://conditions.codeplex.com/WorkItem/View.aspx?WorkItemId=10480.
            // To prevent a cost of O(n*m) we copy the sequence into a set (copy cost: O(n), using set: O(1)).
            // Which gives a total cost of: O(n) + O(2m). Note that copying sequence is equal to iterating it.
            bool sequenceContainsNull;
            var set = ConvertToSet(sequence, out sequenceContainsNull);

            foreach (object element in values)
            {
                if (element == null)
                {
                    if (!sequenceContainsNull)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!set.ContainsKey(element))
                    {
                        return false;
                    }
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

                // Optimization: We use the while statement instead of foreach, because we don't need a value, 
                // we don't have to call enumerator.Current. foreach Calls Current always and this could lead
                // to boxing of elements when the enumerator is a IEnumerator<T> and T is a struct.
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

                // Optimization: We use the while statement instead of foreach, because we don't need a value, 
                // we don't have to call enumerator.Current. foreach Calls Current always and this could lead
                // to boxing of elements when the enumerator is a IEnumerator<T> and T is a struct.
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

                // Optimization: We use the while statement instead of foreach, because we don't need a value, 
                // we don't have to call enumerator.Current. foreach Calls Current always and this could lead
                // to boxing of elements when the enumerator is a IEnumerator<T> and T is a struct.
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

                // Optimization: We use the while statement instead of foreach, because we don't need a value, 
                // we don't have to call enumerator.Current. foreach Calls Current always and this could lead
                // to boxing of elements when the enumerator is a IEnumerator<T> and T is a struct.
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

                // Optimization: We use the while statement instead of foreach, because we don't need a value, 
                // we don't have to call enumerator.Current. foreach Calls Current always and this could lead
                // to boxing of elements when the enumerator is a IEnumerator<T> and T is a struct.
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

        private static Dictionary<T, byte> ConvertToSet<T>(IEnumerable<T> sequence,
            out bool sequenceContainsNull)
        {
            // A dictionary can have null as one of it's keys, therefore we have to communicate whether the
            // sequence contains null. (HashSet<T> does have this ability).
            sequenceContainsNull = false;

            int capacity = DetermineInitialCapacity<T>(sequence);

            // A Dictionary is used to improve performance. Using 'Contains' on a collection would give a 
            // performance characteristic of O(n*m) and with a Dictionary it's of O(m).
            // Using HashSet<T> is slightly more performant, but HashSet<T> is part of .NET 3.5 and we 
            // don't want to have to reference to 3.5 unless it's really needed.
            Dictionary<T, byte> set = new Dictionary<T, byte>(capacity);

            foreach (T element in sequence)
            {
                if (element != null)
                {
                    const byte Dummy = 0;
                    set[element] = Dummy;
                }
                else
                {
                    sequenceContainsNull = true;
                }
            }

            return set;
        }

        private static int DetermineInitialCapacity<T>(IEnumerable<T> sequence)
        {
            ICollection<T> collection = sequence as ICollection<T>;

            if (collection != null)
            {
                return collection.Count;
            }

            return 0;
        }

        private static Dictionary<object, byte> ConvertToSet(IEnumerable sequence, 
            out bool sequenceContainsNull)
        {
            // A dictionary can have null as one of it's keys, therefore we have to communicate whether the
            // sequence contains null.
            sequenceContainsNull = false;

            int capacity = DetermineInitialCapacity(sequence);

            // A Dictionary is used to improve performance. Using 'Contains' on a collection would give a 
            // performance characteristic of O(n*m) and with a Dictionary it's of O(m).
            // Using HashSet<T> is slightly more performant, but HashSet<T> is part of .NET 3.5 and we 
            // don't want to have to reference to 3.5 unless it's really needed.
            Dictionary<object, byte> set = new Dictionary<object, byte>(capacity);

            foreach (object element in sequence)
            {
                if (element != null)
                {
                    const byte Dummy = 0;
                    set[element] = Dummy;
                }
                else
                {
                    sequenceContainsNull = true;
                }
            }

            return set;
        }

        private static int DetermineInitialCapacity(IEnumerable sequence)
        {
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count;
            }

            return 0;
        }
    }
}