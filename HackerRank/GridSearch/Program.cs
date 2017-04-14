using System;
using System.IO;

//https://www.hackerrank.com/challenges/the-grid-search

class Solution
{
    static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            Console.SetIn(File.OpenText(args[0]));
        }

        int tests = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < tests; a0++)
        {
            string[] tokens_R = Console.ReadLine().Split(' ');
            int totalRows = Convert.ToInt32(tokens_R[0]);
            int totalColumns = Convert.ToInt32(tokens_R[1]);
            

            Grid dataGrid = new Grid(totalRows, totalColumns);

            for (int index = 0; index < totalRows; index++)
            {
                dataGrid.AddRow(Console.ReadLine());
            }

            string[] tokens_r = Console.ReadLine().Split(' ');
            int searchGridRows = Convert.ToInt32(tokens_r[0]);
            int searchGridCols = Convert.ToInt32(tokens_r[1]);

            Grid searchGrid = new Grid(searchGridRows, searchGridCols);
            for (int i = 0; i < searchGridRows; i++)
            {
                searchGrid.AddRow(Console.ReadLine());
            }

            // [0,0] [0,1]
            // [1,0] [1,1]


            var dataGridProcessor = new DataGridProcessor(grid: dataGrid, searchGrid: searchGrid);

            Console.WriteLine(dataGridProcessor.Process() ? "YES" : "NO");



        }
    }

    private static void UseStringDemo(int totalRows, string[] searchGrid, string[] dataGrid, int r)
    {
        int previousRowFoundPos = -1;
        int previousRowIndex = -1;
        int previousColIndex = -1;
        int currentSearchGridRow = 0;
        int found = 0;
        bool foundPattern = false;
        for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
        {
            if (currentSearchGridRow < searchGrid.GetLength(0))
            {
                int resultPosition = dataGrid[rowIndex].IndexOf(searchGrid[currentSearchGridRow], StringComparison.Ordinal);

                if (resultPosition >= 0 && previousColIndex == -1)
                    previousColIndex = resultPosition;

                if ((resultPosition >= 0 && previousColIndex == resultPosition) &&
                    ((previousRowIndex == -1) || (rowIndex - previousRowIndex <= 1)))
                {
                    found++;
                    currentSearchGridRow++;
                    previousRowIndex = rowIndex;
                    if (found == r)
                    {
                        foundPattern = true;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(foundPattern ? "YES" : "NO");
    }

    private static void GridWithIntegers(int totalRows, int TotalColumns)
    {
        Grid dataGrid = new Grid(totalRows, TotalColumns);

        for (int i = 0; i < totalRows; i++)
        {
            dataGrid.AddRow(Console.ReadLine());
        }


        string[] tokens_r = Console.ReadLine().Split(' ');
        int r = Convert.ToInt32(tokens_r[0]);
        int c = Convert.ToInt32(tokens_r[1]);

        Grid SearchGrid = new Grid(r, c);

        for (int i = 0; i < r; i++)
        {
            SearchGrid.AddRow(Console.ReadLine());
        }

        var dataGridProcessor = new DataGridProcessor(grid: dataGrid, searchGrid: SearchGrid);

        Console.WriteLine(dataGridProcessor.Process() ? "YES" : "NO");
    }
}