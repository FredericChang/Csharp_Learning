using System;
using System.Collections.Generic;
using System.Text;

namespace BankOOP
{
    public class InterestEarningAccount :　BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
            
        }
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest", Guid.NewGuid());
            }
        }
        //將取得每月的點數（以月為結束餘額）。

    }
}