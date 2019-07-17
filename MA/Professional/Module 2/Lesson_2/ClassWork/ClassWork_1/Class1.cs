using System;
using System.Threading;

namespace ClassWork_1
{
    public class Class1
    {
        public static void OnlyThreadMeth()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Counter: {i}, thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }
        }

        public static void FirstThread()
        {
            ThreadStart starter = new ThreadStart(OnlyThreadMeth);
            Thread thr_1 = new Thread(starter);
            Thread thr_2 = new Thread(starter);

            thr_1.Start();
            thr_2.Start();

            thr_1.Join();
            thr_2.Join();

            Console.Read();
        }
    }
}
