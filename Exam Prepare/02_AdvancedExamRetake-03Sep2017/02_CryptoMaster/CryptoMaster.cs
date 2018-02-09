using System;
using System.Linq;

namespace _02_CryptoMaster
{
    class CryptoMaster
    {
        static void Main(string[] args)
        {
            int[] inputLine = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int currentIndex = 0;

            int currentJumpCounter = 1;

            int maxJumpCounter = 0;
            int startingIndex = 0;

            for (int jumpSize = 1; jumpSize < inputLine.Length; jumpSize++)
            {
                while (startingIndex < inputLine.Length)
                {
                    currentIndex = startingIndex;
                
                    while (inputLine[currentIndex] < inputLine[(currentIndex + jumpSize) % inputLine.Length])
                    {
                        currentIndex = (currentIndex + jumpSize) % inputLine.Length;
                        currentJumpCounter++;
                    }

                    if (currentJumpCounter > maxJumpCounter)
                    {
                        maxJumpCounter = currentJumpCounter;
                    }

                    currentJumpCounter = 0;
                    startingIndex++;

                }
                startingIndex = 0;
            }
            Console.WriteLine(maxJumpCounter);
        }
    }
}
