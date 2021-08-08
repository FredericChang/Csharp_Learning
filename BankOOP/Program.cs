using System;
using System.Runtime.CompilerServices;

namespace BankOOP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IntroToClasses();
            
            // <FirstTests>
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee",Guid.NewGuid());
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries",Guid.NewGuid());
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money",Guid.NewGuid());
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money",Guid.NewGuid());
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings",Guid.NewGuid());
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills",Guid.NewGuid());
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());
            // </FirstTests>

            // <TestLineOfCredit>
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance",Guid.NewGuid());
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount",Guid.NewGuid());
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs",Guid.NewGuid());
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs",Guid.NewGuid());
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
            // </TestLineOfCredit>

        }

        private static void IntroToClasses()
        {
            var account = new BankAccount("<name>", 1000);
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment", Guid.NewGuid());
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back", Guid.NewGuid());
            Console.WriteLine(account.Balance);
            
            Console.WriteLine(account.GetAccountHistory());

            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caugt");
                Console.WriteLine(e.ToString());
            }

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
        //https://github.com/dotnet/docs/blob/main/docs/csharp/fundamentals/tutorials/snippets/object-oriented-programming/Program.cs
        //https://docs.microsoft.com/zh-tw/dotnet/csharp/fundamentals/tutorials/oop
    }
}