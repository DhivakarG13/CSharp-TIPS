using Models;
using Constants.Enumerations;
using Assignment_4_ExpenseTracker.MessageServices;
using Assignment_4_ExpenseTracker.Models;

namespace Assignment_4_ExpenseTracker.RepositoryOperations
{
    public static class SearchRepositoryServices
    {
        public static List<Finance> GetSearchResults(SearchOptions searchChoice, List<Finance> financialRecord)
        {
            List<Finance> matchingActions = new List<Finance>();

            switch (searchChoice)
            {
                case SearchOptions.Source:
                    {
                        string Source = GetUserData.GetStringValue("Enter Your");
                        Console.Clear();
                        matchingActions.AddRange(SearchBySource(Source, financialRecord));
                        break;
                    }
                case SearchOptions.Action:
                    {
                        Console.Clear();
                        ConsoleWriter.ActionTitleWriter("-- Searching by Action --");
                        ConsoleWriter.PrintDialog(new Actions());
                        Actions searchByActionChoice = (Actions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(Actions)).Length);
                        Console.Clear();
                        matchingActions.AddRange(SearchByAction(searchByActionChoice.ToString(), financialRecord));
                        break;
                    }
                case SearchOptions.ActionId:
                    {
                        ConsoleWriter.ActionTitleWriter("-- Searching by Action ID --");
                        int transactionId = GetUserData.GetActionId();
                        Console.Clear();
                        matchingActions.AddRange(SearchByTransactionId(transactionId, financialRecord));
                        break;
                    }
                case SearchOptions.ActionDate:
                    {
                        Console.Clear(); 
                        ConsoleWriter.ActionTitleWriter("-- Searching by Action Date --");
                        ConsoleWriter.PrintDialog(new SearchByActionDateOptions());
                        SearchByActionDateOptions SearchByActionDateChoice = (SearchByActionDateOptions)GetUserData.GetDialogChoice(Enum.GetNames(typeof(SearchByActionDateOptions)).Length);
                        Console.Clear();
                        matchingActions.AddRange(SearchByActionDate(SearchByActionDateChoice, financialRecord));
                        break;
                    }
            }
            return matchingActions;
        }

        private static List<Finance> SearchByActionDate(SearchByActionDateOptions SearchByActionDateChoice, List<Finance> FinancialRecord)
        {
            ConsoleWriter.ActionTitleWriter("-- Searching by Action Date --");
            List<Finance> matchingProducts = new List<Finance>();

            switch (SearchByActionDateChoice)
            {
                case SearchByActionDateOptions.Day:
                    {
                        int DayNumber = GetUserData.GetNumericalValue("Day");
                        int MonthNumber = GetUserData.GetNumericalValue("Month");
                        int YearNumber = GetUserData.GetNumericalValue("Year");
                        int Index = 0;
                        foreach (Finance action in FinancialRecord)
                        {
                            if (action.ActionDate.Day == DayNumber && action.ActionDate.Month == MonthNumber && action.ActionDate.Year == YearNumber)
                            {
                                matchingProducts.Add(action);
                            }
                            Index++;
                        }
                        break;
                    }
                case SearchByActionDateOptions.Month:
                    {
                        int MonthNumber = GetUserData.GetNumericalValue("Month");
                        int YearNumber = GetUserData.GetNumericalValue("Year");
                        int Index = 0;
                        foreach (Finance action in FinancialRecord)
                        {
                            if (action.ActionDate.Month == MonthNumber && action.ActionDate.Year == YearNumber)
                            {
                                matchingProducts.Add(action);
                            }
                            Index++;
                        }
                        break;
                    }
                case SearchByActionDateOptions.Year:
                    {
                        int YearNumber = GetUserData.GetNumericalValue("Year");
                        int Index = 0;
                        foreach (Finance action in FinancialRecord)
                        {
                            if (action.ActionDate.Year == YearNumber)
                            {
                                matchingProducts.Add(action);
                            }
                            Index++;
                        }
                        break;
                    }
            }
            return matchingProducts;
        }

        private static List<Finance> SearchBySource(string Source, List<Finance> FinancialRecord)
        {
            List<Finance> matchingProducts = new List<Finance>();
            foreach (Finance action in FinancialRecord)
            {
                if (Source != null && action.SourceType.Contains(Source))
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }

        private static List<Finance> SearchByTransactionId(int transactionId, List<Finance> FinancialRecord)
        {
            List<Finance> matchingProducts = new List<Finance>();
            foreach (Finance action in FinancialRecord)
            {
                if (action.TransactionId == transactionId)
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }

        private static List<Finance> SearchByAction(string searchByActionChoice, List<Finance> FinancialRecord)
        {
            List<Finance> matchingProducts = new List<Finance>();
            foreach (Finance action in FinancialRecord)
            {
                if (action.GetActionType().Contains(searchByActionChoice))
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }

        internal static (int, int) GetSummary(List<Finance> financeData)
        {
            int income = 0;
            int expense = 0;
            foreach (Finance action in financeData)
            {
                if (action.GetActionType() == "Income")
                {
                    income += action.Amount;
                }
                else if (action.GetActionType() == "Expense")
                {
                    expense += action.Amount;
                }
            }
            return (income, expense);
        }
    }
}