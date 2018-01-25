using System;
using System.Collections.Generic;

class reverseNumbers
{
    static void Main(string[] args)
    {
        var inputLine = Console.ReadLine().Split(' ');
        var stack = new Stack<string>(inputLine);


        do
        {
            Console.Write(stack.Pop() + " ");
            
        } while (stack.Count > 0);
        Console.WriteLine();
    }
}
