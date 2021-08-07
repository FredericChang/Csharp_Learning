using System;
namespace BankOOP
{
    public class Transaction
    {
        public decimal Amount { get; }

        public DateTime Date { get; }
        public string Notes { get; }
        public Guid Guid { get; }

        public Transaction(decimal amount, DateTime date, string note, Guid guid)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
            this.Guid = guid;
        }
    }
}