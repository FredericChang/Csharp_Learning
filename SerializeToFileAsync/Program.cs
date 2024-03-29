﻿using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializeToFileAsync
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string fileName = "WeatherForecast.json";
            using FileStream createStream = File.Create(fileName);
            // await using var stream = new FileStream(fileName, FileMode.Create);
            await JsonSerializer.SerializeAsync(createStream, weatherForecast);
            createStream.Dispose();

            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}