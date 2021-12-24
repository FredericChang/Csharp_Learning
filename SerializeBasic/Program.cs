using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace SerializeBasic
{
    public class WeatherForcast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            var weatherForcast = new WeatherForcast
            {
                Date = DateTime.Parse("2019-09-09"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string jsonString = JsonSerializer.Serialize(weatherForcast);
            Console.WriteLine(jsonString); 
        }
    }
}