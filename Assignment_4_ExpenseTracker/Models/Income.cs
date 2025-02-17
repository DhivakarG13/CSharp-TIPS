using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker.Models
{
    public class Income : IFinance
    {
        private IncomeOptions _incomeType;
        private string? _otherIncomeSource;

        public int Amount { get; set; }

        public int TransactionId { get; set; }

        public DateOnly ActionDate { get; set; }

        public Income(IncomeOptions incomeOption,string? otherIncomeSource, int amount, int transactionId, DateOnly actionDate)
        {
            _incomeType = incomeOption;
            _otherIncomeSource = otherIncomeSource;
            Amount = amount;
            TransactionId = transactionId;
            ActionDate = actionDate;
        }
        public string GetSource()
        {
            if (_incomeType == IncomeOptions.Other)
            {
                return _otherIncomeSource;
            }
            else
            {
                return _incomeType.ToString();
            }
        }

        public void SetSource((int, string) value)
        {
            _incomeType = (IncomeOptions)value.Item1;
            _otherIncomeSource = value.Item2;
        }
    }
}