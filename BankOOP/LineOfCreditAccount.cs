using System;
using System.Collections.Generic;
using System.Text;

namespace BankOOP
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }
        // </ConstructLineOfCredit>

        // <ApplyMonthendInterest>
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest",Guid.NewGuid());
            }
        }
        
        
        //可以有負數餘額，但絕對值不能大於點數限制。
        //每個月都會產生利息費，而月底餘額不是0。
        //會在每次提款時產生費用，並超過點數限制。
    }
}