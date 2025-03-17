using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using Models;
using Assignment_4_ExpenseTracker.HelperUtility;
using Constants.Enumerations;

namespace Assignment_4_ExpenseTracker.RepositoryManager
{
    public static class UpdateRepositoryServices
    {
        public static void AddIncome(List<IFinance> financeData)
        {
            Console.Clear();
            ConsoleWriter.ActionTitleWriter("-- Adding Income __");
            (IncomeOptions, string) incomeSource = GetUserData.GetIncomeSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Income(incomeSource.Item1, incomeSource.Item2, amount, actionId, actionDate));
        }

        public static void AddExpense(List<IFinance> financeData)
        {
            Console.Clear();
            ConsoleWriter.ActionTitleWriter("-- Adding Expense __");
            (ExpenseOptions, string) expenseSource = GetUserData.GetExpenseSource();
            int amount = GetUserData.GetAmount();
            int actionId = IdGenerator.TransactionIdGenerator(financeData);
            ConsoleWriter.PrintTransactionId(actionId);
            DateOnly actionDate = GetUserData.GetActivityTime();
            financeData.Add(new Expense(expenseSource.Item1, expenseSource.Item2, amount, actionId, actionDate));
        }

        public static void EditActivity(IFinance actionToEdit)
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

        private static void EditActivitySource(IFinance actionToEdit)
        {
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Source --");
            if (actionToEdit is Expense)
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
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Time --");
            DateOnly actionDate = GetUserData.GetActivityTime();
            actionToEdit.ActionDate = actionDate;
        }

        private static void EditActivityAmount(IFinance actionToEdit)
        {
            ConsoleWriter.ActionTitleWriter("-- Editing Activity Amount --");
            int amount = GetUserData.GetAmount();
            actionToEdit.Amount = amount;
        }
        internal static void DeleteAction(List<IFinance> FinanceData, IFinance finance)
        {
            FinanceData.Remove(finance);
        }
    }
}