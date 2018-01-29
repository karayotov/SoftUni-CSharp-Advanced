using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Queue<long> queue = new Queue<long>();
        

        long s1 = n, s2, s3, s4;

        queue.Enqueue(s1);

        int loop = 50;

        while (queue.Count <= loop)
        {
            var s = queue.Dequeue();

            Console.Write(s + " ");

            s2 = s + 1;
            s3 = 2 * s + 1;
            s4 = s + 2;
            
            queue.Enqueue(s2);
            queue.Enqueue(s3);
            queue.Enqueue(s4);

            loop --;

        }
        while (loop-- > 0)
        {
            Console.Write(queue.Dequeue() + " ");
        }
    }
}