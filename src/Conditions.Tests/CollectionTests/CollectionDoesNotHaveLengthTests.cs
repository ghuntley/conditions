using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    [TestClass]
    public class CollectionDoesNotHaveLengthTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an non-generic collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            Condition.Requires(queue).DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).DoesNotHaveLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an non-generic collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            Condition.Requires(queue).DoesNotHaveLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [Description("Calling DoesNotHaveLength(1) with an typed collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).DoesNotHaveLength(1);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength(0) with a collection containing one element should pass.")]
        public void CollectionDoesNotHaveLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> {1};

            Condition.Requires(set).DoesNotHaveLength(0);
        }

        [TestMethod]
        [Description("Calling DoesNotHaveLength with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotHaveLengthTest06()
        {
            IEnumerable list = null;

            Condition.Requires(list).DoesNotHaveLength(1, string.Empty);
        }

        [TestMethod]
        [Description(
            "Calling a failing DoesNotHaveLength should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionDoesNotHaveLengthTest07()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").DoesNotHaveLength(0, "the given {0} should not have 0 elements");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("the given list should not have 0 elements"));
            }
        }

        [TestMethod]
        [Description(
            "Calling DoesNotHaveLength(0) with an non-generic collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionDoesNotHaveLengthTest08()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            Condition.Requires(queue).SuppressExceptionsForTest().DoesNotHaveLength(0);
        }
    }
}