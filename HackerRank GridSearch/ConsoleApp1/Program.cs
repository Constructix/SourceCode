using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[,] matrix = new int[,] { { 2, 1, 1, 1, 1, 1, 3, 4 }, { 5, 6, 7, 8, 5, 6, 7, 8 }, { 2, 2, 2, 2, 2, 2, 2, 2 } };
        int[,] search = new int[,] { { 2, 3, 4 }, { 6, 7, 8 }, { 2, 2, 2 } };
        int[,] temp = new int[search.GetLength(0), search.GetLength(1)];


        List<Position> _positions = new List<Position>();
        // prescan
        Prescan(matrix, search, _positions);

        if (_positions.Any())
        {
            int startCol = 0;
            temp = new int[search.GetLength(0), search.GetLength(1)];
            bool isValid = false;
            int index = 0;
            while (index < _positions.Count)
            {
                var currentPosition = _positions[index];
                int startRow = currentPosition.Row;
                startCol = currentPosition.Col;

                int currentX = 0;
                int currentY = 0;

                while (currentX < search.GetLength(0))
                {
                    while (currentY < search.GetLength(1))
                    {
                        if (startRow < matrix.GetLength(0) && startCol < matrix.GetLength(1))
                        {
                            temp[currentX, currentY] = matrix[startRow, startCol];
                            
                        }
                        currentY++;
                        startCol++;
                    }

                    startRow++;
                    startCol = currentPosition.Col;
                    currentY = 0;
                    currentX++;
                }
                isValid = IsValid(search, temp);
                if (!isValid)
                    index++;
                else
                    break;

            }

            Console.WriteLine(isValid);
        }
    }

    private static void Prescan(int[,] matrix, int[,] search, List<Position> _positions)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == search[0, 0])
                {
                    _positions.Add(new Position {Row = row, Col = col});
                }
            }
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                Console.Write(matrix[x, y]);
            }
            Console.WriteLine();
        }

    }

    public static bool IsValid(int[,] search, int[,] temp)
    {
        bool isValid = true;

        for (int x = 0; x < temp.GetLength(0); x++)
        {
            for (int y = 0; y < temp.GetLength(1); y++)
            {
                if (search[x, y] != temp[x, y])
                {
                    isValid = false;
                    return isValid;
                }
            }
        }
        return isValid;
    }



}

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

}