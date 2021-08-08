using System;
using System.Collections.Generic;

namespace BankOOP
{
    public class BankAccount
    {
        public string Number { get;}
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;
        
        private readonly decimal minimumBalance;
        
        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        //TODO: to check this area
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance",Guid.NewGuid());
        }
        
        public void MakeDeposit(decimal amount, DateTime date, string note, Guid guid)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
                //IndexOutOfRangeException 不是最適當的例外狀況：對 ArgumentOutOfRangeException 方法來說更有意義，因為錯誤是由 index 呼叫者傳入的引數所造成。
            }

            var deposit = new Transaction(amount, date, note, guid);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note, Guid guid)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note, Guid.NewGuid());
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
            // if (amount <= 0)
            // {
            //     throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            // }
            //
            // if (Balance - amount < 0)
            // {
            //     throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            // }
            //
            // var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            // var withdrawal = new Transaction(-amount, date, note, guid);
            // allTransactions.Add(withdrawal);
            // if (overdraftTransaction != null)
            //     allTransactions.Add(overdraftTransaction);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote\tGUID");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}\t{item.Guid.ToString()}");
            }
            return report.ToString();
        }

        //Transaction? <= Net 8.0
        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }
        public virtual void PerformMonthEndTransactions() { }

    }
}