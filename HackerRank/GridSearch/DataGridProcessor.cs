
    using System;

public class DataGridProcessor
    {
        private Grid grid;
        private Grid searchGrid;

        
        public DataGridProcessor()
        {
        }

        public DataGridProcessor(Grid grid, Grid searchGrid)
        {
            this.grid = grid;
            this.searchGrid = searchGrid;
        }


        

        public bool Process()
        {
            int rowIncrement = searchGrid.Rows;
            int colIncrement = searchGrid.Columns;

            for (int rowIndex = 0; rowIndex <= grid.Rows / searchGrid.Rows; rowIndex += rowIncrement)
            {
                for (int colIndex = 0; colIndex < grid.Columns ; colIndex+= colIncrement )
                {
                    //Console.Write(grid[rowIndex, colIndex]);




                    for (int searchGridRowIndex = 0; searchGridRowIndex < searchGrid.Rows; searchGridRowIndex++)
                    {
                        for (int searchGridColIndex = 0; searchGridColIndex < searchGrid.Columns; searchGridColIndex++)
                        {
                            
                        }
                    }

                }
                Console.WriteLine();
            }
            //for (int currentRow = 0; currentRow < grid.Rows; currentRow++)
            //{
            //    for (int currentCol = firstGridPosition; currentCol < grid.Columns; currentCol++)
            //    {
            //        if (found == GetNumberOfSearchItemsInSearchGrid(this.searchGrid))
            //            break;
            //        if (searchGridColPos < searchGrid.Columns )
            //        {
            //            if (grid[currentRow, currentCol] == searchGrid[searchGridRowPos, searchGridColPos])
            //            {
            //                if (searchGridColPos == 0 && searchGridRowPos == 0)
            //                    firstGridPosition = currentCol;
            //                found++;
            //                searchGridColPos++;
            //                if (searchGridColPos == searchGrid.Columns && searchGrid.Rows > 1)
            //                {
            //                    searchGridRowPos++;
            //                    searchGridColPos = firstGridPosition;
            //                }
            //            }
            //        }
            //    }
            //}
            //return (found == GetNumberOfSearchItemsInSearchGrid(searchGrid));

            return true;
        }
        private int GetNumberOfSearchItemsInSearchGrid(Grid searchGrid)
        {
            return (searchGrid.Rows * searchGrid.Columns);
        }
    }
