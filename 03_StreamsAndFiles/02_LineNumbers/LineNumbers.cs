using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;

class LineNumbers
{
    static void Main()
    {
        int counter = 0;
        StringBuilder text = new StringBuilder();
        string lineNumber;

        StreamReader reader = new StreamReader("text.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        using (reader)
        {
            using (writer)
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                    lineNumber = $"Line {counter}: ";

                    writer.WriteLine(lineNumber + line);

                }
            }
        }
    }
}