using System;

namespace _04_PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            long height = long.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            for (long currentHeight = 0; currentHeight < height ; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;
                
                if (currentHeight >= 2)
                {
                    for (long widthCounter = 1; widthCounter < currentHeight - 1; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] + 
                            triangle[currentHeight - 1][widthCounter];
                    }
                }
            }
            for (long rows = 0; rows < triangle.Length; rows++)
            {
                for (long columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write(triangle[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}