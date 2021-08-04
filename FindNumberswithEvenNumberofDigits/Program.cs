using System;

namespace FindNumberswithEvenNumberofDigits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] {555, 901, 482, 1771};
            var a = FindNumbers(array);
            Console.WriteLine(a);
        }
        public static int FindNumbers(int[] nums)
        {
            int digitsWithEven = 0;
            var i = 0;
            foreach (var item in nums)
            {
                var x = Math.Floor(Math.Log10(item) + 1);
                
                if (x % 2 == 0)
                {
                    i++;
                }
                // if (item % 2 % 2 == 0  &&　item != 2)
                // {
                //     digitsWithEven++;
                // } 
            }

            return i;
        }
    }
}