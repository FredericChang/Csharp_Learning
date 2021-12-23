using System.Collections.Generic;
using MobilePhoneOOP.Interface;

namespace MobilePhoneOOP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<IMobile> Dial = new List<IMobile>();
            Dial.Add(new Nokia());
            Dial.Add(new Samsung());
            foreach (var o in  Dial)
            {
                o.Dial();
            }
        }
    }
}