namespace ConsumerVehicleRegistration
{
    public class Car
    {
        public int Passengers { get; set; }
    }
}

namespace CommercialRegistration
{
    public class DeliveryTruck
    {
        public int GrossWeightClass { get; set; }
    }
}

namespace LiveryRegistration
{
    public class Taxi
    {
        public int Fares { get; set; }
    }

    public class Bus
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }
    }
}

namespace ConsumberScooterResigstration
{
    interface IScotter
    {
        int Passengers
        {
            get;
            set;
        }
        string Brand
        {
            get;
            set;
        }
        double Distance
        {
            get;
        }
        double calculated(string scotterBrand);
    }
    public class scotter:IScotter
    {
        public scotter(int passengers, string brand)
        {
            Passengers = passengers;
            Brand = brand;

        }

        // Property implementation:
        public int Passengers { get; set; }

        public string Brand { get; set; }

        public double Distance =>
            calculated(Brand);

        public double calculated(string scotterBrand)
        {
            double value = 0;
            switch (scotterBrand)
            {
                case "VOI":
                    value = 10;
                    break;
                case "LIME":
                    value = 20;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;

        }
    }
}