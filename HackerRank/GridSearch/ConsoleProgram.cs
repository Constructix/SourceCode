using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication5
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {



            if (args.Length > 0)
            {
                Console.SetIn(File.OpenText(args[0]));
            }


            //1
            //4 6
            //456712
            //561245
            //123667
            //781288
            //2 2
            //45
            //67




            int[,] matrix = new int[,] { {4, 5, 6, 7, 1, 2}, {5,6,1,2,4,5}, {1,2,3,6,6,7}, { 7,8,1,2,8,8 } };

            int[,] searchMatrix = new int[,] {{4,5}, {6,7}};

            bool[,] results = new bool[searchMatrix.GetLength(0), searchMatrix.GetLength(1)];

            PrintMatrix(matrix);
            Console.WriteLine();
            PrintMatrix(searchMatrix);

            Console.WriteLine();
            Console.WriteLine();

            int searchMatrixRowSize = searchMatrix.GetLength(0);
            int searchMatrixColSize = searchMatrix.GetLength(1);

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {

                    for (int searchMatrixRow = 0; searchMatrixRow < searchMatrixRowSize; searchMatrixRow++)
                    {
                        for (int searchMatrixCol = 0; searchMatrixCol < searchMatrixColSize; searchMatrixCol++)
                        {
                            if (matrix[x, y] == searchMatrix[searchMatrixRow, searchMatrixCol])
                                results[searchMatrixRow, searchMatrixCol] = true;
                        }
                    }
                }
            }
            Console.WriteLine();
            PrintMatrix(results);

            Console.WriteLine(CheckResults(results) == true? "YES": "NO");


        }

        private static bool CheckResults(bool[,] matrix)
        {

            bool valid = true;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (!matrix[x,y])
                        return false;
                }
              
            }
            return valid;
        }


        private static void PrintMatrix(bool[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write($"{matrix[x, y]} ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(int[,] matrix)
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
    }
}
