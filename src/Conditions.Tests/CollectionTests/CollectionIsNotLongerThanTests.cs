using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotLongerThan method.
    /// </summary>
    [TestClass]
    public class CollectionIsNotLongerThanTests
    {
        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotLongerThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotLongerThan(1) with a collection containing two element should fail.")]
        public void CollectionIsNotLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1, 2};

            Condition.Requires(set).IsNotLongerThan(1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(2) with a collection containing two elements should pass.")]
        public void CollectionIsNotLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1, 2};

            Condition.Requires(set).IsNotLongerThan(2);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList {1};

            Condition.Requires(list).IsNotLongerThan(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsNotLongerThan(0) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList {1};

            Condition.Requires(list).IsNotLongerThan(0);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan(0) on a null reference should pass.")]
        public void CollectionIsNotLongerThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsNotLongerThan(-1) on a null reference should fail.")]
        public void CollectionIsNotLongerThanTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(-1);
        }

        [TestMethod]
        [Description("Calling IsNotLongerThan with the condtionDescription parameter should pass.")]
        public void CollectionIsNotLongerThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsNotLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionIsNotLongerThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotLongerThan(-1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsNotLongerThan(-1) with a collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionIsNotLongerThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotLongerThan(-1);
        }
    }
}