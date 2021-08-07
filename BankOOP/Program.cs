using System;
using System.Runtime.CompilerServices;

namespace BankOOP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("<name>", 1000);
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment", Guid.NewGuid());
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back", Guid.NewGuid());
            Console.WriteLine(account.Balance);
            
            Console.WriteLine(account.GetAccountHistory());

            // try
            // {
            //     var invalidAccount = new BankAccount("invalid", -55);
            // }
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caugt");
            //     Console.WriteLine(e.ToString());
            // }

            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "attempt to overdraw", new Guid());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caugt trying to overdraw");
                Console.WriteLine(e.ToString());
            }
        }
        //reference
        //[Bank OOP]https://docs.microsoft.com/zh-tw/dotnet/csharp/fundamentals/tutorials/classes
        //https://github.com/dotnet/docs/blob/main/docs/csharp/fundamentals/tutorials/snippets/introduction-to-classes/transaction.cs
    }
}