using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotShorterOrEqual method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotShorterOrEqualTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(1) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(0) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(1) with a collection containing one element should fail.")]
        public void CollectionIsNotShorterOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsNotShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(0) with a collection containing one element should pass.")]
        public void CollectionIsNotShorterOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) with an ArrayList containing no elements should pass.")]
        public void CollectionIsNotShorterOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterOrEqual(0) with an ArrayList containing no elements should fail.")]
        public void CollectionIsNotShorterOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual(-1) on a null reference should pass.")]
        public void CollectionIsNotShorterOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterOrEqual(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsNotShorterOrEqual(0) on a null reference should fail.")]
        public void CollectionIsNotShorterOrEqualTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsNotShorterOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterOrEqual(-1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsNotShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionIsNotShorterOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotShorterOrEqual(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsNotShorterOrEqual(1) with a collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionIsNotShorterOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotShorterOrEqual(1);
        }
    }
}