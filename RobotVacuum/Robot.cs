using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace RobotVacuum
{
    public class Robot
    {
        public int CurrentRow { get; private set; }
        public int CurrentCol { get; private set; }
        public Direction currentDirection = Direction.East;
        private Room _room;

        public Robot(Room room)
        {
            _room = room;
        }

        public bool Do(Action action)
        {
            if (action == Action.GoForward)
            {
                if (currentDirection == Direction.East) CurrentCol++;
                else if (currentDirection == Direction.West) CurrentCol--;
                else if (currentDirection == Direction.North) CurrentRow--;
                else if (currentDirection == Direction.South) CurrentRow++;
                if (!_room.SetVisitedAndReturnIsValid(CurrentRow, CurrentCol)) return false;
            }
            else
            {
                var deltaDirection = action == Action.TurnLeft ? -1 : 1;
                currentDirection = (Direction)(((int)currentDirection + deltaDirection) % 4);
            }

            return true;
        }
    }
}
