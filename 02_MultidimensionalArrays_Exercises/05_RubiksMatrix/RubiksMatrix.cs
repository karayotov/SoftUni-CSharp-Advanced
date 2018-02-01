using System;
using System.Collections.Generic;
using System.Linq;

class RubiksMatrix
{
    static void Main()
    {
        int[] matrixDimensions = Console.ReadLine()
            .Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int rows = matrixDimensions[0];
        int cols = matrixDimensions[1];
        int[,] matrix = new int[rows, cols];

        int element = 1;

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                matrix[rowIndex, colIndex] = element++;
            }
        }

        int commandsCount = int.Parse(Console.ReadLine());

        string[] commandLine = new string[3];
        int rowOrColForMantain;
        string direction;
        int moves;
        int deletedElement;
        int colToShift;
        int rowToShift;

        for (int comandIndex = 0; comandIndex < commandsCount; comandIndex++)
        {
            commandLine = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            direction = commandLine[1];
            moves = int.Parse(commandLine[2]);
            rowOrColForMantain = int.Parse(commandLine[0]);


            switch (direction)
            {
                case "up":
                    colToShift = rowOrColForMantain;
                    moves = moves % matrix.GetLength(0);

                    for (int moveIndex = 0; moveIndex < moves; moveIndex++)
                    {
                        deletedElement = matrix[0, colToShift];

                        for (int rowIndex = 0; rowIndex < matrix.GetLength(0) - 1; rowIndex++)
                        {
                            matrix[rowIndex, colToShift] = matrix[rowIndex + 1, colToShift];
                        }
                        matrix[matrix.GetLength(0) - 1, colToShift] = deletedElement;
                    }

                    break;

                case "down":
                    colToShift = rowOrColForMantain;

                    moves = moves % matrix.GetLength(0);

                    for (int moveIndex = 0; moveIndex < moves; moveIndex++)
                    {
                        deletedElement = matrix[matrix.GetLength(1) - 1, colToShift];
                        for (int rowIndex = matrix.GetLength(0) - 1; rowIndex > 0; rowIndex--)
                        {
                            matrix[rowIndex, colToShift] = matrix[rowIndex - 1, colToShift];
                        }
                        matrix[0, colToShift] = deletedElement;
                    }
                    
                    break;

                case "left":

                    rowToShift = rowOrColForMantain;
                    moves = moves % matrix.GetLength(1);

                    for (int movesIndex = 0; movesIndex < moves; movesIndex++)
                    {
                        deletedElement = matrix[rowToShift, 0];
                        for (int colIndex = 0; colIndex < matrix.GetLength(1) - 1; colIndex++)
                        {
                            matrix[rowToShift, colIndex] = matrix[rowToShift, colIndex + 1];
                        }
                        matrix[rowToShift, matrix.GetLength(1) - 1] = deletedElement;
                    }

                    break;
                case "right":

                    rowToShift = rowOrColForMantain;
                    moves = moves % matrix.GetLength(1);

                    for (int moveIndex = 0; moveIndex < moves; moveIndex++)
                    {
                        deletedElement = matrix[rowToShift, matrix.GetLength(1) - 1];
                        for (int colIndex = matrix.GetLength(1) - 1; colIndex > 0; colIndex--)
                        {
                            matrix[rowToShift, colIndex] = matrix[rowToShift, colIndex - 1];
                        }
                        matrix[rowToShift, 0] = deletedElement;
                    }
                    break;
            }
        }
        int valueCounter = 0;

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                if (matrix[rowIndex, colIndex] != ++valueCounter)
                {
                    for (int rowSearchIndex = 0; rowSearchIndex < matrix.GetLength(0); rowSearchIndex++)
                    {
                        for (int colSearchIndex = 0; colSearchIndex < matrix.GetLength(1); colSearchIndex++)
                        {
                            if (matrix[rowSearchIndex, colSearchIndex] == valueCounter)
                            {
                                matrix[rowSearchIndex, colSearchIndex] = matrix[rowIndex, colIndex];
                                matrix[rowIndex, colIndex] = valueCounter;
                                Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({rowSearchIndex}, {colSearchIndex})");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No swap required");
                }
            }
        }
    }
}