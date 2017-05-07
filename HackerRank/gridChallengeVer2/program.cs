using System;

namespace Constructix
{
    public static class ConsoleMain
    {
        public static void Main()
        {
            Console.WriteLine("Grid Challenge");

            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 6, 7, 8, 9 } };
            int[,] searchMatrix = new int[,] { { 3, 4 }, { 8, 9 } };

            // PrintMatrix(matrix);
            // Console.WriteLine();
            // PrintMatrix(searchMatrix);

            int rowIncrement = searchMatrix.GetLength(0);
            int colIncrement = searchMatrix.GetLength(1);
            // get chunk of data and put into temp matrix

            int[,] tempMatrix = new int[rowIncrement, colIncrement];

            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j += 2)
                {
                    Console.WriteLine($"{matrix[i, j]}");
                }
            }
            Console.WriteLine("End of Looping");

            Console.WriteLine("TempMatrix is ");
            Console.WriteLine($"IsMatch = {IsMatch(tempMatrix, searchMatrix)}");
            Console.WriteLine();
            PrintMatrix(tempMatrix);
        }

        public static bool IsMatch(int[,] matrix, int[,] searchMatrix)
        {
            int totalRows = searchMatrix.GetLength(0);
            int totalCols = searchMatrix.GetLength(1);

            int count = 0;

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    if (matrix[row, col] == searchMatrix[row, col])
                    {
                        count++;
                        Console.Write($"{matrix[row, col]} ");
                    }
                    else
                    {
                        count--;
                    }
                }
                Console.WriteLine();
            }
            return count == (searchMatrix.GetLength(0) * searchMatrix.GetLength(1));
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write($"{matrix[x, y]}");
                }

                Console.WriteLine();
            }
        }
    }
}