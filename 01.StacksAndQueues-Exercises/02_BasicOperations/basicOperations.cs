using System;
using System.Collections.Generic;
using System.Linq;

class basicOperations
{
    static void Main()
    {
        var nsx= Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var n = nsx[0];
        var s = nsx[1];
        var x = nsx[2];

        var stack = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            stack.Push(inputLine[i]);
        }
        for (int j = 0; j < s; j++)
        {
            stack.Pop();
            if (stack.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
        }


        if (stack.Contains(x))
        {
            Console.WriteLine("true");

        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}
