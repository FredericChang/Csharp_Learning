using System;
using MobilePhoneOOP.Interface;

///https://www.c-sharpcorner.com/UploadFile/cda5ba/object-oriented-programming-with-real-world-scenario/
/// Reference
/// https://www.codeproject.com/Articles/22769/Introduction-to-Object-Oriented-Programming-Concep
namespace MobilePhoneOOP
{
    public class Mobile : ITelephone, IMobile
    {
        private string IEMIcode { get; set; }
        public string SIMCard { get; set; }
        public string Processor { get; }
        public int InternalMemory { get; }
        public bool IsSignalSIM { get; set; }

        public void GetIEMIcode()
        {
            Console.WriteLine("IEMI Code - IEDF3434");
        }


        public void Receive()
        {
            Console.WriteLine();
        }

        public virtual void SendMessage()
        {
            Console.WriteLine();
        }

        public void Dial()
        {
            throw new NotImplementedException();
        }
    }
}