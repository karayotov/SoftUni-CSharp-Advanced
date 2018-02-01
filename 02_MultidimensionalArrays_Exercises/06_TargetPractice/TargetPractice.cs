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
        int leftMaxPoint = Math.Min(colOfImpact - 0, radiusOfImpact);
        int rightMaxPoint = Math.Min(colOfImpact - staircaseMatrix.GetLength(1) - 1, radiusOfImpact);
        int upMaxPoint = Math.Min(rowOfImpact - 0, radiusOfImpact);
        int downMaxPoint = Math.Min(rowOfImpact - staircaseMatrix.GetLength(0) - 1, radiusOfImpact);

        int leftWaveCol = colOfImpact;
        int leftWaveRow = rowOfImpact;
        int rightWaveCol = colOfImpact;
        int rightWaveRow = rowOfImpact;
        int upWaveCol = colOfImpact;
        int upWaveRow = rowOfImpact;
        int downWaveCol = colOfImpact;
        int downWaveRow = rowOfImpact;
        int wave = colOfImpact - radiusOfImpact;
        int leftWave = colOfImpact - radiusOfImpact;
        int rightWave = colOfImpact + radiusOfImpact;

        staircaseMatrix[rowOfImpact, colOfImpact] = ' ';

        for (int shockwaveIndex = 0; shockwaveIndex < radiusOfImpact; shockwaveIndex++)
        {
            for (int i = wave - 1; i >= 0; i--)
            {
                //if (leftWaveCol - wave <= rightMaxPoint && leftWaveRow <= upMaxPoint)
                //{
                    staircaseMatrix[leftWaveRow, leftWaveCol - wave] = ' ';
                    leftWaveCol++;
                //}
            }
            leftWaveRow--;
        }

    }
}