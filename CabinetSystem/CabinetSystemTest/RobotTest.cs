using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    /// <summary>
    /// Summary description for RobotTest
    /// </summary>
    [TestClass]
    public class RobotTest
    {
        public RobotTest()
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
        public void test_should_robot_return_empty_box_when_has_empty_box()
        {
            var rb = new Robot();
            rb.Add(new Cabinet());
            rb.Add(new Cabinet());

            Assert.IsTrue(rb.HasEmptyBox());
        }

        [TestMethod]
        public void test_should_robot_save_bag_when_has_empty_box()
        {
            var rb = new Robot();
            rb.Add(new Cabinet());
            rb.Add(new Cabinet());

            Assert.IsTrue(rb.HasEmptyBox());

            var t1 = rb.StoreBag(new Bag());
            Assert.IsNotNull(t1);
        }

        [TestMethod]
        public void test_should_robot_save_bag_sequentially_when_has_empty_box()
        {
            var rb = new Robot();
            var cabinet1 = new Cabinet(2);
            rb.Add(cabinet1);
            rb.Add(new Cabinet(2));
            rb.StoreBag(new Bag());
            rb.StoreBag(new Bag());
            Assert.IsFalse(cabinet1.HasEmptyBox());
        }

        [TestMethod]
        public void test_should_robot_save_bag_sequentially_when_nonrobot_save_bag_first()
        {
            var rb = new Robot();
            var cabinet1 = new Cabinet(2);
            rb.Add(cabinet1);
            var cabinet2 = new Cabinet(2);
            rb.Add(cabinet2);
            cabinet1.Store(new Bag());
            cabinet2.Store(new Bag());
            rb.StoreBag(new Bag());
            Assert.IsFalse(cabinet1.HasEmptyBox());
        }

    }
}
