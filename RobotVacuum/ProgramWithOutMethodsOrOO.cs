using System;
using System.Collections.Generic;
using System.Text;

namespace RobotVacuum
{
    class ProgramWithOutMethodsOrOO
    {
        static void MainX(string[] args)
        {
            var size = 2;
            var sequenceOfActions = new Action[7];
            while (true)
            {
                var currentRow = 0;
                var currentCol = 0;
                var currentDirection = Direction.East;
                var cellsVisited = new bool[size * size];
                //cellsVisited[0] = true;
                foreach (var action in sequenceOfActions)
                {
                    if (action == Action.GoForward)
                    {
                        if (currentDirection == Direction.East) currentCol++;
                        else if (currentDirection == Direction.West) currentCol--;
                        else if (currentDirection == Direction.North) currentRow--;
                        else if (currentDirection == Direction.South) currentRow++;
                        if (currentRow < 0 || currentRow >= size || currentCol < 0 || currentCol >= size)
                        {
                            break;
                        }
                        var cellVisitedIndex = currentRow * size + currentCol;
                        cellsVisited[cellVisitedIndex] = true;
                    }
                    else
                    {
                        var deltaDirection = action == Action.TurnLeft ? -1 : 1;
                        currentDirection = (Direction)(((int)currentDirection + deltaDirection) % 4);
                    }
                }

                var hasAllCellsBeenVisited = true;
                foreach (var cellVisited in cellsVisited)
                {
                    if (!cellVisited) hasAllCellsBeenVisited = false;
                }
                if (currentCol == 0 && currentRow == 0 && hasAllCellsBeenVisited)
                {
                    Console.WriteLine();
                    foreach (var action in sequenceOfActions)
                    {
                        Console.WriteLine(action.ToString());
                    }
                    return;
                }
                Console.Write(".");
                int i;
                for (i = sequenceOfActions.Length - 1; i >= 0; i--)
                {
                    var actionInt = (int)sequenceOfActions[i];
                    if (actionInt < 2)
                    {
                        sequenceOfActions[i]++;
                        break;
                    }
                    sequenceOfActions[i] = 0;
                }

                if (i == -1)
                {
                    Console.WriteLine("Fant ingen løsning.");
                    return;
                }
            }
        }
    }
}
