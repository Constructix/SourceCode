using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
            Console.SetIn(System.IO.File.OpenText(args[0]));
        int totalTestCases = GetTestCases();
        for (int testCaseIndex = 0; testCaseIndex < totalTestCases; testCaseIndex++)
        {

            try
            {
                int[,] matrix = GetMatrix();
                int[,] search = GetMatrix();
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

                    Console.WriteLine(isValid ? "YES" : "NO");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NO");
            }
        }
}

    private static int[,] GetMatrix()
    {
        string[] RowsAndColsInput = Console.ReadLine().Split(' ');
        int totalRows;
        int totalCols;

        int.TryParse(RowsAndColsInput[0], out totalRows);
        int.TryParse(RowsAndColsInput[1], out totalCols);
        string[] grid = new string[totalRows];
        for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
        {
            grid[rowIndex] = Console.ReadLine();
        }

        
            int[,] matrix = new int[totalRows, totalCols];
            for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++)
            {
                string currentLine = grid[rowIndex];
                for (int y = 0; y < currentLine.Length; y++)
                {
                    int currentValue;
                    int.TryParse(currentLine[y].ToString(), out currentValue);
                    matrix[rowIndex, y] = currentValue;
                }
            }
            return matrix;
        
    }

    private static int GetTestCases()
    {
        int testCases;
        int.TryParse(Console.ReadLine(), out testCases);
        return testCases;
    }

    private static void Prescan(int[,] matrix, int[,] search, List<Position> _positions)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == search[0, 0])
                {
                    _positions.Add(new Position { Row = row, Col = col });
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