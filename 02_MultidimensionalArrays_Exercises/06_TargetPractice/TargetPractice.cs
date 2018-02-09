using System;
using System.Linq;

class TargetPractice
{
    static void Main(string[] args)
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];
        string snake = Console.ReadLine();

        char[,] staircaseMatrix = new char[rows, cols];

        int charIndexSnake = 0;
        int stepsCounter = 0;

        for (int rowIndex = staircaseMatrix.GetLength(0) - 1; rowIndex >= 0; rowIndex--)
        {
            if (stepsCounter++ % 2 == 0)
            {
                for (int colIndex = staircaseMatrix.GetLength(1) - 1; colIndex >= 0; colIndex--)
                {
                    staircaseMatrix[rowIndex, colIndex] = snake[charIndexSnake++];
                    if (charIndexSnake > snake.Length - 1)
                    {
                        charIndexSnake = 0;
                    }
                }
            }
            else
            {
                for (int colIndex = 0; colIndex < staircaseMatrix.GetLength(1); colIndex++)
                {
                    staircaseMatrix[rowIndex, colIndex] = snake[charIndexSnake++];
                    
                    if (charIndexSnake > snake.Length - 1)
                    {
                        charIndexSnake = 0;
                    }
                }
            }
        }

        int[] shotParams = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rowOfImpact = shotParams[0];
        int colOfImpact = shotParams[1];
        int radiusOfImpact = shotParams[2];



        staircaseMatrix[rowOfImpact, colOfImpact] = ' ';

        for (int row = 0; row < staircaseMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
            {
                int a = rowOfImpact - row;
                int b = colOfImpact - col;
                double distance = Math.Sqrt(a * a + b * b);
                if (distance <= radiusOfImpact)
                {
                    staircaseMatrix[row, col] = ' '; 
                }
            }
        }
        int loopCounter = 0;
        for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
        {
            for (int row = staircaseMatrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (staircaseMatrix[row, col] == ' ')
                {
                    loopCounter++;
                }
                else if (loopCounter > 0)
                {
                    staircaseMatrix[row + loopCounter, col] = staircaseMatrix[row, col];
                    staircaseMatrix[row, col] = ' ';
                }
            }
            loopCounter = 0;
        }
        for (int row = 0; row < staircaseMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
            {
                Console.Write(staircaseMatrix[row, col]);
            }
            Console.WriteLine();
        }
        //        for (int row = 0; row < staircaseMatrix.GetLength(0); row++)
        //        {
        //            for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
        //            {
        //                Console.Write(staircaseMatrix[row, col] + " ");
        //            }
        //            Console.WriteLine();
        //
        //        }
        //        Console.WriteLine();
    }
}