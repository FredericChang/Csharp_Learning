using System;


namespace Csharp_V7_Is
{
    public class Base { }
//create a empty Class here
    public class Derived : Base { }

    internal class Program
    {
        static bool IsFirstSummerMonday(DateTime date) => date is {Month: 8, Day: <= 7, DayOfWeek: DayOfWeek.Sunday};
        //<= is avaiable for C#9
        static bool IsFirstSummer(DateTime date) => date is {Month: 8, Day: 1, DayOfWeek: DayOfWeek.Sunday};
        //Month: 8, Day: 1, DayOfWeek: DayOfWeek.Sunday is avaiable for C#8

        //inherit a class of Base{}
        public static void Main(string[] args)
        {
            
            int i = 34;
            object iBoxed = i;
            int? jNullable = 42;
            if (iBoxed is int a && jNullable is int b)
            {
                Console.WriteLine(a + b); // output 76
            }

            int ii = 27;
            Console.WriteLine(ii is System.IFormattable);
            object iBoxed2 = ii;
            Console.WriteLine(iBoxed2 is int);
            Console.WriteLine(iBoxed2 is long);

            object Objectb = new Base();
            Console.WriteLine("Objectb is Base: " + (Objectb is Base));
            Console.WriteLine("Objectb is Base: " + (Objectb is Derived));
            
            object Objectb2 = new Derived();
            Console.WriteLine("Objectb2 is Derived: " + (Objectb2 is Base));
            Console.WriteLine("Objectb2 is Derived: " + (Objectb2 is Derived));
            
            object greeting = "Hello, World!";
            if (greeting is string message)
            {
                Console.WriteLine(message.ToLower());  // output: hello, world!
                Console.WriteLine(message.ToUpper());  // output: HELLO, WORLD!
                
            }

        }
        
        //reference
        //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/type-testing-and-cast
        //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/type-testing-and-cast#is-operator
        //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/is
        
    }
}