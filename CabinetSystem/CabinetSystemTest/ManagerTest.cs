using System;
using System.Text;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    /// <summary>
    /// Summary description for ManagerTest
    /// </summary>
    [TestClass]
    public class ManagerTest
    {
        public ManagerTest()
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
        public void TestManagerShouldHaveEmptyBoxGivenManagerHasOneCabinet()
        {
            var manager = new Manager();
            manager.Add(new Cabinet());

            Assert.IsTrue(manager.HasEmptyBox());
        }

        [TestMethod]
        public void TestManagerShouldHaveEmptyBoxGivenManagerHasOneRobotAndOneCabinet()
        {
            var manager = new Manager();
            var robot = new Robot();
            var cabinet = new Cabinet();
            robot.Add(cabinet);
            manager.Add(robot);

            Assert.IsTrue(manager.HasEmptyBox());
        }

        [TestMethod]
        public void TestManagerCouldStoreBoxGivenManagerHasOneRobotAndOneCabinet()
        {
            var manager = new Manager();
            var robot = new Robot();
            var cabinet = new Cabinet();
            robot.Add(cabinet);
            manager.Add(robot);

            var ticket = manager.Store(new Bag(), true);
            Assert.IsNotNull(ticket);
        }


        [TestMethod]
        public void TestManagerCouldPickBoxStoredFromManagerGivenManagerStoreBoxIntoCabinet()
        {
            var manager = new Manager();
            var cabinet = new Cabinet();
            manager.Add(cabinet);
            var bag = new Bag();
            var ticket = manager.Store(bag, false);
            var returnBag = manager.PickBag(ticket, false);
            Assert.AreEqual(bag, returnBag);
        }

        [TestMethod]
        public void TestManagerCouldGetEmptyBoxCountGivenManagerStoreBoxIntoCabinet()
        {
            var manager = new Manager();
            var cabinet1 = new Cabinet(10);
            var cabinet2 = new Cabinet(10);
            manager.Add(cabinet1);
            manager.Add(cabinet2);
            manager.Store(new Bag(), false);
            Assert.AreEqual(19,manager.GetEmptyBoxCount());
        }


    }
}
