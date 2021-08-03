using System;
using System.Collections.Generic;
using System.Globalization;

namespace Csharp_V8_Interface
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}