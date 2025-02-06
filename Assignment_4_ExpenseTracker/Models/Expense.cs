using Constants.Enumerations;
using Models;

namespace Assignment_4_ExpenseTracker.Models
{
    public class Expense : IFinance
    {
        private ExpenseOptions _expenseType;
        private string _otherExpenseSource;
        private int _amount;
        private int _transactionId;
        private DateOnly _actionDate;

        public Expense(ExpenseOptions expenseOption, string otherExpenseSource, int amount, int transactionId, DateOnly actionDate)
        {
            _expenseType = expenseOption;
            _otherExpenseSource = otherExpenseSource;
            _amount = amount;
            _transactionId = transactionId;
            _actionDate = actionDate;
        }
        public string GetSource()
        {
            if (_expenseType == ExpenseOptions.Other)
            {
                return _otherExpenseSource;
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

        public int Amount { get => _amount; set => _amount = value; }
        public int TransactionId { get => _transactionId; set => _transactionId = value; }
        public DateOnly ActionDate { get => _actionDate; set => _actionDate = value; }
    }
}