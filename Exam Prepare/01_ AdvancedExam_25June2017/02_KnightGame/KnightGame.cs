using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02_KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            string[,] chessBoard = new string[dimensions,dimensions];
            string inputLine = String.Empty;
            int targetsInRange = 0;
            int deletedHorses = 0;
            

            for (int rowIndex = 0; rowIndex < chessBoard.GetLength(0); rowIndex++)
            {
                inputLine = Console.ReadLine();
                Regex.Replace(inputLine, @"\s+", "");

                for (int colIndex = 0; colIndex < chessBoard.GetLength(1); colIndex++)
                {
                    chessBoard[rowIndex, colIndex] = inputLine[colIndex].ToString();
                }
            }

            for (int maxTargetsCounter = 8; maxTargetsCounter > 0; maxTargetsCounter--)
            {
                for (int rowIndex = 0; rowIndex < chessBoard.GetLength(0); rowIndex++)
                {
                    for (int colIndex = 0; colIndex < chessBoard.GetLength(1); colIndex++)
                    {
                        if (chessBoard[rowIndex, colIndex] == "K")
                        {
                            if (rowIndex > 1 && colIndex > 0 && chessBoard[rowIndex - 2, colIndex - 1] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex > 0 && colIndex > 1 && chessBoard[rowIndex - 1, colIndex - 2] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex > 1 && colIndex < dimensions - 1 && chessBoard[rowIndex - 2, colIndex + 1] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex > 0 && colIndex < dimensions - 2 && chessBoard[rowIndex - 1, colIndex + 2] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex < dimensions - 1 && colIndex > 1 && chessBoard[rowIndex + 1, colIndex - 2] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex < dimensions - 2 && colIndex > 0 && chessBoard[rowIndex + 2, colIndex - 1] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex < dimensions - 1 && colIndex < dimensions - 2 && chessBoard[rowIndex + 1, colIndex + 2] == "K")
                            {
                                targetsInRange++;
                            }
                            if (rowIndex < dimensions - 2 && colIndex < dimensions - 1 && chessBoard[rowIndex + 2, colIndex + 1] == "K")
                            {
                                targetsInRange++;
                            }
                            if (maxTargetsCounter == targetsInRange)
                            {
                                chessBoard[rowIndex, colIndex] = "0";
                                deletedHorses++;
                            }

                            targetsInRange = 0;
                        }
                    }
                }
            }
            Console.WriteLine(deletedHorses);
        }
    }
}
