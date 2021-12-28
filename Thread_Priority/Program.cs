using System;
using System.Threading;
using System.Diagnostics;



namespace Thread_Priority
{
    internal class Program
    {
        class ThreadSample
        {
            private bool _isStopped = false;

            public void Stop()
            {
                _isStopped = true;
            }

            public void CountNumbers()
            {
                long counter = 0;

                while (!_isStopped)
                {
                    counter++;
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} with" +
                                  $"{Thread.CurrentThread.Priority, 11} priority " +
                                  $"has a count = {counter} ");
            }
        }
        static void RunThreads()
        {
            var sample = new ThreadSample();

            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOne";
            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";
            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();
            
            Thread.Sleep(2000);
            sample.Stop();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine($"Current thread priority : {Thread.CurrentThread.Priority}");
            Console.WriteLine("Running on a single core");
            RunThreads();
            Thread.Sleep(2000);
            Console.WriteLine("Running on a single core");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();

        }
    }
}