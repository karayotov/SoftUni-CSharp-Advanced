using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SimpleTextEditor
{
    static void Main(string[] args)
    {
        int operationsCount = int.Parse(Console.ReadLine());
        string command = String.Empty;
        string argument = String.Empty;
        char peek = 's';
        StringBuilder stringBuilder = new StringBuilder();
        int argInt = 0;
        Stack<string> undo = new Stack<string>();
        for (int i = 0; i < operationsCount; i++)
        {
            string operationStr = Console.ReadLine();
            string[] operationStrings =
                operationStr
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            command = operationStrings[0];

            if (operationStrings.Length > 1)
            {
                argument = operationStrings[1];
                
            }

            switch (command)
            {
                case "1":

                    undo.Push(operationStr);
                    stringBuilder.Append(argument);

                    break;
                case "2":

                    argInt = int.Parse(argument);
                    string deleted = stringBuilder.ToString(stringBuilder.Length - argInt, argInt);
                    undo.Push($"2 {deleted}");
                    stringBuilder.Remove(stringBuilder.Length - argInt, argInt);

                    break;
                case "3":

                    argInt = int.Parse(argument);
                    peek = stringBuilder[argInt - 1];
                    Console.WriteLine(peek);

                    break;
                case "4":
                    string undoPop = undo.Pop();
                    string[] undoOpStrings = undoPop
                        .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    argument = undoOpStrings[1];

                    switch (undoOpStrings[0])
                    {
                        case "1":

                            
                            stringBuilder.Remove(stringBuilder.Length - argument.Length, argument.Length);

                            break;
                        case "2":

                           
                            stringBuilder.Append(argument);

                            break;
                    }

                    break;
            }
        }
    }
}