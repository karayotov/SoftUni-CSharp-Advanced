using System;
using System.Collections.Generic;

class simpleCalculator
{
    static void Main()
    {
        string input = Console.ReadLine();
        var elements = input.Split(' ');
        var stack = new Stack<string>();
        for (int counter = elements.Length; counter >= 0; counter++)
        {
            stack.Push(elements[counter]);
        }

    }
}