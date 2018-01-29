using System;
using System.Collections.Generic;

class RecursiveFibonacci
{
    static void Main()
    {
        byte fibonachiIndex = byte.Parse(Console.ReadLine());

        Queue<long> queue = new Queue<long>(2);
        long a = 1;
        long b = 1;
        queue.Enqueue(a);
        queue.Enqueue(b);
        long c;

        for (int i = 2; i <= fibonachiIndex; i++)
        {
            
            c =  a + b;
            a = b;
            b = c;
            

            queue.Dequeue();

            if (i != fibonachiIndex)
            {
                queue.Enqueue(c);
            }
            else
            {
                Console.WriteLine(queue.Peek());
            }
        }
    }
}