using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] sizeOfMainMatrix = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsMainMatrix = sizeOfMainMatrix[0];
            int colsMainMatrix = sizeOfMainMatrix[1];

            int[] arrayOfCols = new int[colsMainMatrix];

            int[,] mainMatrix = new int[rowsMainMatrix, colsMainMatrix];
            
            Dictionary<int, int[,]> dictionaryWith3DMatrices = new Dictionary<int, int[,]>();

            int topLeftElement,
                topMidleElement,
                topRightElement,
                
                middleLeftElement,
                middleMiddleElement,
                middleRightElement,
                
                bottomLeftElement,
                bottomMiddleElement,
                bottomRightElement,
                sum = 0;

            for (int rowIndex = 0; rowIndex < mainMatrix.GetLength(0); rowIndex++)
            {
                arrayOfCols = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int colIndex = 0; colIndex < mainMatrix.GetLength(1); colIndex++)
                {
                    mainMatrix[rowIndex, colIndex] = arrayOfCols[colIndex];

                    if (rowIndex > 1 && colIndex > 1)
                    {
                        
                        sum += bottomRightElement = mainMatrix[rowIndex, colIndex];
                        sum += bottomMiddleElement = mainMatrix[rowIndex, colIndex - 1];
                        sum += bottomLeftElement = mainMatrix[rowIndex, colIndex - 2];
                        sum += middleRightElement = mainMatrix[rowIndex - 1, colIndex];
                        sum += middleMiddleElement = mainMatrix[rowIndex - 1, colIndex - 1];
                        sum += middleLeftElement = mainMatrix[rowIndex - 1, colIndex - 2];
                        sum += topRightElement = mainMatrix[rowIndex - 2, colIndex];
                        sum += topMidleElement = mainMatrix[rowIndex - 2, colIndex - 1];
                        sum += topLeftElement = mainMatrix[rowIndex - 2, colIndex - 2];

                        int[,] squareMatrix = 
                        {
                            {topLeftElement, topMidleElement, topRightElement},
                            {middleLeftElement, middleMiddleElement, middleRightElement},
                            {bottomLeftElement, bottomMiddleElement, bottomRightElement}
                        };
                        if (!dictionaryWith3DMatrices.ContainsKey(sum))
                        {
                            dictionaryWith3DMatrices.Add(sum, squareMatrix);
                        }
                        sum = 0;
                    }
                }
            }
            sum  = dictionaryWith3DMatrices.Keys.Max();
            int[,] maxValueMatrix = dictionaryWith3DMatrices[sum];

            Console.WriteLine($"Sum = {sum}");

            for (int rowIndex = 0; rowIndex < maxValueMatrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < maxValueMatrix.GetLength(1); colIndex++)
                {
                    Console.Write(maxValueMatrix[rowIndex, colIndex] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}