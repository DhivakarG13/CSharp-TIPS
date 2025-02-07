using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;
using Assignment_4_ExpenseTracker.RepositoryManager;
using Constants;
using Constants.Enumerations;
using Repository;

namespace Assignment4ExpenseTracker
{
    public class ExpenseTracker
    {
        public FinanceRepository _repository;
        public ExpenseTracker()
        {
            _repository = new FinanceRepository();
        }

        public bool Run(MainMenu mainMenuChoice)
        {
            switch (mainMenuChoice)
            {

                case MainMenu.Add_Income:
                    {
                        UpdateRepository.AddIncome(_repository.FinanceData);
                        ConsoleWriter.PrintActionComplete(ConstantStrings.incomeAddedSuccessfullyMessage);
                        break;
                    }

                case MainMenu.Add_Expense:
                    {
                        UpdateRepository.AddExpense(_repository.FinanceData);
                        ConsoleWriter.PrintActionComplete(ConstantStrings.expenseAddedSuccessfullyMessage);
                        break;
                    }

                case MainMenu.Close_App:
                    {
                        return true;
                    }

            }
            return false;
        }
    }
}
