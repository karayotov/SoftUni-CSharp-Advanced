using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P03_CryptoBlockchain
{
    public class StartUp
    {
        private static StringBuilder sb;
        private static string cryptoBlock;

        static void Main(string[] args)
        {
            ReadLines();
            RegexMatch();
            PrintMessage();
        }

        private static void PrintMessage()
        {
            Console.WriteLine(sb.ToString());
        }

        private static void RegexMatch()
        {
            string pattern = @"(?<length>((?<kriva>\{)|(?<prava>\[))\D*(?<nums>[\d{3}]+)\D*(?(kriva)\}|\]))";

            foreach (Match match in Regex.Matches(cryptoBlock, pattern))
            {
                char[] nums = match.Groups["nums"].Value.ToCharArray();
                int length = match.Groups["length"].Value.Length;

                if (nums.Length % 3 == 0)
                {
                    Decrypt(nums, length);
                }
            }
        }

        private static void Decrypt(char[] nums, int length)
        {
            char first;
            char second;
            char third;

            for (int trinity = 2; trinity < nums.Length; trinity += 3)
            {
                first = nums[trinity - 2];
                second = nums[trinity - 1];
                third = nums[trinity];
                int number = int.Parse(string.Join("", first, second, third));

                number = number - length;

                sb.Append((char)number);
            }
        }

        private static void ReadLines()
        {
            sb = new StringBuilder();

            int lineQuantity = int.Parse(Console.ReadLine());

            for (int thisLine = 0; thisLine < lineQuantity; thisLine++)
            {
                sb.Append(Console.ReadLine());
            }

            cryptoBlock = sb.ToString();

            sb.Clear();
        }
    }
}