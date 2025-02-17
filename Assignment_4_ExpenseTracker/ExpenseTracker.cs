using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.RepositoryManager;
using Assignment_4_ExpenseTracker.Models;
using Assignment_4_ExpenseTracker.RepositoryManage;
using Constants;
using Constants.Enumerations;
using Models;
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
                case MainMenu.Search:
                    {
                        List<IFinance> matchingActions = new List<IFinance>();
                        ConsoleWriter.PrintDialog(new SearchOptions());
                        SearchOptions searchChoice = (SearchOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(SearchOptions)).Length);
                        matchingActions = SearchRepository.GetSearchResults(searchChoice, _repository.FinanceData);
                        if (matchingActions.Count > 0)
                        {
                            ConsoleWriter.PrintListOfActionData(matchingActions);
                            ConsoleWriter.PrintActionComplete(ConstantStrings.SearchSuccessfulMessage);
                        }
                        else
                        {
                            ConsoleWriter.PrintActionFailed(ConstantStrings.SearchFailedMessage);
                        }
                        break;
                    }
                case MainMenu.View_All_Actions:
                    {
                        if (_repository.FinanceData.Any())
                        {
                            ConsoleWriter.PrintListOfActionData(_repository.FinanceData);
                            ConsoleWriter.PrintActionComplete(ConstantStrings.allActionsDisplayedMessage);
                        }
                        else
                        {
                            ConsoleWriter.PrintActionFailed(ConstantStrings.repositoryEmpty);
                        }
                        break;
                    }
                case MainMenu.Edit_Activity:
                    {
                        List<IFinance> matchingActions = new List<IFinance>();
                        ConsoleWriter.PrintDialog(new SearchOptions());
                        SearchOptions searchChoice = (SearchOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(SearchOptions)).Length);
                        matchingActions = SearchRepository.GetSearchResults(searchChoice, _repository.FinanceData);
                        if (matchingActions.Count > 0)
                        {
                            ConsoleWriter.PrintListOfActionData(matchingActions);
                            int indexToEdit = GetUserData.GetChoiceFromList(matchingActions.Count());
                            UpdateRepository.EditActivity(matchingActions[indexToEdit]);
                            ConsoleWriter.PrintActionComplete("Action Updated Successfully");
                        }
                        else
                        {
                            ConsoleWriter.PrintActionFailed(ConstantStrings.SearchFailedMessage);
                        }
                        break;
                    }
                case MainMenu.View_Summary:
                    {
                        (int, int) summary = SearchRepository.GetSummary(_repository.FinanceData);
                        ConsoleWriter.PrintSummary(summary);
                        ConsoleWriter.PrintActionComplete(string.Empty);
                        break;
                    }
                case MainMenu.Close_App:
                    {
                        return true;
                    }

            }
            Console.Clear();
            return false;
        }
    }
}
