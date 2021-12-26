using System;
using System.Threading;
namespace Thread_Start
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Thread t = new Thread(printNumber);
            t.Start();
            printNumber();
        }

        static void printNumber()
        {
            Console.WriteLine("Starting"); 
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}