using System;
using System.Collections.Generic;
using System.Globalization;

namespace Csharp_V8_Interface
{
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }
    }
}