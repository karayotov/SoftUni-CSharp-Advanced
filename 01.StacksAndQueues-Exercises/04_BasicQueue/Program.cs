using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BasicQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var nsx = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nsx[0];
            var s = nsx[1];
            var x = nsx[2];

            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(inputLine[i]);
            }

            for (int j = 0; j < s; j++)
            {
                queue.Dequeue();

            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");

            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
