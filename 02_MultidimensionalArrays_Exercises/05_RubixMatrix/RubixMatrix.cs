using System;
using System.Linq;

namespace _05_RubixMatrix
{
    class RubixMatrix
    {
        private static int[,] matrix;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            matrix = new int[dimensions[0], dimensions[1]];

            int rows = dimensions[0];
            int cols = dimensions[1];

            int number = 1;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[rows, cols] = ++number;
                }
            }

            int commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                ParseCommand();
            }

            ///
            /// 

        }

        private static void ParseCommand()
        {
            string[] commaArgs = Console.ReadLine().Split();
            string command = commaArgs[1];
            int index = int.Parse(commaArgs[0]);
            int rotation = int.Parse(commaArgs[2]);
            ///
        }
        //private static MoveRow(int )
    }
}
