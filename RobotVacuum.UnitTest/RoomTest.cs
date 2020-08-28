using NUnit.Framework;

namespace RobotVacuum.UnitTest
{
    public class RoomTest
    {
        [Test]
        public void TestSize()
        {
            var room = new Room(5);
            Assert.AreEqual(5, room.Size);
        }

        [Test]
        public void TestVisited()
        {
            var room = new Room(1);
            room.SetVisitedAndReturnIsValid(0, 0);
            Assert.IsTrue(room.AllPartsHaveBeenVisited);
            //Assert.AreEqual(5, room.Size);
        }

        [Test]
        public void TestVisited2()
        {
            var room = new Room(2);
            room.SetVisitedAndReturnIsValid(0, 0);
            room.SetVisitedAndReturnIsValid(0, 1);
            room.SetVisitedAndReturnIsValid(1, 0);
            room.SetVisitedAndReturnIsValid(1, 1);
            Assert.IsTrue(room.AllPartsHaveBeenVisited);
        }
    }
}