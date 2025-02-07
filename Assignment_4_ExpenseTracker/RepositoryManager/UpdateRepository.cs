using Assignment_4_ExpenseTracker.Models;
using System;
using Models;
using Assignment_4_ExpenseTracker.HelperUtility;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.RepositoryManager
{
    public static class UpdateRepository
    {
        public static void AddIncome(List<IFinance> financeData)
        {
            (IncomeOptions, string?) incomeSource = GetUserData.GetIncomeSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Income(incomeSource.Item1, incomeSource.Item2, amount, actionId, actionDate));
        }
        public static void AddExpense(List<IFinance> financeData)
        {
            (ExpenseOptions, string?) expenseSource = GetUserData.GetExpenseSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Expense(expenseSource.Item1, expenseSource.Item2, amount, actionId, actionDate));
        }
    }
}