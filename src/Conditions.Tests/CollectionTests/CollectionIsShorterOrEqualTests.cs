using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    [TestClass]
    public class CollectionIsShorterOrEqualTests
    {
        [TestMethod]
        [Description("Calling IsShorterOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterOrEqual(1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsShorterOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsShorterOrEqual(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsShorterOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling IsShorterOrEqual(-1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsShorterOrEqual(0);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual(0) on a null reference should pass.")]
        public void CollectionIsShorterOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterOrEqual(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        [Description("Calling IsShorterOrEqual(-1) on a null reference should fail.")]
        public void CollectionIsShorterOrEqualTest09()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterOrEqual(-1);
        }

        [TestMethod]
        [Description("Calling IsShorterOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsShorterOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterOrEqual(0, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionIsShorterOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsShorterOrEqual(-1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc list def"));
            }
        }

        [TestMethod]
        [Description(
            "Calling IsShorterOrEqual(-1) with a collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionIsShorterOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsShorterOrEqual(-1);
        }
    }
}