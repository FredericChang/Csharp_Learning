using System;

namespace random_Double2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random a = new Random(1);
            double aa = 0;
            aa = NextDouble(a, 1, 5);
            Console.WriteLine(aa);
            var rand = new Random();

            for (int ctr = 0; ctr <= 4; ctr++)
            {
                
                Console.Write("{0,10:N4}", rand.NextDouble() * 5);
            }
                
        }
        
        public static double NextDouble(Random RandGenerator, double MinValue, double MaxValue)
        {
            return RandGenerator.NextDouble() * (MaxValue - MinValue) + MinValue;
        }

    }
}