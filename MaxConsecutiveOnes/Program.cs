using System;
using System.Globalization;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 0, 1, 1, 0, 1 };
            //Given a binary array nums, return the maximum number of consecutive 1's in the array.
            var a = FindMaxConsecutiveOnes(array1);
            Console.WriteLine(a);
        }
        public static int FindMaxConsecutiveOnes(int[] nums) {
            var i = 0;
            var z = 0;
            var x = 0;
            foreach (var item in nums ){
                i++;
                if (item == 1){
                    z++;
                } 
                if (item == 0){
                
                    z=0;
                }
                if(z > x)
                {
                    x = z;
                }
            }
            return x;
        }
    }
}