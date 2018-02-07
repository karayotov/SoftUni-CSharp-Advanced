using System;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[a-zA-Z]+\<(?<leftNum>[\d]+)REGEH(?<rightNum>[\d]+)\>[a-zA-Z]+\]";
            string input = Console.ReadLine();
            int firstIndex = 0;
            int nextIndex = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                firstIndex += int.Parse(m.Groups["leftNum"].Value);


                if (firstIndex >= input.Length)
                {
                    Console.Write(input[firstIndex % (input.Length - 1)]);
                }
                else
                {
                    Console.Write(input[firstIndex]);
                }

                firstIndex += int.Parse(m.Groups["rightNum"].Value);

                if (firstIndex >= input.Length)
                {
                    Console.Write(input[firstIndex % (input.Length - 1)]);
                }
                else
                {
                    Console.Write(input[firstIndex]);
                }
            }
            Console.WriteLine();

        }
    }
}
