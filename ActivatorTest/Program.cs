using System;
using System.Reflection;
using System.Text;

namespace ActivatorTest
{
    internal class sometye
    {
        public void Dosomething(int x)
        {
            Console.WriteLine("100/ {0} = {1}", x, 100/100);
        }
    }
    internal class Program
    {
        private static string instanceSpec =
            "System.EventArgs;System.Random;" + "System.Exception;System.Object;System.version";
        
        public static void Main(string[] args)
        {
            Object o = Activator.CreateInstance(typeof(StringBuilder));

            StringBuilder sb = (StringBuilder)o;
            sb.Append("Hello");
            Console.WriteLine(sb);

            System.Runtime.Remoting.ObjectHandle oh =
                Activator.CreateInstance(Assembly.GetEntryAssembly().CodeBase, typeof(sometye).FullName);
            sometye st = (sometye)oh.Unwrap();
            st.Dosomething(5);
        }
    }
}