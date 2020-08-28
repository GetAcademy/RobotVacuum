namespace RobotVacuum
{
    public class Room
    {
        private bool[] _cellsVisited;

        public Room(int size)
        {
            Size = size;
            _cellsVisited = new bool[size * size];
        }

        public int Size { get; }

        public bool AllPartsHaveBeenVisited
        {
            get
            {
                foreach (var cellVisited in _cellsVisited)
                {
                    if (!cellVisited) return false;
                }
                return true;
                // return _cellsVisited.All(cellVisited => cellVisited);
            }
        }

        public bool SetVisitedAndReturnIsValid(int row, int col)
        {
            if (row < 0 || row >= Size || col < 0 || col >= Size) return false;
            var cellVisitedIndex = row * Size + col;
            _cellsVisited[cellVisitedIndex] = true;
            return true;
        }
    }
}
