using System.Data;

public class FinanceData
{
    public List<IFinance> FinancialRecord { get; private set; }

    public List<DateOnly> ActivityTimeRecord { get; private set; }

    public FinanceData()
    {
        FinancialRecord = new List<IFinance>();
        ActivityTimeRecord = new List<DateOnly>();

    }


    public void AddAction(IFinance newAction)
    {
        FinancialRecord.Add(newAction);
        ActivityTimeRecord.Add(GetActivityTime());
        ConsoleWriter.PrintActionComplete("");
    }

    private DateOnly GetActivityTime()
    {
        SetTimeOption UserSetTimeChoice = GetUserData.GetSetTimeChoice();
        switch (UserSetTimeChoice)
        {
            case SetTimeOption.Own_Time:
                return GetUserData.GetActivityTime();
            case SetTimeOption.Current_Time:
                return DateOnly.FromDateTime(DateTime.Now);
            default:
                return DateOnly.FromDateTime(DateTime.Now);
        }
    }

    public List<int> SearchActivity()
    {
        List<int> FoundIndexes = new List<int>();
        FoundIndexes.AddRange(SearchOperations.GetSearchResults(FinancialRecord, ActivityTimeRecord));
        PrintRecord(FoundIndexes);
        return FoundIndexes;
    }

    public void EditActivity(int indexToEdit)
    {
        EditOptions UserEditChoice = GetUserData.GetTaskEditChoice();

        switch (UserEditChoice)
        {
            case EditOptions.Edit_Source:
                FinancialRecord[indexToEdit].SetSource();
                break;
            case EditOptions.Edit_Amount:
                FinancialRecord[indexToEdit].SetAmount();
                break;
            case EditOptions.Edit_Time:
                ActivityTimeRecord[indexToEdit] = GetActivityTime();
                break;
        }

    }

    public void PrintRecord(List<int> FoundIndexes)
    {
        if (FoundIndexes.Count == 0 || FoundIndexes[0] == -1)
        {
            Console.WriteLine("No Values matches your Input");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        else
        {
            foreach (int index in FoundIndexes)
            {
                Console.WriteLine($"Index: [{index}]");
                FinancialRecord[index].PrintData();
                Console.WriteLine(ActivityTimeRecord[index]);
            }
            ConsoleWriter.PrintActionComplete("Search Successful");
        }
    }

    public void DeleteAt(int indexToDelete)
    {
        FinancialRecord.RemoveAt(indexToDelete);
        ActivityTimeRecord.RemoveAt(indexToDelete);
        ConsoleWriter.PrintActionComplete("Delete Successful");
    }

    public void PrintBalance()
    {
        int Balance = 0;
        foreach (IFinance Action in FinancialRecord)
        {
            if (Action.GetType().ToString() == "Income")
            {
                Balance += Action.Amount;
            }
            if (Action.GetType().ToString() == "Expense")
            {
                Balance -= Action.Amount;
            }
        }
        ConsoleWriter.PrintBalance(Balance);

    }
}
