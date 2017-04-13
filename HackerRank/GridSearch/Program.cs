using System;
using System.IO;
using System.Text;

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
            StringBuilder currentText = new StringBuilder();

            string[] tokens_R = Console.ReadLine().Split(' ');
            int totalRows = Convert.ToInt32(tokens_R[0]);
            int TotalColumns = Convert.ToInt32(tokens_R[1]);

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
}