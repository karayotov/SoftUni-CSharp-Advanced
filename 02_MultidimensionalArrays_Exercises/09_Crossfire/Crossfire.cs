using System;
using System.Linq;

namespace _09_Crossfire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            long[] matrixData = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            long rowCount = matrixData[0];
            long colCount = matrixData[1];
            string[][] stringLand = new string[rowCount][];

            long index = 0;

            for (long rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                stringLand[rowIndex] = new string[colCount];

                for (long colIndex = 0; colIndex < colCount; colIndex++)
                {
                    ++index;
                    string stringElement = index.ToString();

                    stringLand[rowIndex][colIndex] = stringElement;
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                long[] commands = input
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long rowHit = long.Parse(commands[0].ToString());
                long colHit = long.Parse(commands[1].ToString());
                int rangeHit = int.Parse(commands[2].ToString());

                NukeThemAll(rowHit, colHit, rangeHit, rowCount, colCount, stringLand);

                stringLand = TransferWhatIsLeft(stringLand);
            }
            PrintWhatIsLeft(stringLand);

        }

        private static void PrintWhatIsLeft(string[][] stringLand)
        {
            for (int row = 0; row < stringLand.Length; row++)
            {
                for (int col = 0; col < stringLand[row].Length; col++)
                {
                        Console.Write(stringLand[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static string[][] TransferWhatIsLeft(string[][] stringLand)
        {
            string[][] survivals = new string[stringLand.Length][];
            long newRow = 0;
            long newCol = 0;

            for (int rowIndex = 0; rowIndex < stringLand.Length; rowIndex++)
            {
                survivals[newRow] = new string[stringLand[rowIndex].Length];

                for (int colIndex = 0; colIndex < stringLand[rowIndex].Length; colIndex++)
                {
                    if (stringLand[rowIndex][colIndex] != String.Empty)
                    {
                        survivals[newRow][newCol] = stringLand[rowIndex][colIndex];
                        newCol++;
                    }
                }
                newRow++;
                newCol = 0;
            }
            stringLand = survivals;
            return stringLand;
        }

        public static void NukeThemAll(long rowHit, long colHit, int hitRange, long rowCount, long colCount,
            string[][] stringLand)
        {

            if (InLand(rowHit, colHit, rowCount, colCount))
            {
                stringLand[rowHit][colHit] = String.Empty;
            }
            for (int i = 1; i <= hitRange; i++)
            {
                colHit -= i;
                if (InLand(rowHit, colHit, rowCount, colCount))
                    stringLand[rowHit][colHit] = String.Empty;  //leftBlast
                colHit += i;
                colHit += i;
                if (InLand(rowHit, colHit, rowCount, colCount))
                    stringLand[rowHit][colHit] = String.Empty;  //rightBlast
                colHit -= i;
                rowHit -= i;
                if (InLand(rowHit, colHit, rowCount, colCount))
                    stringLand[rowHit][colHit] = String.Empty;  //upBlast
                rowHit += i;
                rowHit += i;
                if (InLand(rowHit, colHit, rowCount, colCount))
                    stringLand[rowHit][colHit] = String.Empty;  //downBlast
                rowHit -= i;
            }
        }

        private static bool InLand(long rowHit, long colHit, long rowCount, long colCount)
        {
            return rowHit < rowCount && colHit < colCount && rowHit >= 0 && colHit >= 0;
        }
    }
}