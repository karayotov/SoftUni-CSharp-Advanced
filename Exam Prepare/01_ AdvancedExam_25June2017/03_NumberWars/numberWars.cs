using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    class numberWars
    {
        static void Main(string[] args)
        {
            List<string> firstPLayerList =
                Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> secondPLayerList = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> noMansCards = new List<string>();

            Queue<string> firstPlayerQueue = new Queue<string>(firstPLayerList);
            Queue<string> secondPlayerQueue = new Queue<string>(secondPLayerList);

            firstPLayerList.Clear();
            secondPLayerList.Clear();

            int firstPlayerHand = 0;
            int secondPlayerHand = 0;
            int firstHandNum;
            char firstHandChar;
            int secondHandNum;
            char secondHandChar;

            int leftSumCards = 0;
            int rightSumCards = 0;

            string firstSingleCard = String.Empty;
            string secondSingleCard = String.Empty;

            while (true)
            {
                firstSingleCard = firstPlayerQueue.Dequeue();
                secondSingleCard = secondPlayerQueue.Dequeue();

                noMansCards.Add(firstSingleCard);
                noMansCards.Add(secondSingleCard);

                noMansCards.OrderByDescending(x => x);

                if (firstSingleCard < secondSingleCard)
                {
                    //todo
                }
                else if (firstHandNum > secondHandNum)
                {
                    //todo
                }
                else
                {
                    if (firstHandChar < secondHandChar)
                    {
                        //todo
                    }
                    else if (firstHandChar > secondHandChar)
                    {
                        //todo
                    }
                    else
                    {
                        for (int moreCards = 0; moreCards < 3; moreCards++)
                        {
                            firstSingleCard = firstPlayerQueue.Dequeue();
                            secondSingleCard = secondPlayerQueue.Dequeue();

                            secondHandNum = int.Parse(firstSingleCard.Remove(secondSingleCard.Length - 1));
                            firstHandNum = int.Parse(secondSingleCard.Remove(secondSingleCard.Length - 1));


                        }
                    }
                }
            }
        }
    }
}
