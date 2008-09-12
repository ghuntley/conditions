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
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests
{
    public sealed partial class ValidatorExtensionTests
    {
        #region IsEmpty

        [TestMethod]
        [Description("Calling IsEmpty on a null reference to ICollection should pass.")]
        public void IsEmptyTest1()
        {
            ICollection c = null;
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty collection should pass.")]
        public void IsEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on a null reference to IEnumerable should pass.")]
        public void IsEmptyTest3()
        {
            IsEmptyTestEnumerable c = null;
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [Description("Calling IsEmpty on an empty IEnumerable should pass.")]
        public void IsEmptyTest4()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(true);
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty ICollection should fail.")]
        public void IsEmptyTest5()
        {
            Collection<int> c = new Collection<int>();
            c.Add(1);
            c.Requires().IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEmpty on an non empty IEnumerable should fail.")]
        public void IsEmptyTest6()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(false);
            c.Requires().IsEmpty();
        }

        #endregion // IsEmpty

        #region IsNotEmpty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest1()
        {
            ICollection c = null;
            c.Requires().IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an empty ICollection should fail.")]
        public void IsNotEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest3()
        {
            IsEmptyTestEnumerable c = null;
            c.Requires().IsNotEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should fail.")]
        public void IsNotEmptyTest4()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(true);
            c.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty ICollection should pass.")]
        public void IsNotEmptyTest5()
        {
            Collection<int> c = new Collection<int>();
            c.Add(1);
            c.Requires().IsNotEmpty();
        }

        [TestMethod]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should pass.")]
        public void IsNotEmptyTest6()
        {
            IsEmptyTestEnumerable c = new IsEmptyTestEnumerable(false);
            c.Requires().IsNotEmpty();
        }

        #endregion // IsNotEmpty

        #region Contains

        // Calling Contains on an array should compile.
        private void CollectionContainsShouldCompileTest01()
        {
            int[] c = new int[1] { 1 };
            c.Requires().Contains(1);
        }

        // Calling Contains on a Collection should compile.
        private void CollectionContainsShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        // Calling Contains on an IEnumerable should compile.
        private void CollectionContainsShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling Contains on null reference should fail.")]
        public void CollectionContainsTest01()
        {
            Collection<int> c = null;
            c.Requires().Contains(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an empty collection should fail.")]
        public void CollectionContainsTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an Collection that contains the tested value should pass.")]
        public void CollectionContainsTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(1);
        }

        [TestMethod]
        [Description("Calling Contains on an untyped Collection that contains the tested value should pass.")]
        public void CollectionContainsTest04()
        {
            ArrayList c = new ArrayList { 1 };
            c.Requires().Contains((object)1);
        }

        [TestMethod]
        [Description("Calling Contains on an typed Collection that contains the tested untyped value should pass.")]
        public void CollectionContainsTest05()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains((object)1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on an typed Collection that doesn't contain the tested untyped value should fail.")]
        public void CollectionContainsTest06()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().Contains(new object());
        }

        [TestMethod]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest07()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            c.Requires().Contains((object)1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T> and doesn't contain the tested value should fail.")]
        public void CollectionContainsTest08()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            c.Requires().Contains((object)1001);
        }

        #endregion // Contains

        #region DoesNotContain

        // Calling DoesNotContain on an array should compile.
        private void CollectionDoesNotContainShouldCompileTest01()
        {
            int[] c = new int[0];
            c.Requires().DoesNotContain(1);
        }

        // Calling DoesNotContain on a Collection should compile.
        private void CollectionDoesNotContainShouldCompileTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        // Calling DoesNotContain on an IEnumerable should compile.
        private void CollectionDoesNotContainShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on null reference should pass.")]
        public void CollectionDoesNotContainTest01()
        {
            Collection<int> c = null;
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an empty collection should pass.")]
        public void CollectionDoesNotContainTest02()
        {
            Collection<int> c = new Collection<int>();
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().DoesNotContain(1);
        }

        [TestMethod]
        [Description("Calling DoesNotContain on an ArrayList that does not contain the tested value should pass.")]
        public void CollectionDoesNotContainTest04()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            c.Requires().DoesNotContain((object)5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContain on an ArrayList that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest05()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            c.Requires().DoesNotContain((object)4);
        }

        #endregion // DoesNotContain

        #region ContainsAny

        // Calling ContainsAny on an array should compile.
        private void CollectionContainsAnyShouldCompileTest01()
        {
            int[] c = new int[1] { 1 };
            c.Requires().ContainsAny((IEnumerable<int>)c);
        }

        // Calling ContainsAny on a Collection should compile.
        private void CollectionContainsAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        // Calling ContainsAny on an IEnumerable should compile.
        private void CollectionContainsAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAnyTest07()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 1, 2, 3, 4 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionContainsAnyTest08()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 4, 5, 6, 7 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with a 'any' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAnyTest09()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 5, 6, 7, 8 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of the tested typed collection should pass.")]
        public void CollectionContainsAnyTest10()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new int[] { 4, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of the tested untyped collection should pass.")]
        public void CollectionContainsAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of different types of the tested untyped collection should pass.")]
        public void CollectionContainsAnyTest12()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList any = new ArrayList();
            any.Add(DayOfWeek.Friday);
            any.Add(2);

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of the tested typed collection should fail.")]
        public void CollectionContainsAnyTest13()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new int[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of the tested untyped collection should fail.")]
        public void CollectionContainsAnyTest14()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new int[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of different types of the tested untyped collection should fail.")]
        public void CollectionContainsAnyTest15()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList any = new ArrayList();
            any.Add(DayOfWeek.Saturday);
            any.Add(2);
            any.Add(new object());

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empty untyped collection should fail.")]
        public void CollectionContainsAnyTest16()
        {
            ArrayList c = new ArrayList();
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empy 'any' collection should fail.")]
        public void CollectionContainsAnyTest17()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList();
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an two collections that implement IEnumerable<T> but not IColletion<T> should pass.")]
        public void CollectionContainsAnyTest18()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            c.Requires().ContainsAny(c);
        }

        #endregion // ContainsAny

        #region DoesNotContainAny

        // Calling DoesNotContainAny on an array should compile.
        private void CollectionDoesNotContainAnyShouldCompileTest01()
        {
            int[] c = new int[1] { 1 };
            IEnumerable<int> any = new int[1] { 2 };
            c.Requires().DoesNotContainAny(any);
        }

        // Calling DoesNotContainAny on a Collection should compile.
        private void CollectionDoesNotContainAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Collection<int> any = new Collection<int> { 2 };
            c.Requires().DoesNotContainAny(any);
        }

        // Calling DoesNotContainAny on an IEnumerable should compile.
        private void CollectionDoesNotContainAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            int[] any = new int[1] { 2 };
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on a null collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on an empty collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on a filled collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on a null collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on an empty collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny on a filled collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().DoesNotContainAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAny with a 'any' collection containing all elements of the tested collection should fail.")]
        public void CollectionDoesNotContainAnyTest07()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 1, 2, 3, 4 };
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAny with a 'any' collection containing one element of the tested collection should fail.")]
        public void CollectionDoesNotContainAnyTest08()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 4, 5, 6, 7 };
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny with a 'any' collection containing no element of the tested collection should pass.")]
        public void CollectionDoesNotContainAnyTest09()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 5, 6, 7, 8 };
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing one element of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAnyTest10()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new int[] { 4, 5, 6, 8 });
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing one element of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing one element of different types of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAnyTest12()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList any = new ArrayList();
            any.Add(DayOfWeek.Friday);
            any.Add(2);

            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing no elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAnyTest13()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new int[] { 5, 6, 7, 8 });
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing no elements of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAnyTest14()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new int[] { 5, 6, 7, 8 });
            c.Requires().DoesNotContainAny(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAny with an untyped 'any' collection containing no elements of different types of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAnyTest15()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList any = new ArrayList();
            any.Add(DayOfWeek.Saturday);
            any.Add(2);
            any.Add(new object());

            c.Requires().DoesNotContainAny(any);
        }

        #endregion // DoesNotContainAny

        #region ContainsAll

        // Calling ContainsAll on an array should compile
        private void CollectionContainsAllShouldCompileTest01()
        {
            int[] c = new int[1] { 1 };
            c.Requires().ContainsAll((IEnumerable<int>)c);
        }

        // Calling ContainsAll on a Collection should compile
        private void CollectionContainsAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAll(c);
        }

        // Calling ContainsAll on an IEnumerable should compile
        private void CollectionContainsAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAll(c);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest01()
        {
            Collection<int> c = null;
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = null;
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a null collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest04()
        {
            Collection<int> c = null;
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on an empty collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll on a filled collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = new int[0];
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with a 'all' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAllTest07()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] all = new int[] { 1, 2, 3, 4 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing one element of the tested collection should fail.")]
        public void CollectionContainsAllTest08()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] all = new int[] { 4, 5, 6, 7 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAllTest09()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] all = new int[] { 5, 6, 7, 8 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested typed collection should pass.")]
        public void CollectionContainsAllTest10()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new int[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested untyped collection should pass.")]
        public void CollectionContainsAllTest11()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new int[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of different types of the tested untyped collection should pass.")]
        public void CollectionContainsAllTest12()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList all = new ArrayList();
            all.Add(DayOfWeek.Friday);
            all.Add(1);

            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of the tested typed collection should fail.")]
        public void CollectionContainsAllTest13()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new int[] { 4, 5, 6, 7 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing all elements of the tested untyped collection should fail.")]
        public void CollectionContainsAllTest14()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new int[] { 4, 5, 6, 7 });
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of different types of the tested untyped collection should fail.")]
        public void CollectionContainsAllTest15()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList all = new ArrayList();
            all.Add(DayOfWeek.Friday);
            all.Add(1);
            all.Add(new object());

            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll on an empty collection with an non empty 'all' collection should fail.")]
        public void CollectionContainsAllTest16()
        {
            Collection<int> c = new Collection<int>();
            int[] all = new int[] { 4, 5, 6, 7 };
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an empty untyped 'all' collection should pass.")]
        public void CollectionContainsAllTest17()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList();
            c.Requires().ContainsAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAll with an untyped 'all' on an empty collection should fail.")]
        public void CollectionContainsAllTest18()
        {
            ArrayList c = new ArrayList();
            ArrayList all = new ArrayList(new int[] { 1, 2, 3, 4 });
            c.Requires().ContainsAll(all);
        }

        #endregion // ContainsAll

        #region DoesNotContainAll

        // Calling DoesNotContainAll on an array should compile
        private void CollectionDoesNotContainAllShouldCompileTest01()
        {
            try
            {
                int[] c = new int[1] { 1 };
                IEnumerable<int> all = new int[1] { 2 };
                c.Requires().DoesNotContainAll(all);
            }
            catch
            {
                // We're only interested whether this code compiles.
            }
        }

        // Calling DoesNotContainAll on a Collection should compile
        private void CollectionDoesNotContainAllShouldCompileTest02()
        {
            try
            {
                Collection<int> c = new Collection<int> { 1 };
                Collection<int> all = new Collection<int> { 2 };
                c.Requires().DoesNotContainAll(all);
            }
            catch
            {
                // We're only interested whether this code compiles.
            }
        }

        // Calling DoesNotContainAll on an IEnumerable should compile
        private void CollectionDoesNotContainAllShouldCompileTest03()
        {
            try
            {
                IEnumerable<int> c = new Collection<int> { 1 };
                Collection<int> all = new Collection<int> { 2 };
                c.Requires().DoesNotContainAll(all);
            }
            catch
            {
                // We're only interested whether this code compiles.
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotContainAll on a null collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionDoesNotContainAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().DoesNotContainAll(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with a 'any' collection containing all elements of the tested collection should fail.")]
        public void CollectionDoesNotContainAllTest07()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 1, 2, 3, 4 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest08()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 4, 5, 6, 7 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with a 'any' collection containing no element of the tested collection should pass.")]
        public void CollectionDoesNotContainAllTest09()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            int[] any = new int[] { 5, 6, 7, 8 };
            c.Requires().DoesNotContainAll(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAllTest10()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new int[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAllTest11()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new int[] { 1, 2, 3, 4 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of different types of the tested untyped collection should fail.")]
        public void CollectionDoesNotContainAllTest12()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList all = new ArrayList();
            all.Add(DayOfWeek.Friday);
            all.Add(1);

            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing not all elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAllTest13()
        {
            int[] c = new int[] { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new int[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling DoesNotContainAll with an untyped 'all' collection containing all elements of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAllTest14()
        {
            ArrayList c = new ArrayList(new int[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new int[] { 4, 5, 6, 7 });
            c.Requires().DoesNotContainAll(all);
        }

        [TestMethod]
        [Description("Calling ContainsAll with an untyped 'all' collection containing not all elements of different types of the tested untyped collection should pass.")]
        public void CollectionDoesNotContainAllTest15()
        {
            ArrayList c = new ArrayList();
            c.Add(1);
            c.Add(DayOfWeek.Friday);
            c.Add(10.8D);

            ArrayList all = new ArrayList();
            all.Add(DayOfWeek.Friday);
            all.Add(1);
            all.Add(new object());

            c.Requires().DoesNotContainAll(all);
        }

        #endregion // DoesNotContainAll

        #region HasLength

        [TestMethod]
        [Description("Calling HasLength(0) with an untyped collection containing no elements should pass.")]
        public void CollectionHasLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            queue.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an typed collection containing no elements should pass.")]
        public void CollectionHasLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an untyped collection containing one element should pass.")]
        public void CollectionHasLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            queue.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an typed collection containing one element should pass.")]
        public void CollectionHasLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with a collection containing one element should fail.")]
        public void CollectionHasLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(1) with an ArrayList containing one element should fail.")]
        public void CollectionHasLengthTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an ArrayList containing no elements should pass.")]
        public void CollectionHasLengthTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) on a null reference should pass.")]
        public void CollectionHasLengthTest08()
        {
            IEnumerable list = null;

            list.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling HasLength(1) on a null reference should fail.")]
        public void CollectionHasLengthTest09()
        {
            IEnumerable list = null;

            list.Requires().HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionHasLengthTest10()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().HasLength(1);
        }

        #endregion // HasLength

        #region DoesNotHaveLength

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an untyped collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            queue.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an untyped collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            queue.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an typed collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().DoesNotHaveLength(1);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength(0) with a collection containing one element should pass.")]
        public void CollectionDoesNotHaveLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().DoesNotHaveLength(0);
        }

        #endregion // DoesNotHaveLength

        #region IsShorterThan

        [TestMethod]
        [Description("Calling IsShorterThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterThan(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(2) with a collection containing one element should pass.")]
        public void CollectionIsShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsShorterThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(1) with a collection containing one element should fail.")]
        public void CollectionIsShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(1) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsShorterThan(1) on a null reference should pass.")]
        public void CollectionIsShorterThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterThan(0) on a null reference should fail.")]
        public void CollectionIsShorterThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsShorterThan(0);
        }

        #endregion // IsShorterThan

        #region IsNotShorterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterThan(2) with a collection containing one element should fail.")]
        public void CollectionIsNotShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotShorterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(1) with a collection containing one element should pass.")]
        public void CollectionIsNotShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsNotShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(0) on a null reference should pass.")]
        public void CollectionIsNotShorterThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsNotShorterThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotShorterThan(1) on a null reference should fail.")]
        public void CollectionIsNotShorterThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsNotShorterThan(1);
        }

        #endregion // IsNotShorterThan

        #region IsShorterOrEqual

        [TestMethod]
        [Description("Calling IsShorterOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsShorterOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsShorterOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsShorterOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsShorterOrEqual(-1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) on a null reference should pass.")]
        public void CollectionIsShorterOrEqualTest08()
        {
            IEnumerable list = null;

            list.Requires().IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsShorterOrEqual(-1) on a null reference should fail.")]
        public void CollectionIsShorterOrEqualTest09()
        {
            IEnumerable list = null;

            list.Requires().IsShorterOrEqual(-1);
        }

        #endregion // IsShorterOrEqual

        #region IsNotShorterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(1) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(0) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(1) with a collection containing one element should fail.")]
        public void CollectionIsNotShorterOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(0) with a collection containing one element should pass.")]
        public void CollectionIsNotShorterOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) with an ArrayList containing no elements should pass.")]
        public void CollectionIsNotShorterOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(0) with an ArrayList containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) on a null reference should pass.")]
        public void CollectionIsNotShorterOrEqualTest08()
        {
            IEnumerable list = null;

            list.Requires().IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotShorterOrEqual(0) on a null reference should fail.")]
        public void CollectionIsNotShorterOrEqualTest09()
        {
            IEnumerable list = null;

            list.Requires().IsNotShorterOrEqual(0);
        }

        #endregion // IsNotShorterOrEqual

        #region IsLongerThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(1) with a collection containing two element should pass.")]
        public void CollectionIsLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>() { 1, 2 };

            set.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(2) with a collection containing two elements should fail.")]
        public void CollectionIsLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>() { 1, 2 };

            set.Requires().IsLongerThan(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(0) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsLongerThan(-1) on a null reference should pass.")]
        public void CollectionIsLongerThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerThan(0) on a null reference should fail.")]
        public void CollectionIsLongerThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsLongerThan(0);
        }

        #endregion // IsLongerThan

        #region IsNotLongerThan

        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(1) with a collection containing two element should fail.")]
        public void CollectionIsNotLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>() { 1, 2 };

            set.Requires().IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(2) with a collection containing two elements should pass.")]
        public void CollectionIsNotLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>() { 1, 2 };

            set.Requires().IsNotLongerThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsNotLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerThan(0) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsNotLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) on a null reference should pass.")]
        public void CollectionIsNotLongerThanTest08()
        {
            IEnumerable list = null;

            list.Requires().IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotLongerThan(-1) on a null reference should fail.")]
        public void CollectionIsNotLongerThanTest09()
        {
            IEnumerable list = null;

            list.Requires().IsNotLongerThan(-1);
        }

        #endregion // IsNotLongerThan

        #region IsLongerOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsLongerOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(0) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsLongerOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsLongerOrEqual(2) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsLongerOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsLongerOrEqual(0) on a null reference should pass.")]
        public void CollectionIsLongerOrEqualTest08()
        {
            IEnumerable list = null;

            list.Requires().IsLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsLongerOrEqual(1) on a null reference should fail.")]
        public void CollectionIsLongerOrEqualTest09()
        {
            IEnumerable list = null;

            list.Requires().IsLongerOrEqual(1);
        }

        #endregion // IsLongerOrEqual

        #region IsNotLongerOrEqual

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().IsNotLongerOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();
            set.Add(1);

            set.Requires().IsNotLongerOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotLongerOrEqual(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(2) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList() { 1 };

            list.Requires().IsNotLongerOrEqual(2);
        }

        [TestMethod]
        [Description("Calling IsNotLongerOrEqual(1) on a null reference should pass.")]
        public void CollectionIsNotLongerOrEqualTest08()
        {
            IEnumerable list = null;

            list.Requires().IsNotLongerOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling IsNotLongerOrEqual(0) on a null reference should fail.")]
        public void CollectionIsNotLongerOrEqualTest09()
        {
            IEnumerable list = null;

            list.Requires().IsNotLongerOrEqual(0);
        }

        #endregion // IsNotLongerOrEqual

        #region Helper Types and Methods

        private sealed class IsEmptyTestEnumerable : IEnumerable
        {
            private readonly bool empty;

            public IsEmptyTestEnumerable(bool thisCollectionIsEmpty)
            {
                this.empty = thisCollectionIsEmpty;
            }

            public IEnumerator GetEnumerator()
            {
                if (this.empty == true)
                {
                    yield break;
                }

                // Return one element
                yield return null;
            }
        }

        #endregion
    }
}