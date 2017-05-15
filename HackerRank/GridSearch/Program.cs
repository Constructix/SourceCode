using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    
    public static void Main(string [] args)
    {
        if (args.Length > 0)
        {
            Console.SetIn(System.IO.File.OpenText(args[0]));
        }
        int totalTests;
        int.TryParse(Console.ReadLine(), out totalTests);

        string[] matrixString;
        string[] searchPatternMatrixString;
        for (int test = 0; test < totalTests; test++)
        {

            var currentLine = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(currentLine))
            {
                string[] matrixDimensions = currentLine.Split(new char[] {' '});

                int totalMatrixRows;
                int totalMatrixCols;

                if (int.TryParse(matrixDimensions[0], out totalMatrixRows) &&
                    int.TryParse(matrixDimensions[1], out totalMatrixCols))
                {
                    matrixString = GetInput(totalMatrixRows);

                    searchPatternMatrixString = Console.ReadLine().Split(new char[] {' '});

                    GetSearchInput(searchPatternMatrixString);
                    // convert input into int matrix
                    // convert  searcharray into int matrix
                    int[,] matrix = ConvertMatrixToInt(matrixString);
                    int[,] search = ConvertMatrixToInt(searchPatternMatrixString);
                    int[,] temp  = new int[search.GetLength(0),search.GetLength(1)];

                    //int[,] matrix = new int[,] {    { 2, 1, 1, 1, 1, 2, 3, 4 },
                    //    { 5, 6, 7, 8, 5, 6, 7, 8 },
                    //    { 2, 2, 2, 2, 2, 2, 2, 2 } };


                    //int[,] search = new int[,] { { 2, 3, 4 }, { 6, 7, 8 }, { 2, 2, 2 } };
                    //int[,] temp = new int[search.GetLength(0), search.GetLength(1)];


                    var positions = Prescan(matrix, search);

                    if (positions.Any())
                    {
                        int startCol = 0;
                        temp = new int[search.GetLength(0), search.GetLength(1)];
                        bool isValid = false;
                        int index = 0;
                        while (index < positions.Count)
                        {
                            var currentPosition = positions[index];
                            int startRow = currentPosition.Row;
                            startCol = currentPosition.Col;

                            int curentRow = 0;
                            int currentCol = 0;

                            while (curentRow < search.GetLength(0))
                            {
                                while (currentCol < search.GetLength(1))
                                {
                                    if (startRow < matrix.GetLength(0) && startCol < matrix.GetLength(1))
                                    {
                                        temp[curentRow, currentCol] = matrix[startRow, startCol];

                                    }
                                    currentCol++;
                                    startCol++;
                                }

                                startRow++;
                                startCol = currentPosition.Col;
                                currentCol = 0;
                                curentRow++;
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
        }


       
        }
    }

    private static void GetSearchInput(string[] searchPatternMatrixString)
    {
        int totalSearchMatrixRows;
        int totalSearchMatrixCols;

        int.TryParse(searchPatternMatrixString[0], out totalSearchMatrixRows);
        int.TryParse(searchPatternMatrixString[1], out totalSearchMatrixCols);

        string[] searchPatternMatrix = new string[totalSearchMatrixRows];
        for (int currentRow = 0; currentRow < totalSearchMatrixRows; currentRow++)
        {
            searchPatternMatrix[currentRow] = Console.ReadLine();
        }
    }

    private static string[] GetInput(int totalMatrixRows)
    {
        string[] matrixString;
        matrixString = new string[totalMatrixRows];

        for (int currentRow = 0; currentRow < totalMatrixRows; currentRow++)
        {
            matrixString[currentRow] = Console.ReadLine();
        }
        return matrixString;
    }

    private static int[,] ConvertMatrixToInt(string[] matrixString)
    {
        int [,] matrix = new int[matrixString.GetLength(0), matrixString[0].Length];

        for (int index = 0; index < matrixString.GetLength(0); index++)
        {
            for (int charIndex = 0; charIndex < matrixString[index].Length; charIndex++)
            {
                int newNumber;
                int.TryParse(matrixString[0].Substring(charIndex,1).ToString(), out newNumber);
                matrix[index, charIndex] = newNumber;
            }
        }
        return matrix;
    }

    private static List<Position> Prescan(int[,] matrix, int[,] search)
    {
        List<Position> _positions = new List<Position>();
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
        return _positions;
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