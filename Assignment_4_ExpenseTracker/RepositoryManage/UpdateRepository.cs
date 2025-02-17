using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using System;
using Models;
using Assignment_4_ExpenseTracker.HelperUtility;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.RepositoryManage
{
    public static class UpdateRepository
    {
        public static void AddIncome(List<IFinance> financeData)
        {
            Console.Clear();
            (IncomeOptions, string) incomeSource = GetUserData.GetIncomeSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityDate();
            financeData.Add(new Income(incomeSource.Item1, incomeSource.Item2, amount, actionId, actionDate));
        }

        public static void AddExpense(List<IFinance> financeData)
        {
            Console.Clear();
            (ExpenseOptions, string) expenseSource = GetUserData.GetExpenseSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityDate();
            financeData.Add(new Expense(expenseSource.Item1, expenseSource.Item2, amount, actionId, actionDate));
        }

        public static void EditActivity(IFinance actionToEdit)
        {
            Console.Clear();
            ConsoleWriter.PrintActionData(default, actionToEdit);
            ConsoleWriter.PrintDialog(new EditOptions());
            EditOptions UserEditChoice = (EditOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(EditOptions)).Length);

            switch (UserEditChoice)
            {
                case EditOptions.Edit_Source:
                    EditActivitySource(actionToEdit);
                    break;
                case EditOptions.Edit_Amount:
                    EditActivityAmount(actionToEdit);
                    break;
                case EditOptions.Edit_Time:
                    EditActivityTime(actionToEdit);
                    break;
            }
            Console.Clear();
            ConsoleWriter.PrintActionData(default, actionToEdit);

        }
        private static void EditActivitySource(IFinance actionToEdit)
        {
            if (actionToEdit.GetType().ToString() == "Expense")
            {
                (ExpenseOptions, string) expenseSource = GetUserData.GetExpenseSource();
                (int, string) newSource = ((int)expenseSource.Item1, expenseSource.Item2);
                actionToEdit.SetSource(newSource);
            }
            else
            {
                (IncomeOptions, string) incomeSource = GetUserData.GetIncomeSource();
                (int, string) newSource = ((int)incomeSource.Item1, incomeSource.Item2);
                actionToEdit.SetSource(newSource);
            }
        }
        private static void EditActivityTime(IFinance actionToEdit)
        {
            DateOnly actionDate = GetUserData.GetActivityDate();
            actionToEdit.ActionDate = actionDate;
        }

        private static void EditActivityAmount(IFinance actionToEdit)
        {
            int amount = GetUserData.GetAmount();
            actionToEdit.Amount = amount;
        }
    }
}