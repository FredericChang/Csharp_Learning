using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_V9_Record
{
    internal class Program
    {
        public double BaseTemperature = 65;
        public record DailyTemperature(double HighTemp, double LowTemp)
        {
            public double Mean => (HighTemp + LowTemp) / 2.0;
            public double HighTemp { get; } = HighTemp;
            public double LowTemp { get; } = LowTemp;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("HeatingDegreeDays");
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
        protected virtual bool PrintMembers(StringBuilder stringBuilder)
        {
            stringBuilder.Append($"BaseTemperature = {BaseTemperature}");
            return true;
        }

        public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        {
            public double BaseTemperature { get; set; } = BaseTemperature;
            public IEnumerable<DailyTemperature> TempRecords { get; } = TempRecords;
        }

        public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
        }

        public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
        }

        private static DailyTemperature[] data = new DailyTemperature[]
        {
            new DailyTemperature(HighTemp: 57, LowTemp: 30),
            new DailyTemperature(60, 35),
            new DailyTemperature(63, 33),
            new DailyTemperature(68, 29),
            new DailyTemperature(72, 47),
            new DailyTemperature(75, 55),
            new DailyTemperature(77, 55),
            new DailyTemperature(72, 58),
            new DailyTemperature(70, 47),
            new DailyTemperature(77, 59),
            new DailyTemperature(85, 65),
            new DailyTemperature(87, 65),
            new DailyTemperature(85, 72),
            new DailyTemperature(83, 68),
            new DailyTemperature(77, 65),
            new DailyTemperature(72, 58),
            new DailyTemperature(77, 55),
            new DailyTemperature(76, 53),
            new DailyTemperature(80, 60),
            new DailyTemperature(85, 66)
        };  
        public static void Main(string[] args)
        {
            
            foreach (var item in data)
                Console.WriteLine(item);


            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            Console.WriteLine(heatingDegreeDays);


            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            Console.WriteLine(coolingDegreeDays);

            var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 };
            Console.WriteLine(growingDegreeDays);
        }
    }
}