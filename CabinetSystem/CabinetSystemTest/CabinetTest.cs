using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CabinetTest
    {
        public CabinetTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void test_should_has_empty_box()
        {
            var cabinet = new Cabinet();
            var hasEmptyBox = cabinet.HasEmptyBox();
            Assert.IsTrue(hasEmptyBox);
        }
        
        [TestMethod]
        public void test_Has_empty_box_and_store_bag_and_get_a_ticket()
        {
            var cabinet = new Cabinet();
            Ticket ticket = cabinet.Store(new Bag());
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void test_should_pick_bag_by_ticket()
        {
            var cabinet = new Cabinet();
            Bag bag = new Bag();
            Ticket ticket = cabinet.Store(bag);
            Assert.AreEqual(bag, cabinet.PickBag(ticket));
        }

        [TestMethod]
        public void test_should_pick_desired_bag_by_ticket()
        {
            var cabinet = new Cabinet();
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            Ticket ticket1 = cabinet.Store(bag1);
            Ticket ticket2 = cabinet.Store(bag2);
            Assert.AreEqual(bag1, cabinet.PickBag(ticket1));
            Assert.AreEqual(bag2, cabinet.PickBag(ticket2));
        }

        [TestMethod]
        public void test_pick_bag_by_obselete_ticket()
        {
            var cabinet = new Cabinet();
            Ticket ticket = cabinet.Store(new Bag());
            cabinet.PickBag(ticket);

            Assert.IsNull(cabinet.PickBag(ticket));
        }

        [TestMethod]
        public void test_should_return_null_when_picking_bag_by_invalid_ticket()
        {
            var cabinet = new Cabinet();
            cabinet.Store(new Bag());
            var pickBag = cabinet.PickBag(new Ticket());

            Assert.IsNull(pickBag);
        }


        [TestMethod]
        [ExpectedException(typeof(NonTicketException))]
        public void test_should_return_null_when_picking_bag_by_non_ticket()
        {
            var cabinet = new Cabinet();
            cabinet.Store(new Bag());
            cabinet.PickBag(new object() as Ticket);
        }


    }
}
