using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Where
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            int[] numbers = {5, 4, 11, 22, 44, 5, 66, 665, 53};

            var queryTest = from number in numbers where number < 22 select number;
            foreach (var number in queryTest)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            var queryTest2 = from number in numbers where number <= 22 && number % 11 == 0 select number;
            foreach (var number in queryTest2)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            var queryTest3 = 
                from number in numbers 
                where number <= 22 
                where number >= 12 
                select number;
            foreach (var number in queryTest3)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            
            Console.WriteLine("IsEven");

            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var queryEvenNums =
                from num in numbers
                where IsEven(num)
                select num;
            foreach (var number in queryEvenNums)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            Console.WriteLine("IsNotEven");

            var queryEvenNums2 =
                from num in numbers
                where IsNotEven(num)
                select num;
            foreach (var number in queryEvenNums2)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            
        }

        private static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
        private static bool IsNotEven(int i)
        {
            return i % 2 != 0;
        }
    }
}