using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RobotVacuum.UnitTest
{
    class RobotTest
    {
        [Test]
        public void Test1()
        {
            var room = new Room(2);
            var robot = new Robot(room);
            robot.Do(Action.TurnRight);
            robot.Do(Action.GoForward);
            Assert.AreEqual(1, robot.CurrentRow);
            Assert.AreEqual(0, robot.CurrentCol);
        }
    }
}
