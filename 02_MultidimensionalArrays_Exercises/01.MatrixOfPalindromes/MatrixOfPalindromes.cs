using System;
using System.Linq;
using System.Text;

namespace _01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new String[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            string threeCharsWord;
            
            string[,] palindromesMtrx = new string[rowsCount, colsCount];
            char firstChar = 'a';
            char secondChar = 'a';
            char lastChar = 'a';

           
            for (int rowIndex = 0; rowIndex < palindromesMtrx.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < palindromesMtrx.GetLength(1); colIndex++)
                {

                    threeCharsWord = String.Join(secondChar, firstChar, lastChar);
                    palindromesMtrx[rowIndex, colIndex] = threeCharsWord;
                    secondChar++;

                    Console.Write(threeCharsWord + " ");

                }
                firstChar++;
                lastChar++;
                secondChar = firstChar;
                Console.WriteLine();
            }
        }
    }
}
