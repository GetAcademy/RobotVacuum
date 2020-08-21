using System;
using System.Collections.Generic;
using System.Text;

namespace RobotVacuum
{
    class Robot
    {
        public int currentRow = 0;
        public int currentCol = 0;
        public Direction currentDirection = Direction.East;

        public bool Do(Action action, int size, bool[] cellsVisited)
        {
            if (action == Action.GoForward)
            {
                if (currentDirection == Direction.East) currentCol++;
                else if (currentDirection == Direction.West) currentCol--;
                else if (currentDirection == Direction.North) currentRow--;
                else if (currentDirection == Direction.South) currentRow++;
                if (currentRow < 0 || currentRow >= size || currentCol < 0 || currentCol >= size)
                {
                    return false;
                }
                var cellVisitedIndex = currentRow * size + currentCol;
                cellsVisited[cellVisitedIndex] = true;
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
