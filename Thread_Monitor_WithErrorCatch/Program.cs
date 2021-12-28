using System;
using System.IO;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace Thread_Monitor_WithErrorCatch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var t = new Thread(FaultyThread);
            t.Start();
            t.Join();

            try
            {
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch
            {
                WriteLine("We won't get here!");
            }
        }
        
        static void BadFaultyThread()
        {
            WriteLine("Starting a faulty thread...  from BadFaultyThread");
            Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");
        }
        
        static void FaultyThread()
        {
            try
            {
                WriteLine("Starting a faulty thread...  from FaultyThread");
                Sleep(1000);
                throw new Exception("Boom");
            }
            catch (Exception ex)
            {
                WriteLine($"Exception handled: {ex.Message}");
            }
        }
    }

}