using System;
using System.Collections.Generic;
using System.Linq;

class BalancedParenthesis
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        char singleBracket;

        if (inputLine.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        Stack<char> stackLeftBrackets = new Stack<char>();
        Stack<char> stackRightBrackets = new Stack<char>();

        char[] brackets = inputLine.ToCharArray();

        for (int charIndex = 0; charIndex < brackets.Length; charIndex++)
        {
            switch (brackets[charIndex])
            {
                case '(':
                case '{':
                case '[':

                    stackLeftBrackets.Push(brackets[charIndex]);
                    break;
            case ')':
            case '}':
            case ']':
                char open = stackLeftBrackets.Peek();
                char close = brackets[charIndex];

                if (open == '(' && close == ')' || open == '{' && close == '}' || open == '[' && close == ']')
                {
                    stackLeftBrackets.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
                break;
            }
        }
        Console.WriteLine("YES");
    }
}