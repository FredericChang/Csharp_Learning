using System;

namespace base_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DerivedClass md = new DerivedClass();
            DerivedClass md1 = new DerivedClass(1);
        }
    }

    public class BaseClass
    {
        private int num;

        public BaseClass()
        {
            Console.WriteLine("in BaseClass()");
        }
        public BaseClass(int i)
        {
            num = i;
            Console.WriteLine("in BaseClass(int 1)");
        }

        public int GetNum()
        {
            return num;
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass() : base()
        {
            
        }
        public DerivedClass(int i) : base(i)
        {
            
        }
        
        
    }
}