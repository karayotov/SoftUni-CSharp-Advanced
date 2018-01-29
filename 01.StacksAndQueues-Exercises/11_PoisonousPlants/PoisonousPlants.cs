using System;
using System.Collections.Generic;
using System.Linq;

class PoisonousPlants
{
    static void Main(string[] args)
    {
        int oldPlantsAmount = int.Parse(Console.ReadLine());
        int daysCounter = 0;
        int leftPlant = 0;
        int tudaysGMO = 1;

        string gardenStr = String.Empty;
        int[] gardenInts = new int[] { oldPlantsAmount };

        gardenStr = Console.ReadLine();
        gardenInts = gardenStr
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> stack = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        for (int plantIndex = 0; plantIndex < oldPlantsAmount; plantIndex++)
        {
            stack.Push(gardenInts[plantIndex]);
        }

        while (tudaysGMO != 0)
        {
            daysCounter++;
            tudaysGMO = 0;

            for (int plantIndex = stack.Count; plantIndex > 0; plantIndex--)
            {
                int rightPlant = stack.Pop();

                if (stack.Count > 0 )
                {
                    leftPlant = stack.Peek();
                }

                if (rightPlant <= leftPlant || stack.Count == 0)
                {
                    stack2.Push(rightPlant);
                }
                else
                {
                    tudaysGMO++;
                }
            }


            for (int plantIndex = stack2.Count; plantIndex > 0; plantIndex--)
            {
                
                stack.Push(stack2.Pop());
                
            }

        }
        daysCounter--;
        Console.WriteLine(daysCounter);
    }
}