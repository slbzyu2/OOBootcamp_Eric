using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    /// <summary>
    /// Summary description for SmartRobot
    /// </summary>
    [TestClass]
    public class SmartRobotTest
    {
        public SmartRobotTest()
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
        public void test_smartrobot_should_has_empty_box()
        {
            var srb = new SmartRobot();
            srb.Add(new Cabinet());

            Assert.IsTrue(srb.HasEmptyBox());
        }

        [TestMethod]
        public void test_smartrobot_can_store_bag()
        {
            var srb = new SmartRobot();
            srb.Add(new Cabinet());

            var ticket = srb.Store(new Bag());
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void test_smartrobot_get_empty_box_count()
        {
            var srb = new SmartRobot();
            var cabinet = new Cabinet(1);
            srb.Add(cabinet);

            Assert.AreEqual(1, cabinet.GetEmptyBoxCount());
        }


        [TestMethod]
        public void test_smartrobot_can_store_bag_by_order()
        {
            var srb = new SmartRobot();
            var cabinet = new Cabinet(3);
            srb.Add(cabinet);
            srb.Add(new Cabinet(1));
            srb.Store(new Bag());

            Assert.AreEqual(2, cabinet.GetEmptyBoxCount());
        }
    }
}
