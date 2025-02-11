using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker.Models
{
    public class Expense : IFinance
    {
        private ExpenseOptions _expenseType;
        private string? _otherExpenseSource;

        public int Amount { get; set; }

        public int TransactionId { get; set; }

        public DateOnly ActionDate { get; set; }

        public Expense(ExpenseOptions expenseOption, string? otherExpenseSource, int amount, int transactionId, DateOnly actionDate)
        {
            _expenseType = expenseOption;
            _otherExpenseSource = otherExpenseSource;
            Amount = amount;
            TransactionId = transactionId;
            ActionDate = actionDate;
        }
        new public string GetType()
        {
            return "Expense";
        }
        public string GetSource()
        {
            if (_expenseType == ExpenseOptions.Other)
            {
                return _otherExpenseSource ?? string.Empty;
            }
            else
            {
                return _expenseType.ToString();
            }
        }

        public void SetSource((int, string) value)
        {
            _expenseType = (ExpenseOptions)value.Item1;
            _otherExpenseSource = value.Item2;
        }
    }
}