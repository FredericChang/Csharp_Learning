using System;
namespace Csharp_V8_Interface_Net5
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}