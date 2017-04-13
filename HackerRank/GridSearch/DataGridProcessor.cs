
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
            int searchGridRowPos = 0;
            int searchGridColPos = 0;
            int found = 0;
            int firstGridPosition = 0;
            for (int currentRow = 0; currentRow < grid.Rows; currentRow++)
            {
                for (int currentCol = firstGridPosition; currentCol < grid.Columns; currentCol++)
                {
                    if (found == GetNumberOfSearchItemsInSearchGrid(this.searchGrid))
                        break;
                    if (searchGridColPos < searchGrid.Columns )
                    {
                        if (grid[currentRow, currentCol] == searchGrid[searchGridRowPos, searchGridColPos])
                        {
                            if (searchGridColPos == 0 && searchGridRowPos == 0)
                                firstGridPosition = currentCol;
                            found++;
                            searchGridColPos++;
                            if (searchGridColPos == searchGrid.Columns && searchGrid.Rows > 1)
                            {
                                searchGridRowPos++;
                                searchGridColPos = firstGridPosition;
                            }
                        }
                    }
                }
            }

            return (found == GetNumberOfSearchItemsInSearchGrid(searchGrid));
        }
        private int GetNumberOfSearchItemsInSearchGrid(Grid searchGrid)
        {
            return (searchGrid.Rows * searchGrid.Columns);
        }
    }
