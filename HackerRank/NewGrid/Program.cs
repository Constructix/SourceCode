using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGrid
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] grid = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            int[,] searchGrid = new int[,] { { 1, 2 }, { 3, 4 } };


            int currentGridXPosition = 0;
            int currentGridYPosition = 0;



            while (currentGridXPosition < grid.GetLength(0))
            {
                Console.WriteLine(currentGridXPosition);
                // Now we have got the xPosition.

                // go through the search grid and check the values that match the same grid pos 

                int currentXPosition = currentGridXPosition;
                int currentYPosition = 0;

                for (int x = 0; x < searchGrid.GetLength(0); x++)
                {
                    for (int y = 0; y < searchGrid.GetLength(1); y++)
                    {
                        if (grid[currentXPosition, currentYPosition] == searchGrid[x, y])
                            Console.WriteLine($"Match = [{currentXPosition}, {} ");
                    }
                }

                

                currentGridXPosition += searchGrid.GetLength(0);
            }
        }
    }
}
