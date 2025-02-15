using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker.Models
{
    public class Income : IFinance
    {
        private IncomeOptions _incomeType;
        private string _otherIncomeSource;
        private int _amount;
        private int _transactionId;
        private DateOnly _actionDate;

        public Income(IncomeOptions incomeOption,string otherIncomeSource, int amount, int transactionId, DateOnly actionDate)
        {
            _incomeType = incomeOption;
            _otherIncomeSource = otherIncomeSource;
            _amount = amount;
            _transactionId = transactionId;
            _actionDate = actionDate;
        }

        new public string GetType()
        {
            return "Income";
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

        public int Amount { get => _amount; set => _amount = value; }
        public int TransactionId { get => _transactionId; set => _transactionId = value; }
        public DateOnly ActionDate { get => _actionDate; set => _actionDate = value; }
    }
}