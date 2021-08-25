using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // GetSingleDigitNumbers();
            foreach (var item in func(2,10))
            {
                Console.WriteLine(item);
            }
            foreach (var item in GetSingleDigitNumbers())
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<int> GetSingleDigitNumbers()
        {
            int index = 0;
            while (index < 10)
                
                yield return index++;

            yield return 50;

            index = 100;
            while (index < 110)
                yield return index++;
        }

        public static IEnumerable<int> func(int start, int number)
        {
            for (int i = 0; i < number; i++)
            {
                yield return start + 2 * 1;
            }
        }
    }
}