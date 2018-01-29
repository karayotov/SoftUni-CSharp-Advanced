using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        int pumpsCount = int.Parse(Console.ReadLine());
        int currentPumpAmount;
        int nextPumpDistance;
        
        int fuel = 0;

        Queue<string> pumpQueue = new Queue<string>(pumpsCount);
        Queue<string> currPump = new Queue<string>();
        string pumpData;
        short fromWitchIndexWeStartTheTour = 0;

        int[] pumpDataArr = new int[2];

        for (int pumpIndex = 0; pumpIndex < pumpsCount; pumpIndex++)
        {
            pumpData = Console.ReadLine();
            pumpQueue.Enqueue(pumpData);
        }

        while (true)
        {
            currPump = new Queue<string>(pumpQueue);
            
            for (int pumpIndex = 0; pumpIndex < pumpsCount; pumpIndex++)
            {
                pumpData = currPump.Dequeue();

                pumpDataArr = pumpData
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                currentPumpAmount = pumpDataArr[0];
                nextPumpDistance = pumpDataArr[1];

                fuel += currentPumpAmount - nextPumpDistance; //ще добави или ще извади от fuel

                if (fuel < 0)
                {
                    fuel = 0;
                    break;
                }
            }

            if (currPump.Count < 1)
            {
                Console.WriteLine(fromWitchIndexWeStartTheTour);
                return;
            }
            fromWitchIndexWeStartTheTour++;

            pumpData = pumpQueue.Dequeue();
            pumpQueue.Enqueue(pumpData);
        }
    }
}