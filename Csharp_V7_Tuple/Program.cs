using System;
using System.ComponentModel;

namespace Csharp_V7_Tuple
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            (string Alpha, string Beta, string gamma) nameLetters = ("a","b","c");
            Console.WriteLine($"{nameLetters.Alpha}, {nameLetters.Beta}, {nameLetters.gamma}");
            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha},{alphabetStart.Beta}");

            var p = new Point(3.14, 7.12);
            (double X, double Y) = p;
            
            var result = QueryCityData("New York City");
            var city = result.Item1;
            var pop = result.Item2;
            var size = result.Item3;

            var xs = new[] {1, 2, 3};
            var limits = FindMinMax(xs);
            Console.WriteLine($"Limits of [{string.Join(" ",xs)}] are {limits.min} and {limits.max}");
            
            var ys = new[] { -9, 0, 67, 100 };
            var (minimum, maximum) = FindMinMax(ys);
            Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");

            
            (int min, int max) FindMinMax(int[] input)
            {
                if (input is null || input.Length == 0)
                {
                    throw new ArgumentException("there're not numbers in tuple");
                }

                var min = int.MaxValue;
                var max = int.MinValue;
                foreach (var i in input)
                {
                    if (i < min)
                    {
                        min = i;
                    }

                    if (i > max)
                    {
                        max = i;
                    }
                }
                return (min, max);
            }

        }
        private static (string, int, double) QueryCityData(string name)
        {
            if (name == "New York City")
                return (name, 8175133, 468.48);

            return ("", 0, 0);
            //if string name is not the same will be discarded directly.
        }
    }

    public class Point
    {
        public Point(double x, double y) => (X, Y) = (x, y);
        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
    }

}