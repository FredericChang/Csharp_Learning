using System;
using System.Linq;

namespace Csharp_V8_Interface
{
    class Program
    {
        public static void Main(string[] args)
        {
            SampleCustomer c = new SampleCustomer("Customer Frederic", new DateTime(2020, 8, 24))
            {
                Reminders =
                {
                    { new DateTime(2020, 8, 25), "Birth"},
                    { new DateTime(2020, 8, 26), "Birth2"}
                }
            };
            
            SampleOrder o = new SampleOrder(new DateTime(2020, 9, 22), 5m);
            c.AddOrder(o);
            o = new SampleOrder(new DateTime(2020, 9, 23), 25m);
            c.AddOrder(o);
            
            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            
            foreach (var item in c.Reminders)
            {
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            }
            foreach (IOrder order in c.PreviousOrders)
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");

        }

        // public decimal ComputeLoyaltyDiscount()
        // {
        //     DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        //     if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
        //     {
        //         return 0.10m;
        //     }
        //
        //     return 0;
        // }
        
        //reference
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
        /*
            Methods
            Properties
            Indexers
            Events
         */
        /* C#8.0
            Constants
            Operators
            Static constructor.
            Nested types
            Static fields, methods, properties, indexers, and events
            Member declarations using the explicit interface implementation syntax.
            Explicit access modifiers (the default access is public).
         */
    }
}