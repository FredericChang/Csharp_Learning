using System;
using System.Threading;


namespace Thread_Status
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting from here");
            Thread t1 = new Thread(Donotthing);
            Thread t2 = new Thread(printNumberWithStatus);
            Console.WriteLine("t1.ThreadState" + t1.ThreadState.ToString()); 
            t2.Start();
            t1.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("t1.ThreadState" + t1.ThreadState.ToString() +" "+ i);
            }
            Thread.Sleep(5000);
            t1.Abort();
            Console.WriteLine("A Thread has been aborted");
            Console.WriteLine("t1.ThreadState" + t1.ThreadState.ToString()); 
            Console.WriteLine("t2.ThreadState" + t2.ThreadState.ToString());
        }

        static void Donotthing()
        {
            Console.WriteLine("Donotthing, Thread");
            Thread.Sleep(2000);
        }
        
        static void printNumberWithStatus()
        {
            Console.WriteLine("Starting"); 
            Console.WriteLine("printNumberWithStatus_Inital" + Thread.CurrentThread.ToString());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("printNumberWithStatus" + Thread.CurrentThread.ToString()+ "  "+ i);
                Thread.Sleep(2000);

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