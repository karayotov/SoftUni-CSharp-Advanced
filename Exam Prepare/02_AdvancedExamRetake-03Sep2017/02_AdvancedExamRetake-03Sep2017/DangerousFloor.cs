using System;
using System.Linq;

namespace _02_AdvancedExamRetake_03Sep2017
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {
            string inputLine;

            string[][] floorMatrix = new string[8][];

            for (int row = 0; row < floorMatrix.GetLength(0); row++)
            {
                floorMatrix[row] = Console.ReadLine().Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            while ((inputLine = Console.ReadLine()) != "END")
            {
                
                string gender = inputLine[0].ToString();
                int startingRow = int.Parse(inputLine[1].ToString());
                int startCol = int.Parse(inputLine[2].ToString());
                int finalRow = int.Parse(inputLine[4].ToString());
                int finalCol = int.Parse(inputLine[5].ToString());


            }


        }

        public static bool RookValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            if ((startRow == finalRow && startCol != finalCol)   ||   (startRow != finalRow && startCol == finalCol))
            {
                return true;
            }
            return false;
        }

        public static bool BishopValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            if (Math.Abs(startRow - finalRow) == Math.Abs(startCol - finalCol))
            {
                return true;
            }
            return false;
        }

        public static bool QueenValidMove(int startRow, int startCol, int finalRow, int finalCol)
        {
            if (BishopValidMove(startRow, startCol, finalRow, finalCol) && RookValidMove(startRow, startCol, finalRow, finalCol))
            {
                return true;
            }
            return false;
        }

    }
}
