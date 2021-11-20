using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneOOP
{
    public class Samsung : Mobile
    {
        public void GetWIFIConnection()
        {
            Console.WriteLine();
        }

        public void CameraClick()
        {
            Console.WriteLine();
        }
        
        public void CameraClick(string CemeraMode)
        {
            Console.WriteLine("Camera clicked in" + CemeraMode);
        }
    }
}