using System;
using System.Linq;

namespace _03_SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int colsCount;
            int rowsCount;
            int[] matrixDimensions = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            rowsCount = matrixDimensions[0];
            colsCount = matrixDimensions[1];


            string[] chars = new string[colsCount];

            string[,] matrix = new string[rowsCount, colsCount];

            string upperLeftElement;
            string upperRightElement;
            string bottomLeftElement;
            string bottomRightElement;

            int boxesChecked = 0;


            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                chars = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    bottomRightElement = chars[colIndex];

                    matrix[rowIndex, colIndex] = bottomRightElement;
                    if (rowIndex > 0 && colIndex > 0)
                    {
                        bottomLeftElement = matrix[rowIndex, colIndex - 1];
                        if (bottomLeftElement == bottomRightElement)
                        {
                            upperLeftElement = matrix[rowIndex - 1, colIndex - 1];
                            upperRightElement = matrix[rowIndex - 1, colIndex];

                            if (upperLeftElement == upperRightElement && upperLeftElement == bottomRightElement)
                            {
                                boxesChecked++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(boxesChecked);
        }
    }
}
