using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_WordCount
{
    class WordCount
    {
        static void Main()
        {
            StreamReader textReader = new StreamReader("text.txt");
            StreamReader wordsReader = new StreamReader("words.txt");
            StreamWriter resultWriter = new StreamWriter("result.txt");

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] wordsFromText;
            string line;
            string textLine;

            using (wordsReader)
            {
                while ((line = wordsReader.ReadLine()) != null)
                {
                    dictionary.Add(line, 0);
                }
            }
            using (textReader)
            {
                using (resultWriter)
                {
                    while ((textLine = textReader.ReadLine()) != null)
                    {
                        wordsFromText = textLine.ToLower().Split(new Char[] {'-', ' ', '.', '!', '?', ',', ':'},
                            StringSplitOptions.RemoveEmptyEntries).ToArray();

                        foreach (string word in wordsFromText)
                        {
                            if (dictionary.ContainsKey(word))
                            {
                                dictionary[word]++;
                            }
                        }

                    }
                    foreach (var pair in dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        resultWriter.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}
