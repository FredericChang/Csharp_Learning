using System;
using System.IO;
using System.Text.Json;

namespace SerializeToFile
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {

            var weatherForecast = new WeatherForecast()
            {
                Date = DateTime.Parse("2021-12-23"),
                TemperatureCelsius = 33,
                Summary = "Cold"
            };

            string fileName = "WetherForecast.json";
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}