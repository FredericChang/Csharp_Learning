using System;

namespace Csharp_V8_Interface
{
    public class SampleOrder:IOrder
    {
        public SampleOrder(DateTime purchase, decimal cost) =>
            (Purchased, Cost) = (purchase, cost);
        public DateTime Purchased { get; }
        public decimal Cost { get; }
    }
}