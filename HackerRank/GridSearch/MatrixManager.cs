using System.IO;

namespace ConsoleApp1
{
    public class MatrixManager
    {
        private StreamReader _fileReader;
        private int _totalTests;
        private int[,] matrix;
        private int[,] tempMatrix;
        private int[,] searchMatrix;

        public MatrixManager(StreamReader fileReader)
        {
            _fileReader = fileReader;
        }


        public void Process()
        {
            using (_fileReader)
            {
                int.TryParse(_fileReader.ReadLine(), out _totalTests);

                for (int testCounter = 0; testCounter < _totalTests; testCounter++)
                {
                    matrix = GetMatrixData();
                    searchMatrix = GetMatrixData();
                    tempMatrix = new int[searchMatrix.GetLength(0), searchMatrix.GetLength(1)];

                }
            }
        }

        private int[,] GetMatrixData()
        {
            int matrixRowSize;
            int matrixColSize;

            matrixRowSize = GetDimensions(out matrixColSize);

            int[,] matrix = new int[matrixRowSize, matrixColSize];

            for (int row = 0; row < matrixRowSize; row++)
            {
                string currentLine = _fileReader.ReadLine();
                AddColumns(currentLine, matrix, row);
            }
            return matrix;
        }

        private int GetDimensions(out int matrixColSize)
        {
            int matrixRowSize;
            string[] dimensions = _fileReader.ReadLine().Split(new char[] {' '});
            int.TryParse(dimensions[0], out matrixRowSize);
            int.TryParse(dimensions[1], out matrixColSize);
            return matrixRowSize;
        }

        private static void AddColumns(string currentLine, int[,] matrix, int row)
        {
            for (int col = 0; col < currentLine.Length; col++)
            {
                int currentValue;
                int.TryParse(currentLine.Substring(col, 1).ToString(), out currentValue);
                matrix[row, col] = currentValue;
            }
        }
    }
}