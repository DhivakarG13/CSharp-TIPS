using System;
using System.Transactions;

public class Expense : IFinance
{
    private ExpenseOption _expenseType;
    private string _otherExpenseSource;
    private int _amount;
    private int _transactionId;

    int IFinance.Amount => _amount;
    string IFinance.Source
    {
        get
        {
            if (_expenseType == ExpenseOption.Other)
            {
                return _otherExpenseSource;
            }
            else
            {
                return _expenseType.ToString();
            }
        }
    }
    int IFinance.TransactionId => _transactionId;

    public Expense(List<IFinance> FinancialRecord)
    {

        SetSource();
        SetAmount();
        _transactionId = IdGenerator.TransactionIdGenerator(FinancialRecord);
    }

    public void SetAmount()
    {
        _amount = GetUserData.GetAmount();
    }

    public void SetSource()
    {
        (ExpenseOption, string?) ExpenseSource = GetUserData.GetExpenseSource();
        _expenseType = ExpenseSource.Item1;
        _otherExpenseSource = ExpenseSource.Item2 ?? string.Empty;
    }

    public void PrintData()
    {
        if (_expenseType == ExpenseOption.Other)
        {
            Console.WriteLine($"Expense Type   : {_otherExpenseSource}");
        }
        else
        {
            Console.WriteLine($"Expense Type   : {_expenseType}");
        }
        Console.WriteLine($"Amount         : {_amount}");
        Console.WriteLine($"Transaction Id : {_transactionId}");
    }
}