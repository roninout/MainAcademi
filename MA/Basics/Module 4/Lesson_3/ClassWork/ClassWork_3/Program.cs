using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> ht = new Dictionary<int, string>();

            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht[1] = "Four";
            foreach (var item in ht)
                Console.WriteLine(item);

            Queue queue = new Queue();

            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("four");

            foreach (var item in queue)
                Console.WriteLine(item);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            Console.ReadKey();
        }
    }
}
