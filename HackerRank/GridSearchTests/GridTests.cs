using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GridSearchTests
{
    public class GridTests
    {
        [Fact]
        public void GridInstanceCreate()
        {
            var Grid = new Grid(10, 10);
            Assert.NotNull(Grid);
        }


        [Fact]
        public void Grid_InitialiseSetValue()
        {
            var Grid = new Grid(1, 1);
            Grid[0, 0] = 10;
            Assert.Equal(10, Grid[0, 0]);
        }

        [Fact]
        public void DataTable()
        {
            var dataGrid = new Grid(1, 10);

            string testRow = "7283455864";

            int currentValue;
            int.TryParse(testRow.Substring(0, 1), out currentValue);
            dataGrid[0, 0] = currentValue;

            Assert.True(dataGrid[0, 0] == 7);
        }

        [Fact]
        public void DataTable_LastDigitIsFour()
        {
            var dataGrid = new Grid(1, 10);

            string testRow = "7283455864";

            int currentValue;
            int.TryParse(testRow.Substring(9, 1), out currentValue);
            dataGrid[0, 9] = currentValue;

            Assert.True(dataGrid[0, 9] == 4);
        }


        [Fact]
        public void DataTable_ConvertRowToArrayOfInts()
        {
            var testInputValue = "7283455864";
            var testSecondColumnValue = "6731158619";
            var expectedValues = new int[2, 10] {{7, 2, 8, 3, 4, 5, 5, 8, 6, 4}, 
                                                 {6, 7, 3, 1, 1, 5, 8, 6, 1, 9}};


            var DataGrid = new Grid(2, 10);
            DataGrid.AddRow(testInputValue);
            DataGrid.AddRow(testSecondColumnValue);
            for (int rowIndex = 0; rowIndex < 2; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 10; columnIndex++)
                {
                    Assert.True(DataGrid[rowIndex, columnIndex] == expectedValues[rowIndex, columnIndex]);
                }
            }

        }

        [Fact]
        public void DataTable_SearchTable()
        {
            var firstRowInputValue = "9505";
            var secondRowInputValue = "3845";
            var thirRow = "3530";

            var expectedValues = new int[3, 4] {{9, 5, 0, 5}, {3, 8, 4, 5}, {3, 5, 3, 0}};

            var searchPatternGrid = new Grid(3,4);

            searchPatternGrid.AddRow(firstRowInputValue);
            searchPatternGrid.AddRow(secondRowInputValue);
            searchPatternGrid.AddRow(thirRow);

            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    Assert.True(searchPatternGrid[rowIndex, columnIndex] == expectedValues[rowIndex, columnIndex]);
                }
            }
        }



}
}
