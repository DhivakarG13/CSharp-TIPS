


using System.Threading.Tasks;

public static class SearchOperations
{
    public static List<int> GetSearchResults(List<IFinance> FinancialRecord, List<DateOnly> ActivityTimeRecord)
    {
        List<int> FoundIndexes = new List<int>();
        SearchOption searchChoice = GetUserData.GetSearchChoice();

        switch (searchChoice)
        {
            case SearchOption.Source:
                FoundIndexes.AddRange(SearchBySource(FinancialRecord));
                break;
            case SearchOption.Action:
                FoundIndexes.AddRange(SearchByAction(FinancialRecord));
                break;
            case SearchOption.ActionId:
                FoundIndexes.Add(SearchByTransactionId(FinancialRecord));
                break;
            case SearchOption.ActionDate:
                FoundIndexes.AddRange(SearchByActionDate(ActivityTimeRecord));
                break;
        }
        return FoundIndexes;
    }

    private static List<int> SearchByActionDate(List<DateOnly> ActivityTimeRecord)
    {
        Console.WriteLine("Search by date Option");
        Console.WriteLine("[1]Day [2]month [3]year");
        int SearchByDateChoice = GetUserChoice.GetChoice(new List<int> { 1, 2, 3 });
        List<int> FoundIndexes = new List<int>();
        switch (SearchByDateChoice)
        {
            case 1://Day
                {
                    int DayNumber = GetUserData.GetNumber("Day");
                    int Index = 0;
                    foreach (DateOnly ActivityTime in ActivityTimeRecord)
                    {
                        if (ActivityTime.Day == DayNumber)
                        {
                            FoundIndexes.Add(Index);
                        }
                        Index++;
                    }
                    break;
                }
            case 2://Month
                {
                    int MonthNumber = GetUserData.GetNumber("Month");
                    int Index = 0;
                    foreach (DateOnly ActivityTime in ActivityTimeRecord)
                    {
                        if (ActivityTime.Month == MonthNumber)
                        {
                            FoundIndexes.Add(Index);
                        }
                        Index++;
                    }
                    break;
                }
            case 3://Year
                {
                    int YearNumber = GetUserData.GetNumber("Year");
                    int Index = 0;
                    foreach (DateOnly ActivityTime in ActivityTimeRecord)
                    {
                        if (ActivityTime.Year == YearNumber)
                        {
                            FoundIndexes.Add(Index);
                        }
                        Index++;
                    }
                    break;
                }
        }
        return FoundIndexes;
    }

    private static List<int> SearchBySource(List<IFinance> FinancialRecord)
    {
        List<int> FoundIndexes = new List<int>();
        string? Source = GetUserData.GetSource("Enter your");
        int Index = 0;
        foreach (IFinance Action in FinancialRecord)
        {
            if (Source != null && Action.Source.Contains(Source))
            {
                FoundIndexes.Add(Index);
            }
            Index++;
        }
        return FoundIndexes;
    }

    private static int SearchByTransactionId(List<IFinance> FinancialRecord)
    {
        int transactionId = GetUserData.GetActionId();
        int index = 0;
        foreach (IFinance action in FinancialRecord)
        {
            if (action.TransactionId == transactionId)
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    private static List<int> SearchByAction(List<IFinance> FinancialRecord)
    {
        List<int> FoundIndexes = new List<int>();
        string searchChoice = GetUserData.GetSearchByActionChoice().ToString();
        int Index = 0;
        foreach (IFinance action in FinancialRecord)
        {
            if (action.GetType().ToString() == searchChoice)
            {
                FoundIndexes.Add(Index);
            }
            Index++;
        }
        return FoundIndexes;
    }
}