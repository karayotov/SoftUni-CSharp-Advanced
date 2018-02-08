using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    class numberWars
    {
        static void Main(string[] args)
        {
            Queue<string> firstPlayerQueue = new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            Queue<string> secondPlayerQueue = new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            List<string> table = new List<string>();

            string firstSingleCard = String.Empty;
            string secondSingleCard = String.Empty;

            int firstNum, secondNum, turnCounter = 0;

            while (firstPlayerQueue.Count > 0 && secondPlayerQueue.Count > 0 && turnCounter < 1_000_000)
            {
                turnCounter++;

                firstSingleCard = firstPlayerQueue.Dequeue();
                secondSingleCard = secondPlayerQueue.Dequeue();


                firstNum = int.Parse(firstSingleCard.Remove(firstSingleCard.Length - 1));
                secondNum = int.Parse(secondSingleCard.Remove(secondSingleCard.Length - 1));

                if (firstNum > secondNum)
                {
                    firstPlayerQueue.Enqueue(firstSingleCard);
                    firstPlayerQueue.Enqueue(secondSingleCard);

                }
                else if (firstNum < secondNum)
                {
                    secondPlayerQueue.Enqueue(secondSingleCard);
                    secondPlayerQueue.Enqueue(firstSingleCard);
                }
                while (firstNum == secondNum)
                {

                    table.Add(secondSingleCard);
                    table.Add(firstSingleCard);

                    firstNum = 0;
                    secondNum = 0;

                    for (int moreMoves = 0; moreMoves < 3; moreMoves++)
                    {
                        if (firstPlayerQueue.Count > 0 && secondPlayerQueue.Count > 0)
                        {
                            firstSingleCard = firstPlayerQueue.Dequeue();
                            table.Add(firstSingleCard);

                            secondSingleCard = secondPlayerQueue.Dequeue();
                            table.Add(secondSingleCard);
                        }
                        else
                        {
                            if (firstPlayerQueue.Count < secondPlayerQueue.Count)
                            {
                                Console.WriteLine($"Second player wins after {turnCounter} turns");
                            }
                            else if (firstPlayerQueue.Count > secondPlayerQueue.Count)
                            {
                                Console.WriteLine($"First player wins after {turnCounter} turns");
                            }
                            else
                            {
                                Console.WriteLine($"Draw after {turnCounter} turns");
                            }
                            return;
                        }


                        firstNum += char.ToUpper(firstSingleCard[firstSingleCard.Length - 1]) - 64;
                        secondNum += char.ToUpper(secondSingleCard[secondSingleCard.Length - 1]) - 64;

                    }

                    table = table.OrderByDescending(x => x).ToList();

                    if (firstNum > secondNum)
                    {
                        for (int i = 0; i < table.Count; i++)
                        {
                            firstPlayerQueue.Enqueue(table[i]);
                        }
                        table = new List<string>();
                        break;

                    }
                    else if (firstNum < secondNum)
                    {
                        for (int i = 0; i < table.Count; i++)
                        {
                            secondPlayerQueue.Enqueue(table[i]);
                        }
                        table = new List<string>();
                        break;
                    }
                }
            }
            if (firstPlayerQueue.Count < secondPlayerQueue.Count)
            {
                Console.WriteLine($"Second player wins after {turnCounter} turns");
            }
            else if (firstPlayerQueue.Count > secondPlayerQueue.Count)
            {
                Console.WriteLine($"First player wins after {turnCounter} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turnCounter} turns");
            }
        }
    }
}