using System;
using System.Linq;

namespace _02_SquareWithMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            int sum = 0;

            int rowIndex = 0, colIndex = 0;

            for (int rows = 0; rows < rowsAndCols[0]; rows++)
            {
                var values = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < rowsAndCols[1]; col++)
                {
                    matrix[rows, col] = values[col];
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var tempSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] +
                                  matrix[rows + 1, cols + 1];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }
            Console.WriteLine(matrix[rowIndex, colIndex] + " " + matrix[rowIndex, colIndex + 1] + " ");
            Console.WriteLine(matrix[rowIndex + 1, colIndex] + " " + matrix[rowIndex + 1, colIndex + 1] + " ");
            Console.WriteLine(sum);
        }
    }
}
