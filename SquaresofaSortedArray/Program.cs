using System;
using System.Linq;

namespace SquaresofaSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] {-4,-1,0,3,10 };
            var test = SortedSquares(array);

        }
        public static int[] SortedSquares(int[] nums)
        {
            int[] result = new int[] { };
            for (int run = 0; run < nums.Length; run++)
            {
                var a  = nums[run] *　nums[run];
                Console.WriteLine(a.ToString());
                result.Append(a);
                
            }
            int temp;

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i] > result[j])
                    {
                        temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                        
                    }
                }
            }

            foreach(int value in result)
            {
                Console.Write(value + " ");
            }

            return result;
        }
    }
}