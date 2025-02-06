using Models;
using Constants.Enumerations;
using Assignment_4_ExpenseTracker.MessageServices;

namespace Assignment_4_ExpenseTracker.RepositoryManager
{
    public static class SearchRepository
    {
        public static List<IFinance> GetSearchResults(SearchOptions searchChoice, List<IFinance> financialRecord)
        {
            List<IFinance> matchingActions = new List<IFinance>();

            switch (searchChoice)
            {
                case SearchOptions.Source:
                    {
                        string Source = GetUserData.GetStringValue("Enter Your");
                        matchingActions.AddRange(SearchBySource(Source, financialRecord));
                        break;
                    }
                case SearchOptions.Action:
                    {
                        ConsoleWriter.PrintDialog(new Actions());
                        Actions searchByActionChoice = (Actions)GetUserData.GetChoice(Enum.GetNames(typeof(Actions)).Length);
                        matchingActions.AddRange(SearchByAction(searchByActionChoice.ToString(), financialRecord));
                        break;
                    }
                case SearchOptions.ActionId:
                    {
                        int transactionId = GetUserData.GetActionId();
                        matchingActions.AddRange(SearchByTransactionId(transactionId, financialRecord));
                        break;
                    }
                case SearchOptions.ActionDate:
                    {
                        ConsoleWriter.PrintDialog(new SearchByActionDateOptions());
                        SearchByActionDateOptions SearchByActionDateChoice = (SearchByActionDateOptions)GetUserData.GetChoice(Enum.GetNames(typeof(SearchByActionDateOptions)).Length);
                        matchingActions.AddRange(SearchByActionDate(SearchByActionDateChoice, financialRecord));
                        break;
                    }
            }
            return matchingActions;
        }

        private static List<IFinance> SearchByActionDate(SearchByActionDateOptions SearchByActionDateChoice, List<IFinance> FinancialRecord)
        {

            List<IFinance> matchingProducts = new List<IFinance>();

            switch (SearchByActionDateChoice)
            {
                case SearchByActionDateOptions.Day:
                    {
                        int DayNumber = GetUserData.GetNumericalValue("Day");
                        int MonthNumber = GetUserData.GetNumericalValue("Month");
                        int YearNumber = GetUserData.GetNumericalValue("Year");
                        int Index = 0;
                        foreach (IFinance action in FinancialRecord)
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
                        foreach (IFinance action in FinancialRecord)
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
                        foreach (IFinance action in FinancialRecord)
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

        private static List<IFinance> SearchBySource(string Source, List<IFinance> FinancialRecord)
        {
            List<IFinance> matchingProducts = new List<IFinance>();
            foreach (IFinance action in FinancialRecord)
            {
                if (Source != null && action.GetSource().Contains(Source))
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }

        private static List<IFinance> SearchByTransactionId(int transactionId, List<IFinance> FinancialRecord)
        {
            List<IFinance> matchingProducts = new List<IFinance>();
            foreach (IFinance action in FinancialRecord)
            {
                if (action.TransactionId == transactionId)
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }

        private static List<IFinance> SearchByAction(string searchByActionChoice, List<IFinance> FinancialRecord)
        {
            List<IFinance> matchingProducts = new List<IFinance>();
            foreach (IFinance action in FinancialRecord)
            {
                if (action.GetType().ToString().Contains( searchByActionChoice))
                {
                    matchingProducts.Add(action);
                }
            }
            return matchingProducts;
        }
    }
}