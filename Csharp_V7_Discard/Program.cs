using System;

namespace Csharp_V7_Discard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var (_, _, _, pop1, _, pop2) = QueryCityDatForYears("New York City", 1960, 2010);
            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
            (_, _, _, pop1, _, pop2) = QueryCityDatForYears("New York City", 1966, 2010);
            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
            
            static (string, double, int, int, int, int) QueryCityDatForYears(string name, int year1, int year2)
            {
                int population1 = 0, population2 = 0;
                double area = 0;
                if (name == "New York City")
                {
                    area = 468.48;
                    if (year1 == 1960)
                    {
                        population1 = 778198;
                    }
                    if (year1 == 2010)
                    {
                        population2 = 8175133;
                    }
                    return (name, area, year1, population1, year2, population2);

                }
                
                return ("", 0, 0, 0, 0, 0);
            }
            //static is from C#8.0

            //reference
            //https://docs.microsoft.com/zh-tw/dotnet/csharp/fundamentals/functional/discards
            //https://docs.microsoft.com/zh-tw/dotnet/csharp/fundamentals/functional/deconstruct#tuple-elements-with-discards
            
        }
    }
}