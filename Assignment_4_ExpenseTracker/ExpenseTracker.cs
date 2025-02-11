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
        List<IFinance> _repository;
        public ExpenseTracker(List<IFinance> repository)
        {
            _repository = repository;
        }

        public bool Run(MainMenu mainMenuChoice)
        {
            switch (mainMenuChoice)
            {

                case MainMenu.Add_Income:
                    {
                        UpdateRepositoryServices.AddIncome(_repository);
                        ConsoleWriter.PrintActionComplete(ConstantStrings.incomeAddedSuccessfullyMessage);
                        break;
                    }

                case MainMenu.Add_Expense:
                    {
                        UpdateRepositoryServices.AddExpense(_repository);
                        ConsoleWriter.PrintActionComplete(ConstantStrings.expenseAddedSuccessfullyMessage);
                        break;
                    }
                case MainMenu.Search:
                    {
                        List<IFinance> matchingActions = new List<IFinance>();
                        ConsoleWriter.PrintDialog(new SearchOptions());
                        SearchOptions searchChoice = (SearchOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(SearchOptions)).Length);
                        matchingActions = SearchRepositoryServices.GetSearchResults(searchChoice, _repository);
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
                        if (_repository.Any())
                        {
                            ConsoleWriter.PrintListOfActionData(_repository);
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
                        matchingActions = SearchRepositoryServices.GetSearchResults(searchChoice, _repository);
                        if (matchingActions.Count > 0)
                        {
                            ConsoleWriter.PrintListOfActionData(matchingActions);
                            int indexToEdit = GetUserData.GetChoiceFromList(matchingActions.Count());
                            UpdateRepositoryServices.EditActivity(matchingActions[indexToEdit]);
                            ConsoleWriter.PrintActionComplete("Action Updated Successfully");
                        }
                        else
                        {
                            ConsoleWriter.PrintActionFailed(ConstantStrings.SearchFailedMessage);
                        }
                        break;
                    }
                case MainMenu.Delete_Activity:
                    {
                        ConsoleWriter.ActionTitleWriter("-- Deleting Activity --");
                        List<IFinance> matchingActions = new List<IFinance>();
                        ConsoleWriter.PrintDialog(new SearchOptions());

                        ConsoleWriter.ActionTitleWriter("-- Searching Activity --");
                        SearchOptions searchChoice = (SearchOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(SearchOptions)).Length);
                        matchingActions = SearchRepositoryServices.GetSearchResults(searchChoice, _repository);
                        if (matchingActions.Count > 0)
                        {
                            ConsoleWriter.PrintListOfActionData(matchingActions);
                            int indexToDelete = GetUserData.GetChoiceFromList(matchingActions.Count());
                            UpdateRepositoryServices.DeleteAction(_repository, matchingActions[indexToDelete]);
                            ConsoleWriter.PrintActionComplete("Action Deleted Successfully");
                        }
                        else
                        {
                            ConsoleWriter.PrintActionFailed(ConstantStrings.SearchFailedMessage);
                        }
                        break;
                    }
                case MainMenu.View_Summary:
                    {
                        (int, int) summary = SearchRepositoryServices.GetSummary(_repository);
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
