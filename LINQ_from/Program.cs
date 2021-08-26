using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_from
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[] upperCase = {'A', 'B', 'C'};
            char[] lowerCase = {'x', 'y', 'z'};

            var joinQuery1 = 
                from upper in upperCase 
                from lower in lowerCase 
                select new {upper, lower};

            var joinQuery2 = 
                from lower in lowerCase
                where lower != 'x'
                from upper in upperCase
                select new {upper, lower};

            Console.WriteLine("Cross join:");

            foreach (var pair in joinQuery1)
            {
                Console.WriteLine("{0} is matched to {1}", pair.lower, pair.upper);   
            }
            
            Console.WriteLine("Filtered non-equijoin:");
            // Rest the mouse pointer over joinQuery2 to verify its type.
            foreach (var pair in joinQuery2)
            {
                Console.WriteLine("{0} is matched to {1}", pair.lower, pair.upper);
            }

        }
    }
}