using System;
using System.IO;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Thread_Background
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // FileStream fs = new FileStream("Test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            // // First, save the standard output.
            // TextWriter tmp = Console.Out;
            // StreamWriter sw = new StreamWriter(fs);
            // SetOut(sw);
            // Console.WriteLine("Hello file");
            // Console.SetOut(tmp);
            // Console.WriteLine("Hello World");
            
            var sampleForeground = new ThreadSample(10);
            var sampleBackground = new ThreadSample(20);

            var threadOne = new Thread(sampleForeground.CountNumbers);
            threadOne.Name = "ForegroundThread";
            var threadTwo = new Thread(sampleBackground.CountNumbers);
            threadTwo.Name = "BackgroundThread";
            threadTwo.IsBackground = true;
            
            threadOne.Start();
            threadTwo.Start();
            // sw.Close();
        }

        class ThreadSample
        {
            private readonly int _iterations;

            public ThreadSample(int iterations)
            {
                _iterations = iterations;
            }

            public void CountNumbers()
            {
                for (int i = 0; i < _iterations; i++)
                {
                    Sleep(500);
                    WriteLine($"{CurrentThread.Name} prints {i}");
                }
            }
        }
    }
}