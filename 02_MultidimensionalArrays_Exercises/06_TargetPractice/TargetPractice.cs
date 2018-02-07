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
            .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rowOfImpact = shotParams[0];
        int colOfImpact = shotParams[1];
        int radiusOfImpact = shotParams[2];

        int leftWave = colOfImpact - radiusOfImpact;
        int rightWave = colOfImpact + radiusOfImpact;

        staircaseMatrix[rowOfImpact, colOfImpact] = ' ';

        int downRowsBlastRange = rowOfImpact + radiusOfImpact;
        int upRowsBlastRange = rowOfImpact - radiusOfImpact;
        int originalLeftWave = leftWave;
        int originalRightWave = rightWave;

        for (int shockwaveRowStartIndex = rowOfImpact; shockwaveRowStartIndex <= downRowsBlastRange; shockwaveRowStartIndex++)
        {
            for (int shockwaveColLeftStartIndex = leftWave;
                shockwaveColLeftStartIndex <= rightWave;
                shockwaveColLeftStartIndex++)
            {
                if (shockwaveRowStartIndex >= 0
                    && shockwaveRowStartIndex < staircaseMatrix.GetLength(0)
                    && shockwaveColLeftStartIndex >= 0
                    && shockwaveColLeftStartIndex < staircaseMatrix.GetLength(1))
                {
                    staircaseMatrix[shockwaveRowStartIndex, shockwaveColLeftStartIndex] = ' ';
                }
            }
            leftWave++;
            rightWave--;
        }
        leftWave = originalLeftWave;
        rightWave = originalRightWave;

        for (int shockwaveRowStartIndex = rowOfImpact - 1; shockwaveRowStartIndex >= upRowsBlastRange; shockwaveRowStartIndex--)
        {
            leftWave++;
            rightWave--;
            for (int shockwaveColLeftStartIndex = leftWave;
                shockwaveColLeftStartIndex <= rightWave;
                shockwaveColLeftStartIndex++)
            {
                if (shockwaveRowStartIndex >= 0
                    && shockwaveRowStartIndex < staircaseMatrix.GetLength(0)
                    && shockwaveColLeftStartIndex >= 0
                    && shockwaveColLeftStartIndex < staircaseMatrix.GetLength(1))
                {
                    staircaseMatrix[shockwaveRowStartIndex, shockwaveColLeftStartIndex] = ' ';
                }
            }
        }
        int loopCounter = 0;
//        for (int row = 0; row < staircaseMatrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
//            {
//                Console.Write(staircaseMatrix[row, col]);
//            }
//            Console.WriteLine();
//
//        }
//        Console.WriteLine();

        for (int rowIndex = staircaseMatrix.GetLength(0) - 1; rowIndex >= 0; rowIndex--)
        {
            for (int colIndex = 0; colIndex < staircaseMatrix.GetLength(1); colIndex++)
            {
                while (staircaseMatrix[rowIndex, colIndex] == ' ' && rowIndex > 0)
                {
                   
                    for (int fallIndex = rowIndex; fallIndex > 0; fallIndex--)
                    {
                        staircaseMatrix[fallIndex, colIndex] = staircaseMatrix[fallIndex - 1, colIndex];

                    }

                    staircaseMatrix[0, colIndex] = ' ';

                    if (loopCounter++ > rowIndex + 1)
                    {
                        loopCounter = 0;
                        break;
                    }
                }
            }
        }
        for (int row = 0; row < staircaseMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < staircaseMatrix.GetLength(1); col++)
            {
                Console.Write(staircaseMatrix[row, col]);
            }
            Console.WriteLine();

        }
    }
}