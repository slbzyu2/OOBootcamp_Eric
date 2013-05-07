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
    }
}
