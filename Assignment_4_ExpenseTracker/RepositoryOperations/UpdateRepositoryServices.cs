using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using System;
using Models;
using Assignment_4_ExpenseTracker.HelperUtility;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.RepositoryOperations
{
    public static class UpdateRepositoryServices
    {
        public static void AddIncome(List<Finance> financeData)
        {
            Console.Clear();
            ConsoleWriter.ActionTitleWriter("-- Adding Income __");
            string incomeSource = GetUserData.GetIncomeSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Income(incomeSource, amount, actionId, actionDate));
        }

        public static void AddExpense(List<Finance> financeData)
        {
            Console.Clear();
            ConsoleWriter.ActionTitleWriter("-- Adding Expense __");
            string expenseSource = GetUserData.GetExpenseSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Expense(expenseSource, amount, actionId, actionDate));
        }

        public static void EditActivity(Finance actionToEdit)
        {
            Console.Clear();
            ConsoleWriter.ActionTitleWriter("-- Editing Activity --");
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
        private static void EditActivitySource(Finance actionToEdit)
        {
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Source --");
            if (actionToEdit.GetType().ToString() == "Expense")
            {
                string expenseSource = GetUserData.GetExpenseSource();
                actionToEdit.SourceType = expenseSource;
            }
            else
            {
                string incomeSource = GetUserData.GetIncomeSource();
                actionToEdit.SourceType = incomeSource;
            }
        }
        private static void EditActivityTime(Finance actionToEdit)
        {
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Time --");
            DateOnly actionDate = GetUserData.GetActivityTime();
            actionToEdit.ActionDate = actionDate;
        }

        private static void EditActivityAmount(Finance actionToEdit)
        {
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Amount --");
            int amount = GetUserData.GetAmount();
            actionToEdit.Amount = amount;
        }

        internal static void DeleteAction(List<Finance> FinanceData,Finance finance)
        {
            FinanceData.Remove(finance);
        }
    }
}