

public static class SearchOperations
{
    internal static List<int> GetSearchResults(List<IFinance>  FinancialRecord)
    {
        List<int> FoundIndeces = new List<int>();
        string searchChoice = GetUserData.GetSearchChoice();

        switch (searchChoice)
        {
            case "Action":
                FoundIndeces.AddRange(SearchByAction(FinancialRecord));
                break;
            case "ActionId":
                FoundIndeces.Add(SearchByActionId(FinancialRecord));
                break;
        }
        return FoundIndeces;
    }
    private static int SearchByActionId(List<IFinance> FinancialRecord)
    {
        int transactionId = GetUserData.GetActionId();
        int index = 0;
        foreach(IFinance action in FinancialRecord)
        {
            if(action.TransactionId == transactionId)
            {
                return index;
            }
        }
        return -1;
    }


    private static List<int> SearchByAction(List<IFinance> FinancialRecord)
    {
        List<int> FoundIndeces = new List<int>();
        string searchChoice = GetUserData.GetSearchByActionChoice();
        if(searchChoice == "Income")
        {
            Console.WriteLine("                                     In Income");
            int Index = 0;
            foreach (IFinance action in FinancialRecord)
            {
                if(action.GetType() == typeof(Income))
                {
                    FoundIndeces.Add(Index);
                }
                Index++;
            }
        }
        else
        {
            Console.WriteLine("                                     In Expense");
            int Index = 0;
            foreach (IFinance action in FinancialRecord)
            {
                if (action.GetType() == typeof(Expense))
                {
                    Console.WriteLine(Index);
                    FoundIndeces.Add(Index);
                }
                Index++;
            }
        }

        return FoundIndeces;
    }
}