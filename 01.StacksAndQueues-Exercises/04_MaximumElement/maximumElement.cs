using System;
using System.Collections.Generic;
using System.Linq;

class maximumElement
{
    static void Main()
    {
        var nsx = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var n = nsx[0];
        var s = nsx[1];
        var x = nsx[2];

        var stack = new Queue<int>(inputLine);

        for (int j = 0; j < s; j++)
        {
            stack.Dequeue(); 

        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
            return;
        }

        if (stack.Contains(x))
        {
            Console.WriteLine("true");

        }
        else
        {
            Console.WriteLine(stack.Max());
        }
    }
}