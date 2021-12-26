using System;
using System.Threading;


namespace Thread_Join
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting.....");
            Thread t = new Thread(printNumberWithDelay);
            t.Start();
            t.Join();
            Console.WriteLine("Thread End");

            // printNumberWithDelay();
        }

        static void printNumber()
        {
            Console.WriteLine("Starting"); 
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        
        static void printNumberWithDelay()
        {
            Console.WriteLine("Starting"); 
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(i);
            }
        }
    }
}