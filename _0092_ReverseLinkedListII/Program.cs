using System;
using System.Linq;

namespace _0092_ReverseLinkedListII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] {1,2,3,4,5 };
            // var test = Reservse(array);
            // Console.WriteLine(test);
            var test2 = between(array, 3, 5);
            
        }

        public static int[] between(int[] nums, int x, int y)
        {
            int[] array = new int[nums.Length];
            if (nums.Length == 0)
            {
                return null;
            }

            int xx = 0;
            for (int i = x; i < y; i++)
            {
                var ggg = nums[i-1];
                array[xx]=(nums[i-1]);
                xx++;
            }
            Array.Resize(ref array,xx+1);

            var xxx = Reservse(array);
            
            return array;
        }

        public static int[] Reservse(int[] nums)
        {
            int first = 0;
            int last = 0;
            int account = nums.Length - 1;
            for (int run = 0; run < account; run++)
            {
                last = nums[account];
                first = nums[run];
                nums[run] = last;
                nums[account] = first;
                account -= 1;
                
            }
            foreach(int value in nums)
            {
                Console.Write(value + " ");
            }

            return nums;
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