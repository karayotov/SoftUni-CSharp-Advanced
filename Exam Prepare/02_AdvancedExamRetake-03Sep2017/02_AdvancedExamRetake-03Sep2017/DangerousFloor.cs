using System;
using System.Linq;
using System.Net.Sockets;

namespace _02_AdvancedExamRetake_03Sep2017
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {

            char[][] floorMatrix = new char[8][];

            for (int row = 0; row < floorMatrix.Length; row++)
            {
                floorMatrix[row] = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse)
                    .ToArray();
            }
            Console.WriteLine();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                char emptyPlace = 'x';
                char gender = inputLine[0];
                int startRow = int.Parse(inputLine[1].ToString());
                int startCol = int.Parse(inputLine[2].ToString());
                int finalRow = int.Parse(inputLine[4].ToString());
                int finalCol = int.Parse(inputLine[5].ToString());



                if (EverithingIsTochno(floorMatrix, gender, startRow, startCol, finalRow, finalCol))
                {
                    floorMatrix[startRow][startCol] = emptyPlace;
                    floorMatrix[finalRow][finalCol] = gender;
                }

            }
        }

        public static bool EverithingIsTochno(char[][] floorMatrix, char gender, int startRow, int startCol, int finalRow, int finalCol)
        {
            if (floorMatrix[startRow][startCol] != gender)
            {
                Console.WriteLine("There is no such a piece!");
                return false;
            }

            bool peaceMoveIsOk = false;

            switch (gender)
            {
                
                case 'K':
                    if (KingValidMove(startRow, startCol, finalRow, finalCol)) peaceMoveIsOk = true;
                    break;
                case 'R':
                    if (RookValidMove(startRow, startCol, finalRow, finalCol)) peaceMoveIsOk = true;
                    break;
                case 'B':
                    if (BishopValidMove(startRow, startCol, finalRow, finalCol)) peaceMoveIsOk = true;
                    break;
                case 'Q':
                    if (QueenValidMove(startRow, startCol, finalRow, finalCol)) peaceMoveIsOk = true;
                    break;
                case 'P':
                    if (PawnValidMove(startRow, startCol, finalRow, finalCol)) peaceMoveIsOk = true;
                    break;
                default:
                    throw new Exception();
            }

            if (peaceMoveIsOk == false)   //|| NotMovingPeace(startRow, startCol, finalCol, finalRow)
            {
                Console.WriteLine("Invalid move!");
                return false;
            }

            if (MoveOutOfBoard(finalRow, finalCol))
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }
            return true;

        }
        public static bool RookValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            return startRow == finalRow || startCol == finalCol;
        }

        public static bool BishopValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            return Math.Abs(startRow - finalRow) == Math.Abs(startCol - finalCol);
        }

        public static bool QueenValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            return BishopValidMove(startRow, startCol, finalRow, finalCol) || RookValidMove(startRow, startCol, finalRow, finalCol);
        }

        public static bool KingValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            int rowRange = Math.Abs(startRow - finalRow);
            int colRange =  Math.Abs(startCol - finalCol);

            return rowRange == 1 && colRange == 1 || rowRange == 0 && colRange == 1 || rowRange == 1 && colRange == 0;
        }

        public static bool PawnValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            bool pawnIsOnTheLastPosition = startRow == 0;

            if (finalRow == startRow - 1 && startCol == finalCol && pawnIsOnTheLastPosition == false)
            {
                return true;
            }
            return false;
        }

        public static bool MoveOutOfBoard(int finalRow, int finalCol)
        {
            if (finalRow >= 8 || finalRow < 0 || finalCol >= 8 || finalCol < 0)
            {
                return true;
            }

            return false;
        }

        public static bool InvalidStart(int startRow, int startCol)
        {
            return startRow >= 8 || startRow < 0 || startCol >= 8 || startCol < 0;
        }

        public static bool NotMovingPeace(int startRow, int startCol, int finalRow, int finalCol)
        {
            return startRow == finalRow && startCol == finalCol;
        }
    }
}