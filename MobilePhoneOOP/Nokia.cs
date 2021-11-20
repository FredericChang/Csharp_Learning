using System;

namespace MobilePhoneOOP
{
    public class Nokia : Mobile
    {
        public void GetBlueToothConnection()
        {
            Console.WriteLine();
        }

        public override void SendMessage()
        {
            Console.WriteLine("Message from Nokia Mobile Phone");
        }
    }
}