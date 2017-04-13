using System;

using Xunit;

namespace GridSearchTests
{
    public class DataGridProcessorTests
    {
        [Fact]
        public void DataGridProcessor_InstanceCreated()
        {
            DataGridProcessor _processor = new DataGridProcessor();
            Assert.NotNull(_processor);
        }



        [Fact]
        public void LoadFromFile()
        {
            string fileName = @"D:\GitHub\HackerRank\GridSearch\Data Files\DevInput4.txt";

            Console.SetIn(System.IO.File.OpenText(fileName));

            Console.ReadLine();

            string [] currentLine = Console.ReadLine().Split(new char[] {' '});

            int rows, cols;

            int.TryParse(currentLine[0], out rows);
            int.TryParse(currentLine[1], out cols);
            var grid = new Grid(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                grid.AddRow(Console.ReadLine());
            }

            currentLine = Console.ReadLine().Split(new char[] { ' ' });
            int.TryParse(currentLine[0], out rows);
            int.TryParse(currentLine[1], out cols);

            var searchGrid = new Grid(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                searchGrid.AddRow(Console.ReadLine());
            }
            DataGridProcessor _processor = new DataGridProcessor(grid, searchGrid);

            var result = _processor.Process();
            var formatedResult = result ? "YES" : "NO";
            Assert.NotNull(_processor);

            Assert.True(result);
            Assert.True(formatedResult.Equals("YES"));

        }


        [Fact]
        public void DataGridProcessor_AcceptsDataGridAndSearchGrid()
        {

            var grid = new Grid(10,10);

            grid.AddRow("7283455864");
            grid.AddRow("6731158619");
            grid.AddRow("8988242643");
            grid.AddRow("3830589324");
            grid.AddRow("2229505813");
            grid.AddRow("5633845374");
            grid.AddRow("6473530293");
            grid.AddRow("7053106601");
            grid.AddRow("0834282956");
            grid.AddRow("4607924137");
          
            var searchGrid = new Grid(3,4);

            searchGrid.AddRow("9505");
            searchGrid.AddRow("3845");
            searchGrid.AddRow("3530");

            DataGridProcessor _processor = new DataGridProcessor(grid, searchGrid);

            var result = _processor.Process();
            var formatedResult = result ? "YES" : "NO";
            Assert.NotNull(_processor);

            Assert.True(result);
            Assert.True(formatedResult.Equals("YES"));
        }
    }
}