using System;

namespace GridSearchTests
{
    public class Grid
    {

        private int[,] _internalGrid;
        private int _rowsAllocated = 0;

        public Grid()
        {
        }

        public Grid(int rows, int columns)
        {
            _internalGrid = new int[rows, columns];
        }

        public int this[int index, int columnIndex]
        {
            get { return _internalGrid[index, columnIndex]; }
            set { _internalGrid[index, columnIndex] = value; }

        }

        public void AddRow(string testInputValue)
        {
            int newIntValue = 0;


            Validate(testInputValue);

            for (int index = 0; index < _internalGrid.GetLength(1); index++) { 
                if (int.TryParse(testInputValue.Substring(index, 1), out newIntValue))
                {
                    _internalGrid[_rowsAllocated, index] = newIntValue;
                }
            }

            ++_rowsAllocated;
        }

        private void Validate(string testInputValue)
        {
            if (_rowsAllocated >= _internalGrid.GetLength(0))
                throw new Exception("Tryin to add a row that is larger than Row length.");

            if (testInputValue.Length > _internalGrid.GetLength(1))
                throw new Exception("Trying to add column that is larger than the column length.");
        }
    }
}