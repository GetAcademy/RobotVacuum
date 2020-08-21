using System;

namespace RobotVacuum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 2;
            var sequenceOfActions = new Action[7];
            while (true)
            {
                var robot = new Robot();
                var cellsVisited = new bool[size * size];
                //cellsVisited[0] = true;
                foreach (var action in sequenceOfActions)
                {
                    var isSuccess = robot.Do(action, size, cellsVisited);
                    if (!isSuccess) break;
                }

                var hasAllCellsBeenVisited = true;
                foreach (var cellVisited in cellsVisited)
                {
                    if (!cellVisited) hasAllCellsBeenVisited = false;
                }
                if (robot.currentCol == 0 && robot.currentRow == 0 && hasAllCellsBeenVisited)
                {
                    ShowSequenceOfAcions(sequenceOfActions);
                    return;
                }
                Console.Write(".");
                var isFinished = GoToNextSequenceOfAction(sequenceOfActions);
                if (isFinished)
                {
                    Console.WriteLine("Fant ingen løsning.");
                    return;
                }
            }
        }

        private static void ShowSequenceOfAcions(Action[] sequenceOfActions)
        {
            Console.WriteLine();
            foreach (var action in sequenceOfActions)
            {
                Console.WriteLine(action.ToString());
            }
        }

        private static bool GoToNextSequenceOfAction(Action[] sequenceOfActions)
        {
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

            var isFinished = i == -1;
            return isFinished;
        }
    }
}
