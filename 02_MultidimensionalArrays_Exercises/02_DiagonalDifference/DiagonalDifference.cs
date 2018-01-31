using System;
using System.Linq;

namespace _02_DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int rowsAndColsCound = int.Parse(Console.ReadLine());
            int[] rowInput;
            int[,] squareMatrix = new int[rowsAndColsCound, rowsAndColsCound];

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            for (int rowIndex = 0; rowIndex < squareMatrix.GetLength(0); rowIndex++)
            {
                rowInput = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int colIndex = 0; colIndex < squareMatrix.GetLength(1); colIndex++)
                {

                    squareMatrix[rowIndex, colIndex] = rowInput[colIndex];
                }
            }
            for (int rowCollIndex = 0; rowCollIndex < squareMatrix.GetLength(0); rowCollIndex++)
            {
                sumFirstDiagonal += squareMatrix[rowCollIndex, rowCollIndex];
                sumSecondDiagonal += squareMatrix[rowCollIndex, --rowsAndColsCound];
            }

            Console.WriteLine(Math.Abs(sumSecondDiagonal - sumFirstDiagonal));
        }
    }
}
