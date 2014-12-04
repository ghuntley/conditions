using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotShorterThan method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotShorterThanTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterThan(0);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterThan(2) with a collection containing one element should fail.")]
        public void CollectionIsNotShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsNotShorterThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(1) with a collection containing one element should pass.")]
        public void CollectionIsNotShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList {1};

            Condition.Requires(list).IsNotShorterThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan(0) on a null reference should pass.")]
        public void CollectionIsNotShorterThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsNotShorterThan(1) on a null reference should fail.")]
        public void CollectionIsNotShorterThanTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotShorterThan with the condtionDescription parameter should pass.")]
        public void CollectionIsNotShorterThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterThan(-1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsNotShorterThan should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionIsNotShorterThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotShorterThan(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsNotShorterThan(1) with a collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionIsNotShorterThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotShorterThan(1);
        }
    }
}