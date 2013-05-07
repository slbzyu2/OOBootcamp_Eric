using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    [TestClass]
    public class SuperRobotTest
    {
        [TestMethod]
        public void test_superrobot_should_has_empty_box()
        {
            var superRobot = new SuperRobot();
            superRobot.Add(new Cabinet());

            Assert.IsTrue(superRobot.HasEmptyBox());
        }

        [TestMethod]
        public void test_superrobot_can_store_bag()
        {
            var superRobot = new SuperRobot();
            superRobot.Add(new Cabinet());

            var ticket = superRobot.Store(new Bag());
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void test_superrobot_can_store_bag_by_emptyboxrate()
        {
            var superRobot = new SuperRobot();
            var cabinet1 = new Cabinet(10);
            var cabinet2 = new Cabinet(8);

            cabinet1.Store(new Bag());
            cabinet1.Store(new Bag());
            cabinet1.Store(new Bag());

            cabinet2.Store(new Bag());
            cabinet2.Store(new Bag());

            superRobot.Add(cabinet1);
            superRobot.Add(cabinet2);

            superRobot.Store(new Bag());

            Assert.AreEqual(5, cabinet2.GetEmptyBoxCount());
        }
    }
}
