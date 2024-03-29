﻿using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using ConsumberScooterResigstration;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Csharp_V8_Switch
{
    internal class Program
    {

        public class TollCalculator
        {
   
            public static bool IsWeekDay(DateTime timeOfToll) => timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true,
            };
            private enum TimeBand
            {
                MorningRush,
                Daytime,
                EveningRush,
                Overnight
            }

            private static TimeBand GetTimeBand(DateTime timeOfToll) => timeOfToll.Hour switch
            {
                < 6 or > 19 => TimeBand.Overnight,
                < 10 => TimeBand.MorningRush,
                < 16 => TimeBand.Daytime,
                _ => TimeBand.EveningRush,
            };

            public decimal PeakTimePremiumFull(DateTime timeOfToll, bool isBound) =>
                (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), isBound) switch
                {
                    (true, TimeBand.MorningRush, true) => 2.00m,
                    (true, TimeBand.MorningRush, false) => 1.00m,
                    (true, TimeBand.Daytime, _) => 1.50m,
                    (true, TimeBand.EveningRush, true) => 1.00m,
                    (true, TimeBand.EveningRush, false) => 2.00m,
                    //(true, TimeBand.Overnight, true) => 0.75m,
                    //(true, TimeBand.Overnight, false) => 0.75m,
                    //(false, TimeBand.MorningRush, true) => 1.00m,
                    //(false, TimeBand.MorningRush, false) => 1.00m,
                    //(false, TimeBand.Daytime, true) => 1.00m,
                    //(false, TimeBand.Daytime, false) => 1.00m,
                    //(false, TimeBand.EveningRush, true) => 1.00m,
                    //(false, TimeBand.EveningRush, false) => 1.00m,
                    //(false, TimeBand.Overnight, true) => 1.00m,
                    //(false, TimeBand.Overnight, false) => 1.00m,
                    (false, _, _) => 1.0m,
                    (true, TimeBand.Overnight, _) => 0.75m,

                };
            public decimal PeakTimePremiumIfElse(DateTime timeOfToll, bool inbound)
            {
                if ((timeOfToll.DayOfWeek == DayOfWeek.Saturday) ||
                        (timeOfToll.DayOfWeek == DayOfWeek.Sunday))
                {
                    return 1.0m;
                }
                else
                {
                    int hour = timeOfToll.Hour;
                    if (hour < 6)
                    {
                        return 0.75m;
                    }
                    else if (hour < 10)
                    {
                        if (inbound)
                        {
                            return 2.0m;
                        }
                        else
                        {
                            return 1.0m;
                        }
                    }
                    else if (hour < 16)
                    {
                        return 1.5m;
                    }
                    else if (hour < 20)
                    {
                        if (inbound)
                        {
                            return 1.0m;
                        }
                        else
                        {
                            return 2.0m;
                        }
                    }
                    else
                    {
                        return 0.75m;
                    }
                    //Overnight
                }
            }
            public decimal CalculateToll(object vehicle) =>
                vehicle switch
                {
                    scotter s => s.Passengers switch
                    {
                        0 => 2.00m + 0.5m,
                        1 => 2.00m,
                        2 => 2.00m,
                        _ => 1.55m,
                    },

                    Car { Passengers: 0 } => 2.00m + 0.50m,
                    Car { Passengers: 1 } => 2.0m,
                    Car { Passengers: 2 } => 2.0m - 0.50m,
                    Car c => 2.00m - 1.0m,

                    Taxi { Fares: 0 } => 3.50m + 1.00m,
                    Taxi { Fares: 1 } => 3.50m,
                    Taxi { Fares: 2 } => 3.50m - 0.50m,
                    Taxi t => 3.50m - 1.00m,



                    Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
                    Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
                    Bus b => 5.00m,

                    DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
                    DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
                    DeliveryTruck t => 10.00m,

                    { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                    null => throw new ArgumentNullException(nameof(vehicle))
                };

        }

        public static void Main(string[] args)
        {
            
            var numbers = new int[] { 10, 20, 30, 40, 50, 60, 70 };
            Console.WriteLine(GetSourceLabel(numbers));  // output: 1

            var letters = new List<char> { 'a', 'b', 'c', 'd' };
            Console.WriteLine(GetSourceLabel(letters));  // output: 2

            static int GetSourceLabel<T>(IEnumerable<T> source) => source switch
            {
                Array array => 1,
                ICollection<T> collection => 2,
                _ => 3,
            };
        //   First set of test code
            //var tollCalc = new TollCalculator();

            //var car = new Car();
            //var taxi = new Taxi();
            //var bus = new Bus();
            //var truck = new DeliveryTruck();

            //Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
            //Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
            //Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
            //Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");

            //try
            //{
            //    tollCalc.CalculateToll("this will fail");
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("Caught an argument exception when using the wrong type");
            //}
            //try
            //{
            //    tollCalc.CalculateToll(null!);
            //}
            //catch (ArgumentNullException e)
            //{
            //    Console.WriteLine("Caught an argument exception when using null");
            //}


            //2nd test(after adding for occupants)

            var tollCalc = new TollCalculator();
            //Car { Passengers: 0}        => 2.00m + 0.50m,
            //Car { Passengers: 1}        => 2.0m,
            //Car { Passengers: 2}        => 2.0m - 0.50m,
            //Car c                      => 2.00m - 1.0m,

            //Taxi { Fares: 0}  => 3.50m + 1.00m,
            //Taxi { Fares: 1}  => 3.50m,
            //Taxi { Fares: 2}  => 3.50m - 0.50m,
            //Taxi t           => 3.50m - 1.00m,

            //Bus b when((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
            //Bus b when((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
            //Bus b => 5.00m,

            //DeliveryTruck t when(t.GrossWeightClass > 5000) => 10.00m + 5.00m,
            //DeliveryTruck t when(t.GrossWeightClass < 3000) => 10.00m - 2.00m,
            //DeliveryTruck t => 10.00m,

            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emptyTaxi = new Taxi();
            var singleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };
            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for a solo driver is {tollCalc.CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {tollCalc.CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {tollCalc.CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {tollCalc.CalculateToll(fullVan)}");

            Console.WriteLine($"The toll for an empty taxi is {tollCalc.CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {tollCalc.CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {tollCalc.CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {tollCalc.CalculateToll(fullVanPool)}");

            Console.WriteLine($"The toll for a low-occupant bus is {tollCalc.CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {tollCalc.CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(fullBus)}");

            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(lightTruck)}");

            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalc.CalculateToll(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }



            Console.WriteLine("Testing the time premiums");

            var testTimes = new DateTime[]
            {
                new DateTime(2019, 3, 4, 8, 0, 0), // morning rush
                new DateTime(2019, 3, 6, 11, 30, 0), // daytime
                new DateTime(2019, 3, 7, 17, 15, 0), // evening rush
                new DateTime(2019, 3, 14, 03, 30, 0), // overnight

                new DateTime(2019, 3, 16, 8, 30, 0), // weekend morning rush
                new DateTime(2019, 3, 17, 14, 30, 0), // weekend daytime
                new DateTime(2019, 3, 17, 18, 05, 0), // weekend evening rush
                new DateTime(2019, 3, 16, 01, 30, 0), // weekend overnight
            };

            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalc.PeakTimePremiumIfElse(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalc.PeakTimePremiumIfElse(time, false)}");
            }
            Console.WriteLine("====================================================");
            foreach (var time in testTimes)
            {
                Console.WriteLine($"Inbound premium at {time} is {tollCalc.PeakTimePremiumFull(time, true)}");
                Console.WriteLine($"Outbound premium at {time} is {tollCalc.PeakTimePremiumFull(time, false)}");
            }


        }
    }
}