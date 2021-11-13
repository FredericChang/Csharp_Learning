using System;
using System.Globalization;
using System.Linq;


namespace _739_DailyTemperatures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array1 = new[] { 73,74,75,71,69,72,76,73 };
            var aa = DailyTemperatures(array1);
            foreach (var a in aa)
            {
                Console.WriteLine(a);
            }
            


        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            int a = 0;
            for (int i = 0; i < temperatures.Length-1 ; i++)
            {
                for (int y = i+1 ; y < temperatures.Length; y++)
                {
                    if (temperatures[i] < temperatures[y])
                    { 
                        a = y - i;
                        result[i] = a;
                        break;
                    }
                    if ( y == temperatures.Length)
                    {
                        result[i] = 0;
                    }
                }
            }
            
            return result;
            
        }
    }
}