using System;

namespace Delegate
{

    delegate void D(int x);

    class C
    {
        public static void M1(int i) 
        {
            Console.WriteLine("C.M1: " + i);
        }

        public static void M2(int i) 
        {
            Console.WriteLine("C.M2: " + i);
        }

        public void M3(int i)
        {
            Console.WriteLine("C.M3: " + i);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            D cd1 = new D(C.M1);
            cd1(-1);                // call M1
            D cd2 = new D(C.M2);
            cd2(-2);                // call M2
            D cd3 = cd1 + cd2;
            cd3(10);                // call M1 then M2
            Console.WriteLine("Here");
            cd3 += cd1;
            cd3(20);
            Console.WriteLine("Here");
            C c = new C();
            D cd4 = new D(c.M3);
            cd3 += cd4;
            cd3(30);
            Console.WriteLine("Here");
            cd3 -= cd1;             // remove last M1
            cd3(40);                // call M1, M2, then M3
            Console.WriteLine("Here");
            cd3 -= cd4;
            cd3(50);                // call M1 then M2
            Console.WriteLine("Here");
            cd3 -= cd2;
            cd3(60);                // call M1
            Console.WriteLine("Here");

            cd3 -= cd2;             // impossible removal is benign
            cd3(60);                // call M1
            Console.WriteLine("Here");

            cd3 -= cd1;             // invocation list is empty so cd3 is null
            Console.WriteLine("70");

            cd3(70);                // System.NullReferenceException thrown
            Console.WriteLine("Here");

            cd3 -= cd1;             // impossible removal is benign
        }
    }
}