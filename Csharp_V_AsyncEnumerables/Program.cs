using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Csharp_V_AsyncEnumerables
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            static IEnumerable<int> Range(int start, int count)
            {
                for (int i = 0; i < count; i++)
                    yield return start + i;
                //此示例顯示使用“yield return”創建 IEnumerable<T>
                //IEnumerable C# 2.0
                //.NET Framework 4 System.Threading.Tasks.Task 和 Task<T>
                //.NET Framework 4.5 和 C# 5，它引入了 async 和 await 
            }
            foreach (int item in Range(10, 3))
                Console.Write(item + " "); // prints 10 11 12

            static async Task PrintAsync(string format, int iteraions, int delayMilliseconds)
            {
                Console.WriteLine("goto PrintAsync");

                for (int i = 0; i < iteraions; i++)
                {
                    Console.WriteLine("goto PrintAsync_For");

                    await Task.Delay(delayMilliseconds);
                    Console.WriteLine("delayMilliseconds");
                }
            }
            Console.WriteLine("goto await PrintAsync");
            await PrintAsync("Iteration {0}", 5, 1_000);
            //should correct
            //static async Task Main(string[] args)
        }
    }
}

//reference
//https://docs.microsoft.com/zh-tw/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8