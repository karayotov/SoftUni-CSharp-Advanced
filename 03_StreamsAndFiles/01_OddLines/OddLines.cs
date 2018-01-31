using System;
using System.IO;

namespace _01_OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}